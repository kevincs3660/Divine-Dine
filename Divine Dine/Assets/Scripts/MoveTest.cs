using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {

	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			RaycastHit hit2;
			Vector3 movePosition = new Vector3(0,0,0);
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				Debug.Log(ray.direction);
				//Ray newray = new Ray(hit.point - hit.normal * 1000f, hit.normal);
				Vector3 reverse = new Vector3(ray.direction.x * -1f, ray.direction.y * -1f, ray.direction.z * -1f);
				Debug.Log(reverse);
				reverse.Scale(new Vector3(5f, 5f, 5f));
				//Debug.Log("Final vector" + reverse);
				Vector3 newPosition = new Vector3(hit.point.x + reverse.x, hit.point.y + reverse.y, hit.point.z + reverse.z);
				//hit.collider.Raycast(newray, out hit2, 100);
				//Debug.Log ("reverse ray direction " + newray.direction);
			 	//ray.direction
				//Debug.Log("Current hitpoint: " + hit.point);
				//hit.point.Set(hit.point.x - (ray.direction.x * 2f), hit.point.y - (ray.direction.y * 2f), hit.point.z);
				//Debug.Log ("new hitpoint: " + hit.point);
				/*
				GameObject table = GameObject.Find("Table");
				if(table != null)
				{

					float distance = Vector3.Distance(table.transform.GetChild(0).position, this.gameObject.transform.position);
					for(int i = 1; i < table.transform.childCount; i++)
					{
						if(Vector3.Distance(table.transform.GetChild(i).position, this.gameObject.transform.position) < distance)
							movePosition = table.transform.GetChild(i).position;
					}
				}
				agent.SetDestination(movePosition);*/
				agent.SetDestination (hit.point);
				//Debug.Log("Old: " + hit.point);
				//Debug.Log("New: " + newPosition);
				//agent.SetDestination(newPosition);
			}
		
		}
	
	}
}
