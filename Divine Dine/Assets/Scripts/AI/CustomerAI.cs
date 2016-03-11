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
		LEAVING = 5
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
			findChair();
		}
		
		if (state == customerStates.LEAVING && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) {
			Destroy(this.gameObject);
		}
		
		if (state == customerStates.FOUND_CHAIR && nearestChair != null) {
			if(Vector3.Distance (nearestChair.transform.position, agent.nextPosition) <= 0.6f) {
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
		
		while (timer < eatTime) {
			timer += Time.deltaTime;
			
			yield return null;
		}
		leaving ();
	}
	
	private void leaving() {
		//Debug.Log ("Imma leave now");
		PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
		NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
		chair.taken = false;
		chairCarve.carving = false;
		agent.SetDestination (entrance.transform.position);
		state = customerStates.LEAVING;
	}

	public FoodScript giveOrder() {
		state = customerStates.WAITING_FOR_FOOD;
		FoodScript order = new FoodScript (food, this.gameObject);
		return order;
	}
	
	private void findChair() {
		GameObject[] chairsTag = GameObject.FindGameObjectsWithTag("Chair");
		List<GameObject> chairs = new List<GameObject>();

		for(int j = 0; j < chairsTag.Length; j++) {
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(chairsTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && chairsTag[j].gameObject.GetComponent<PlaceableObject>().taken == false) {
				chairs.Add(chairsTag[j]);
			}
		}
		
		if(chairs.Count != 0) {
			float distance = 0;
			distance = Vector3.Distance(this.gameObject.transform.position, chairs[0].gameObject.transform.position);
			nearestChair = chairs[0];
			
			if(chairs.Count > 1) {
				for(int i = 1; i < chairs.Count; i++) {
					if(distance > Vector3.Distance(this.gameObject.transform.position, chairs[i].gameObject.transform.position)) {
						distance = Vector3.Distance(this.gameObject.transform.position, chairs[i].gameObject.transform.position);
						nearestChair = chairs[i];
					}
				}
			}
			   
			if(agent.CalculatePath(nearestChair.gameObject.transform.position, path)) {
				if(path.status != NavMeshPathStatus.PathPartial) {
					NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
					PlaceableObject chair = nearestChair.GetComponent<PlaceableObject>();
					if(chair.taken == false) {
						agent.SetDestination(nearestChair.gameObject.transform.position);
						chair.taken = true;
						chairCarve.carving = true;
						state = customerStates.FOUND_CHAIR;
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
		}
		else {
			//Debug.Log("Hmm this place seems busy. Imma just go home");
			agent.SetDestination(despawnPoint.transform.position);
			state = customerStates.LEAVING;
		}
	}


}