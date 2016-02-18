using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerAI : MonoBehaviour {

	// Use this for initialization
	//private GameObject[] chairsTag;
	//private List<GameObject> chairs; 
	private NavMeshAgent agent;
	private bool hasMoved = false;
	private NavMeshPath path;
	private bool pathComplete = false;
	void Start () {
		path = new NavMeshPath();
	}
	
	// Update is called once per frame
	void Update () {
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
			GameObject nearestChair;

			agent = this.gameObject.GetComponent<NavMeshAgent>();
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
			Debug.Log("Calculating location");
			if(agent.CalculatePath(nearestChair.gameObject.transform.position, path))
			{
				Debug.Log ("Calculated location");
				if(path.status != NavMeshPathStatus.PathPartial)
				{
					Debug.Log("Path is good");
					NavMeshObstacle chairCarve = nearestChair.GetComponent<NavMeshObstacle>();
					PlaceableObject chair = nearestChair.GetComponent<PlaceableObject>();
					if(chair.taken == false)
					{
						agent.SetDestination(nearestChair.gameObject.transform.position);
						chair.taken = true;
						chairCarve.carving = true;
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
	}
}
