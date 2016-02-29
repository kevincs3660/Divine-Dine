using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerAI_old : MonoBehaviour {

	// Use this for initialization
	//private GameObject[] chairsTag;
	//private List<GameObject> chairs; 
	private NavMeshAgent agent;
	private bool hasMoved = false;
	private NavMeshPath path;
	private bool pathComplete = false;
	private GameObject entrance;
	private GameObject despawnPoint;
	private GameObject nearestChair;
	private GameObject table; 
	public int eatTime = 10;
	public int orderTime = 5;
	private GameObject[] menu;
	private bool arrived = false;
	private bool finishedChair = false;
	private bool imGoingHome = false;
	private bool imEating = false;
	private bool finishedEating = false;
	private bool imLeaving = false;
	private bool left = false;
	private bool eatingNow = false;
	public bool waitingForFood = false;
	private bool orderingNow = false;
	private bool goingToOrder = false;

	enum customerStates
	{
		WALKING = 0,
		FINDING_CHAIR = 1,
		WAITING = 2,
		EATING = 3,
		LEAVING = 4
	};
	private customerStates state = customerStates.WALKING;

	void Start () {
		path = new NavMeshPath();
		agent = this.gameObject.GetComponent<NavMeshAgent>();

		entrance = GameObject.Find ("Entrance");
		despawnPoint = GameObject.Find ("CustomerDespawnPoint");
		if (entrance != null) 
		{
			agent.SetDestination(entrance.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(entrance.transform.position, agent.nextPosition) <= 0.5f)
		{
			//Debug.Log("THE FUN HAS ARRIVED");
			arrived = true;
		}

		if (arrived && finishedChair == false) 
		{
			//Debug.Log("Finding me dat chair");
			findChair();
		}

		if (imGoingHome && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) 
		{
			Destroy(this.gameObject);
		}

		if (goingToOrder && nearestChair != null && orderingNow == false)
		{
			if(Vector3.Distance (nearestChair.transform.position, agent.nextPosition) <= 0.3f) 
			{
				//Debug.Log("Sitting in ma chair");
				//StartCoroutine(eatFood());
				StartCoroutine(ordering());
			}
		}

		if (imLeaving && Vector3.Distance (entrance.transform.position, agent.nextPosition) <= 0.5f) 
		{
			agent.SetDestination (despawnPoint.transform.position);
			left = true;
		}

		if (left && Vector3.Distance (despawnPoint.transform.position, agent.nextPosition) <= 0.3f) 
		{
			Destroy (this.gameObject);
		}

	}
	

	private IEnumerator ordering()
	{
		orderingNow = true;
		float timer = 0;
		
		while (timer < orderTime)
		{
			timer += Time.deltaTime;
			
			yield return null;
		}

		waitingForFood = true;
	}

	private IEnumerator eatFood()
	{
		eatingNow = true;
		//Debug.Log ("eating ma food now");
		float timer = 0;
		
		while (timer < eatTime)
		{
			timer += Time.deltaTime;
			
			yield return null;
		}
		//Debug.Log ("Done eating ma food");
		finishedEating = true;
		leaving ();
	}

	private void leaving()
	{
		//Debug.Log ("Imma leave now");
		PlaceableObject chair = nearestChair.GetComponent<PlaceableObject> ();
		NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
		chair.taken = false;
		chairCarve.carving = false;
		agent.SetDestination (entrance.transform.position);
		imLeaving = true;
	}

	private void findChair()
	{
		GameObject[] chairsTag = GameObject.FindGameObjectsWithTag("Chair");
		//chairs = new GameObject[chairsTag.Length];
		List<GameObject> chairs = new List<GameObject>();
		//int chairIndex = 0;
		for(int j = 0; j < chairsTag.Length; j++)
		{
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(chairsTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && chairsTag[j].gameObject.GetComponent<PlaceableObject>().taken == false)
			{
				chairs.Add(chairsTag[j]);
			}
		}
		
		if(!hasMoved && chairs.Count != 0)
		{
			//Debug.Log("INSIDE THING");
			float distance = 0;
			//Vector3 nearestChairLocation = new Vector3(0,0,0);
			

			//Debug.Log ("Chair length: " + chairs.Count);
			distance = Vector3.Distance(this.gameObject.transform.position, chairs[0].gameObject.transform.position);
			//nearestChairLocation = chairs[0].gameObject.transform.position;
			nearestChair = chairs[0];
			
			if(chairs.Count > 1)
			{
				
				for(int i = 1; i < chairs.Count; i++)
				{
					if(distance > Vector3.Distance(this.gameObject.transform.position, chairs[i].gameObject.transform.position))
					{
						distance = Vector3.Distance(this.gameObject.transform.position, chairs[i].gameObject.transform.position);
						//nearestChairLocation = chairs[i].gameObject.transform.position;
						nearestChair = chairs[i];
					}
				}
			}

			//Debug.Log(agent.CalculatePath(new Vector3(0.5f, 0f, 0.5f), path));
			//Debug.Log(agent.CalculatePath(nearestChair.gameObject.transform.position, path));
			//agent.SetDestination(nearestChair.gameObject.transform.position);   
			hasMoved = true;
			//Debug.Log (nearestChair.gameObject.transform.position);
			//Debug.Log("Calculating location");
			if(agent.CalculatePath(nearestChair.gameObject.transform.position, path))
			{
				//Debug.Log ("Calculated location");
				if(path.status != NavMeshPathStatus.PathPartial)
				{
					//Debug.Log("Path is good");
					NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
					PlaceableObject chair = nearestChair.GetComponent<PlaceableObject>();
					if(chair.taken == false)
					{
						//Debug.Log("Found me a chair. Awwww yissssss");
						agent.SetDestination(nearestChair.gameObject.transform.position);
						chair.taken = true;
						chairCarve.carving = true;
						finishedChair = true;
						//waitingForFood = true;
						goingToOrder = true;
						//imEating = true;
					}
				}
			}
			if (!agent.pathPending && pathComplete == false)
			{
				if (agent.remainingDistance <= agent.stoppingDistance)
				{
					if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
					{
						// Done
						pathComplete = true;
						agent.Stop();
					}
				}
			}
		}
		else
		{
			//Debug.Log("Hmm this place seems busy. Imma just go home");
			agent.SetDestination(despawnPoint.transform.position);
			finishedChair = true;
			imGoingHome = true;
		}
	}
}
