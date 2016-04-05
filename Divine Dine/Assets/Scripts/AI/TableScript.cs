using UnityEngine;
using System.Collections;

public class TableScript : MonoBehaviour {

	private GameObject chair;
	public bool hasChair = false;

	public enum tableStates
	{
		FREE = 0,
		USED = 1,
		DIRTY = 2
	};
	public tableStates state = tableStates.FREE;
	// Use this for initialization
	void Start () {
		chair = null;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasChair)
			checkForChair ();
		if (hasChair)
			checkChairIsNear ();
	
	}

	private void checkForChair()
	{
		//Debug.Log ("Checking for thing");
		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, new Vector3 (-1f, 0, 0), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				chair = hit.collider.gameObject;
				chair.GetComponent<PlaceableObject>().taken = true;
				hasChair = true;
				Debug.Log ("HIT THE SHIT1");
			}
		}
		else if (Physics.Raycast (this.transform.position, new Vector3 (1f, 0, 0), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				chair = hit.collider.gameObject;
				chair.GetComponent<PlaceableObject>().taken = true;
				hasChair = true;
				Debug.Log ("HIT THE SHIT2");
			}
		}
		else if (Physics.Raycast (this.transform.position, new Vector3 (0, 0, 1f), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				chair = hit.collider.gameObject;
				chair.GetComponent<PlaceableObject>().taken = true;
				hasChair = true;
				Debug.Log ("HIT THE SHIT3");
			}
		}
		else if (Physics.Raycast (this.transform.position, new Vector3 (0, 0, -1f), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				chair = hit.collider.gameObject;
				chair.GetComponent<PlaceableObject>().taken = true;
				hasChair = true;
				Debug.Log ("HIT THE SHIT4");
			}
		}

		//if (Physics.Raycast (this.transform.position, new Vector3(-1f,0,0), 1f, LayerMask.NameToLayer("Default"))) {
		//	Debug.Log("HIT THE SHIT");
		//}
	}

	private void checkChairIsNear()
	{
		if (hasChair) {
			float distance = Vector3.Distance(this.gameObject.transform.position, chair.transform.position);
			if(distance > 1f) {
				Debug.Log("Removing Chair");
				chair.gameObject.GetComponent<PlaceableObject>().taken = false;
				chair = null;
				hasChair = false;
			}
		}
	}

	public GameObject getChair()
	{
		return chair;
	}
}
