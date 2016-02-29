using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodScript : MonoBehaviour {

	//private GameObject stove;
	private bool foundStove;
	private int cookTime; 
	public GameObject customer;
	public GameObject recipe;
	//public bool foodWaiting = false;

	public FoodScript(GameObject recipeObject, GameObject customerObject)
	{
		customer = customerObject;
		recipe = recipeObject;
	}

	// not needed, done in waiter

	/*
	private IEnumerator cooking()
	{
		float timer = 0;

		while (timer < cookTime)
		{
			timer += Time.deltaTime;
			
			yield return null;
		}

		foodWaiting = true;
		// need to notify waiter 
	}
	*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
