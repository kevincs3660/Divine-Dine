using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerAI : MonoBehaviour {

	private NavMeshAgent agent;
	private bool hasMoved = false;
	private NavMeshPath path;
	private bool pathComplete = false;
	private GameObject entrance;
	private GameObject despawnPoint;
	private GameObject nearestChair;
	private GameObject nearestTable;
	private GameObject table; 
	public float eatTime = 10f;
	private ArrayList menu;
	private bool arrived = false;
	private bool left = false;
	private bool ordered = false;
	public GameObject food;
	public bool hasWaiter = false;
	private Animator anim;
	public float chanceToEnterRestaurant = 0.35f;
	private int level;
	
	public enum customerStates {
		WALKING = 0,
		FOUND_CHAIR = 1,
		WAITING = 2,
		WAITING_FOR_FOOD = 3,
		EATING = 4,
		LEAVING = 5,
		WAITING_FOR_TABLE = 6,
		FOUND_TABLE = 7
	};
	public customerStates state = customerStates.WALKING;
	
	void Start () {
		path = new NavMeshPath();
		agent = this.gameObject.GetComponent<NavMeshAgent>();
		anim = this.gameObject.GetComponent<Animator> ();

		//anim.Play ("Walk");
		anim.SetInteger ("Transition", 1);
		
		entrance = GameObject.Find ("Entrance");
		despawnPoint = GameObject.Find ("CustomerDespawnPoint");

		if (entrance != null) {
			agent.SetDestination(entrance.transform.position);
		}

		level = GameObject.Find ("Game Manager").GetComponent<GlobalVariables> ().CurrentLevel ();
		//Debug.Log("CHance before: " + chanceToEnterRestaurant);
		chanceToEnterRestaurant += level / 50;
		//Debug.Log("CHANCE AFTER: " + chanceToEnterRestaurant);
		//Debug.Log ("RANDOM: " + Random.value);
		eatTime = eatTime * GameObject.Find("Game Manager").GetComponent<GlobalVariables>().gameSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		// When the customer reaches the entrance
		if(Vector3.Distance(entrance.transform.position, agent.nextPosition) <= 0.5f && arrived == false) {
			//Debug.Log("THE FUN HAS ARRIVED");
			Debug.Log(chanceToEnterRestaurant);
			if(Random.value < chanceToEnterRestaurant)
				arrived = true;
			else
			{
				agent.SetDestination(despawnPoint.transform.position);
				state = customerStates.LEAVING;
			}
		}

		// If customer has reached entrance, search for tables first, and then open chairs to wait for a table
		if (arrived && state == customerStates.WALKING) {
			if(!findTable()) {
				findChair();
			}

		}

		// If the customer has reached the despawn point 
		if (state == customerStates.LEAVING && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) {
			Destroy(this.gameObject);
		}

		// If the customer is waiting for a table, keep trying to find a table
		if (state == customerStates.WAITING_FOR_TABLE) {
			anim.SetInteger("Transition",0);
			if(findTable()) {
				NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle> ();
				PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
				chair.taken = false;
				chairCarve.carving = false;
			}
		}

		// If the customer has found and reached a chair to wait in, start waiting for a table
		if (state == customerStates.FOUND_CHAIR && nearestChair != null) {
			if(Vector3.Distance (nearestChair.transform.position, agent.nextPosition) <= 0.6f) {
				state = customerStates.WAITING_FOR_TABLE;
			}
		}

		// If the customer has reached the table, order the food
		if (state == customerStates.FOUND_TABLE && nearestTable != null) {
			if(Vector3.Distance (nearestTable.gameObject.GetComponent<TableScript>().getChair().transform.position, agent.nextPosition) <= 0.6f) {
				if(ordered == false) {
					anim.SetInteger("Transition",0);
					order ();
				}
			}
		}

		// If the customer is done eating, leave and move to the despawn point
		if (state == customerStates.LEAVING && Vector3.Distance (entrance.transform.position, agent.nextPosition) <= 0.5f) {
			agent.SetDestination (despawnPoint.transform.position);
			left = true;
			anim.SetInteger("Transition",1);
		}

		// If the customer has reached the despawn point, die
		if (left && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) {
			Destroy (this.gameObject);
		}
		
	}
	
	/*
	 * Customer selects food from current available menu and then waits for a waiter to take their order 
	 */
	private void order() {
		menu = GameObject.Find("Game Manager").GetComponent<FoodVariables>().GetAllSelectedRecipes();
		foreach(Object it in menu)
			Debug.Log(it.ToString());
		int foodSelected = Random.Range(0,menu.Count);
		food = (GameObject)menu[foodSelected];

		state = customerStates.WAITING;
	}

	/*
	 * Called by the waiter to indicate they have arrived with the food so the customer can start eating
	 */
	public void acceptFood() {
		StartCoroutine(eatFood());
	}

	/*
	 * Creates the food model and then waits for the customer to eat, then makes customer leave to go die
	 */
	private IEnumerator eatFood() {
		state = customerStates.EATING;
		float timer = 0;

		Vector3 tableTop = new Vector3 (nearestTable.transform.position.x, nearestTable.transform.position.y + 1f, nearestTable.transform.position.z);
		GameObject foodModel = (GameObject)Instantiate (food.gameObject.GetComponent<Food> ().model, tableTop, Quaternion.identity);
		anim.SetInteger ("Transition", 2);
        foodModel.tag = "Food";
		
		while (timer < eatTime) {
			timer += Time.deltaTime;
			
			yield return null;
		}
		Destroy (foodModel);
		leaving ();
	}

	/*
	 * Changes state of table and performs other cleanup to prepare for next customer. Adds money and experience
	 */
	private void leaving() {
		//Debug.Log ("Imma leave now");
		//PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
		//NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
		PlaceableObject chair = nearestTable.gameObject.GetComponent<TableScript>().getChair().GetComponent<PlaceableObject> ();
		NavMeshObstacle chairCarve = nearestTable.gameObject.GetComponent<TableScript>().getChair().GetComponent<NavMeshObstacle>();
		chairCarve.carving = false;
		nearestTable.GetComponent<TableScript> ().state = TableScript.tableStates.FREE;
		anim.SetInteger ("Transition", 1);

		GameObject manager = GameObject.Find ("Game Manager");
		manager.gameObject.GetComponent<GlobalVariables> ().AddMoney (15);
        manager.gameObject.GetComponent<GlobalVariables>().AddExperience(food.GetComponent<Food>().level);
		manager.gameObject.GetComponent<FoodVariables> ().AddMarketPoint (1);
	
		agent.SetDestination (entrance.transform.position);
		state = customerStates.LEAVING;
	}

	/*
	 * Allows customer to give order to waiter 
	 */
	public FoodScript giveOrder() {
		state = customerStates.WAITING_FOR_FOOD;
		FoodScript order = new FoodScript (food, this.gameObject);
		return order;
	}

	/*
	 * Called only after a customer has failed to find an open table. Tries to find an open chair where the customer can wait for a table
	 */
	private void findChair() {

		// Gets all chair objects
		GameObject[] chairsTag = GameObject.FindGameObjectsWithTag ("Chair");
		List<GameObject> chairs = new List<GameObject> ();

		// Removes those chairs that are previews or already taken
		for (int j = 0; j < chairsTag.Length; j++)
        {
			if (chairsTag [j].gameObject.GetComponent<PlaceableObject> ().isPreview == false && chairsTag [j].gameObject.GetComponent<PlaceableObject> ().taken == false)
            {
				chairs.Add (chairsTag [j]);
			}
		}

		// If any chairs exist, find the nearest chair
		if (chairs.Count != 0) {
			float distance = 0;
			distance = Vector3.Distance (this.gameObject.transform.position, chairs [0].gameObject.transform.position);
			nearestChair = chairs [0];
			
			if (chairs.Count > 1) {
				for (int i = 1; i < chairs.Count; i++) {
					if (distance > Vector3.Distance (this.gameObject.transform.position, chairs [i].gameObject.transform.position)) {
						distance = Vector3.Distance (this.gameObject.transform.position, chairs [i].gameObject.transform.position);
						nearestChair = chairs [i];
					}
				}
			}

			// If chair is reachable, go there 
			if (agent.CalculatePath (nearestChair.gameObject.transform.position, path)) {
				if (path.status != NavMeshPathStatus.PathPartial) {
					NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle> ();
					PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
					if (chair.taken == false) {
						agent.SetDestination (nearestChair.gameObject.transform.position);
						chair.taken = true;
						chairCarve.carving = true;
						state = customerStates.FOUND_CHAIR;
						Debug.Log("FOUND A CHAIR YO");
					}
				}
			}
			/*
			if (!agent.pathPending && pathComplete == false) {
				if (agent.remainingDistance <= agent.stoppingDistance) {
					if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
						// Done
						pathComplete = true;
						agent.Stop();
					}
				}
			} */
		} else {
			agent.SetDestination(despawnPoint.transform.position);
			state = customerStates.LEAVING;
		}
	}

	/*
	 * Tries to find an open table for the customer. 
	 * 
	 * Return: Boolean indicated whether or not an open table was found
	 */
	private bool findTable() {

		// Get all tables
		GameObject[] tablesTag = GameObject.FindGameObjectsWithTag("Table");
		List<GameObject> tables = new List<GameObject>();

		for(int j = 0; j < tablesTag.Length; j++) {
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(tablesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && tablesTag[j].gameObject.GetComponent<TableScript>().state == TableScript.tableStates.FREE && tablesTag[j].gameObject.GetComponent<TableScript>().hasChair == true) {
				tables.Add(tablesTag[j]);
			}
		}

		// If any tables are left, find the closest one
		if(tables.Count != 0) {
			float distance = 0;
			distance = Vector3.Distance(this.gameObject.transform.position, tables[0].gameObject.transform.position);
			nearestTable = tables[0];
			
			if(tables.Count > 1) {
				for(int i = 1; i < tables.Count; i++) {
					if(distance > Vector3.Distance(this.gameObject.transform.position, tables[i].gameObject.transform.position)) {
						distance = Vector3.Distance(this.gameObject.transform.position, tables[i].gameObject.transform.position);
						nearestTable = tables[i];
					}
				}
			}

			// If the table has a chair associated with it, go there
			if(nearestTable.gameObject.GetComponent<TableScript>().getChair() != null) {
				GameObject tablesChair = nearestTable.gameObject.GetComponent<TableScript>().getChair();

				if(agent.CalculatePath(tablesChair.gameObject.transform.position, path)) {
					if(path.status != NavMeshPathStatus.PathPartial) {

						NavMeshObstacle chairCarve = tablesChair.GetComponent<NavMeshObstacle>();
						//PlaceableObject table = nearestTable.GetComponent<PlaceableObject>();
						PlaceableObject chair = tablesChair.GetComponent<PlaceableObject>();

						if(nearestTable.gameObject.GetComponent<TableScript>().state == TableScript.tableStates.FREE) {

							agent.SetDestination(nearestTable.gameObject.GetComponent<TableScript>().getChair().gameObject.transform.position);
							chair.taken = true;
							//table.taken = true;
							nearestTable.gameObject.GetComponent<TableScript>().state = TableScript.tableStates.USED;
							chairCarve.carving = true;
							//chairCarve.carving = true;
							state = customerStates.FOUND_TABLE;
							return true;
						}
					}
				}
			}

			return false;
		}
		else {
			return false;
		}
	}		
}