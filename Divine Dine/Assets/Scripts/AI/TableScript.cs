using UnityEngine;
using System.Collections;

public class TableScript : MonoBehaviour {

	public enum tableStates
	{
		FREE = 0,
		USED = 1,
		DIRTY = 2
	};
	public tableStates state = tableStates.FREE;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
