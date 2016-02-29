using UnityEngine;
using System.Collections;

public class StoveScript : MonoBehaviour {

	private FoodScript currentFood;
	public enum stoveStates
	{
		FREE = 0,
		COOKING = 1,
		FOOD_READY = 2
	};
	public stoveStates state = stoveStates.FREE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
