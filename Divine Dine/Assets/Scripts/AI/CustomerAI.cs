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
	public int eatTime = 10;
	private ArrayList menu;
	private bool arrived = false;
	private bool left = false;
	private bool ordered = false;
	public GameObject food;
	public bool hasWaiter = false;
	
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
		
		entrance = GameObject.Find ("Entrance");
		despawnPoint = GameObject.Find ("CustomerDespawnPoint");
		if (entrance != null) {
			agent.SetDestination(entrance.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Vector3.Distance(entrance.transform.position, agent.nextPosition) <= 0.5f) {
			//Debug.Log("THE FUN HAS ARRIVED");
			arrived = true;
		}
		
		if (arrived && state == customerStates.WALKING) {
			//Debug.Log("Finding me dat chair");
			if(!findTable()) {
				findChair();
			}

		}
		
		if (state == customerStates.LEAVING && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) {
			Destroy(this.gameObject);
		}

		if (state == customerStates.WAITING_FOR_TABLE) {
			if(findTable()) {
				NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle> ();
				PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
				chair.taken = false;
				chairCarve.carving = false;
			}
		}

		if (state == customerStates.FOUND_CHAIR && nearestChair != null) {
			if(Vector3.Distance (nearestChair.transform.position, agent.nextPosition) <= 0.6f) {
				//Debug.Log("Sitting in ma chair");
				//StartCoroutine(eatFood());
				//if(ordered == false) {
				//	order ();
				//}
				state = customerStates.WAITING_FOR_TABLE;
			}
		}
		
		if (state == customerStates.FOUND_TABLE && nearestTable != null) {
			if(Vector3.Distance (nearestTable.gameObject.GetComponent<TableScript>().getChair().transform.position, agent.nextPosition) <= 0.6f) {
				//Debug.Log("Sitting in ma chair");
				//StartCoroutine(eatFood());
				if(ordered == false) {
					order ();
				}
			}
		}
		
		if (state == customerStates.LEAVING && Vector3.Distance (entrance.transform.position, agent.nextPosition) <= 0.5f) {
			agent.SetDestination (despawnPoint.transform.position);
			left = true;
		}
		
		if (left && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) {
			Destroy (this.gameObject);
		}
		
	}
	
	
	private void order() {
		menu = GameObject.Find("Game Manager").GetComponent<FoodVariables>().GetAllSelectedRecipes();
		foreach(Object it in menu)
			Debug.Log(it.ToString());
		int foodSelected = Random.Range(0,menu.Count);
		food = (GameObject)menu[foodSelected];

		//Random r1 = new Random();
		//int itemSelected = r1.Next(0, menu.Count);
		state = customerStates.WAITING;

		//StartCoroutine (eatFood ());

	}

	public void acceptFood() {
		StartCoroutine(eatFood());
	}
	
	private IEnumerator eatFood() {
		state = customerStates.EATING;
		float timer = 0;

		Vector3 tableTop = new Vector3 (nearestTable.transform.position.x, nearestTable.transform.position.y + 1f, nearestTable.transform.position.z);
		GameObject foodModel = (GameObject)Instantiate (food.gameObject.GetComponent<Food> ().model, tableTop, Quaternion.identity);
		
		while (timer < eatTime) {
			timer += Time.deltaTime;
			
			yield return null;
		}
		Destroy (foodModel);
		leaving ();
	}
	
	private void leaving() {
		//Debug.Log ("Imma leave now");
		//PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
		//NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
		PlaceableObject chair = nearestTable.gameObject.GetComponent<TableScript>().getChair().GetComponent<PlaceableObject> ();
		NavMeshObstacle chairCarve = nearestTable.gameObject.GetComponent<TableScript>().getChair().GetComponent<NavMeshObstacle>();
		chairCarve.carving = false;
		nearestTable.GetComponent<TableScript> ().state = TableScript.tableStates.FREE;

		GameObject manager = GameObject.Find ("Game Manager");
		//manager.gameObject.GetComponent<GlobalVariables> ().money += 10;
		manager.gameObject.GetComponent<GlobalVariables> ().AddMoney (10);
		manager.gameObject.GetComponent<FoodVariables> ().AddMarketPoint (1);
		//chair.taken = false;
	
		agent.SetDestination (entrance.transform.position);
		state = customerStates.LEAVING;
	}

	public FoodScript giveOrder() {
		state = customerStates.WAITING_FOR_FOOD;
		FoodScript order = new FoodScript (food, this.gameObject);
		return order;
	}
	
	private void findChair() {
		GameObject[] chairsTag = GameObject.FindGameObjectsWithTag ("Chair");
		List<GameObject> chairs = new List<GameObject> ();

		for (int j = 0; j < chairsTag.Length; j++) {
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if (chairsTag [j].gameObject.GetComponent<PlaceableObject> ().isPreview == false && chairsTag [j].gameObject.GetComponent<PlaceableObject> ().taken == false) {
				chairs.Add (chairsTag [j]);
			}
		}
		
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
						//return true;
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
			//Debug.Log("Hmm this place seems busy. Imma just go home");
			//return false;
			agent.SetDestination(despawnPoint.transform.position);
			state = customerStates.LEAVING;
		}
	}

	private bool findTable() {
		GameObject[] tablesTag = GameObject.FindGameObjectsWithTag("Table");
		List<GameObject> tables = new List<GameObject>();

		for(int j = 0; j < tablesTag.Length; j++) {
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(tablesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && tablesTag[j].gameObject.GetComponent<TableScript>().state == TableScript.tableStates.FREE && tablesTag[j].gameObject.GetComponent<TableScript>().hasChair == true) {
				tables.Add(tablesTag[j]);
			}
		}
		//Debug.Log ("Got here");
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

			if(nearestTable.gameObject.GetComponent<TableScript>().getChair() != null)
			{
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
		}
		else {
			//Debug.Log("Hmm this place seems busy. Imma just go home");
			return false;
			//agent.SetDestination(despawnPoint.transform.position);
			//state = customerStates.LEAVING;
		}
	}

		


}