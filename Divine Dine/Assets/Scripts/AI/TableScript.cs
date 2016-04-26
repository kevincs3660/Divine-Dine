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
	
	public void Calculate () {
		if (!this.gameObject.GetComponent<PlaceableObject> ().isPreview) {
			if (!hasChair)
				checkForChair ();
			if (hasChair)
				checkChairIsNear ();
		}
	
	}

    public void Reset ()
    {
        chair = null;
        hasChair = false;
        state = tableStates.FREE;
    }

	private void checkForChair()
	{
		Debug.Log ("Checking for thing");
		RaycastHit hit;
		Vector3 rayPosition = new Vector3 (this.transform.position.x, this.transform.position.y +0.5f, this.transform.position.z);
		if (Physics.Raycast (rayPosition, new Vector3 (-1f, 0, 0), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				if(!hit.collider.gameObject.GetComponent<PlaceableObject>().isPreview) {
					chair = hit.collider.gameObject;
					chair.GetComponent<PlaceableObject>().taken = true;
					hasChair = true;
					Debug.Log ("HIT THE SHIT1");
				}
			}
		}
		else if (Physics.Raycast (rayPosition, new Vector3 (1f, 0, 0), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				if(!hit.collider.gameObject.GetComponent<PlaceableObject>().isPreview) {
					chair = hit.collider.gameObject;
					chair.GetComponent<PlaceableObject>().taken = true;
					hasChair = true;
					Debug.Log ("HIT THE SHIT2");
				}
			}
		}
		else if (Physics.Raycast (rayPosition, new Vector3 (0, 0, 1f), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				if(!hit.collider.gameObject.GetComponent<PlaceableObject>().isPreview) {
					chair = hit.collider.gameObject;
					chair.GetComponent<PlaceableObject>().taken = true;
					hasChair = true;
					Debug.Log ("HIT THE SHIT3");
				}
			}
		}
		else if (Physics.Raycast (rayPosition, new Vector3 (0, 0, -1f), out hit, 1f)) {
			if(hit.collider.gameObject.tag == "Chair") {
				if(!hit.collider.gameObject.GetComponent<PlaceableObject>().isPreview) {
					chair = hit.collider.gameObject;
					chair.GetComponent<PlaceableObject>().taken = true;
					hasChair = true;
					Debug.Log ("HIT THE SHIT4");
				}
			}
		}
	}

	private void checkChairIsNear()
	{
		if (hasChair) {
			float distance = Vector3.Distance(this.gameObject.transform.position, chair.transform.position);
			if(distance > 1.7f) {
				Debug.Log("Removing Chair because at distance: " + distance);
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

	public void reset()
	{
		state = tableStates.FREE;
		if (hasChair) {
			NavMeshObstacle mesh = chair.GetComponent<NavMeshObstacle>();
			PlaceableObject theChair = chair.GetComponent<PlaceableObject>();
			theChair.taken = true;
			mesh.carving = true;
		}
	}
}
