using UnityEngine;
using System.Collections;

public class CustomerAI : MonoBehaviour {

	// Use this for initialization
	public GameObject[] tables;
	private NavMeshAgent agent;
	private bool hasMoved = false;
	private NavMeshPath path;
	void Start () {
		path = new NavMeshPath();
		/*
		float distance = 0;
		Vector3 nearestTable = new Vector3(0,0,0);
		tables = GameObject.FindGameObjectsWithTag("Table");
		agent = this.gameObject.GetComponent<NavMeshAgent>();

		for(int i = 1; i < tables.Length; i++)
		{
			distance = Vector3.Distance(this.gameObject.transform.position, tables[0].gameObject.transform.position);
			if(distance > Vector3.Distance(this.gameObject.transform.position, tables[i].gameObject.transform.position))
			{
				distance = Vector3.Distance(this.gameObject.transform.position, tables[i].gameObject.transform.position);
				nearestTable = tables[i].gameObject.transform.position;
			}
		}

		agent.SetDestination(nearestTable);*/
	
	}
	
	// Update is called once per frame
	void Update () {
		tables = GameObject.FindGameObjectsWithTag("Table");
		if(!hasMoved && tables.Length != 0)
		{
			float distance = 0;
			Vector3 nearestTable = new Vector3(0,0,0);

			agent = this.gameObject.GetComponent<NavMeshAgent>();

			if(tables.Length > 1)
			{
				for(int i = 1; i < tables.Length; i++)
				{
					distance = Vector3.Distance(this.gameObject.transform.position, tables[0].gameObject.transform.position);
					if(distance > Vector3.Distance(this.gameObject.transform.position, tables[i].gameObject.transform.position))
					{
						distance = Vector3.Distance(this.gameObject.transform.position, tables[i].gameObject.transform.position);
						nearestTable = tables[i].gameObject.transform.position;
					}
				}
			}
			else 
			{
				distance = Vector3.Distance(this.gameObject.transform.position, tables[0].gameObject.transform.position);
				nearestTable = tables[0].gameObject.transform.position;
			}
			hasMoved = true;
			if(agent.CalculatePath(nearestTable, path))
				if(path.status != NavMeshPathStatus.PathPartial)
					agent.SetDestination(nearestTable);
		}
	
	}
}
