using UnityEngine;
using System.Collections;

public class StoveScript : MonoBehaviour {

	private FoodScript currentFood;
	public int cookTime = 10;
	private bool foodGiven = false;
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
	void Update () 
	{
		if(foodGiven)
			foodPickedUp();
	
	}

	public void acceptFood(FoodScript food)
	{
		currentFood = food;
		StartCoroutine(cookFood());
	}

	private IEnumerator cookFood()
	{
		float timer = 0;
		state = stoveStates.COOKING;

		while(timer < cookTime)
		{
			timer += Time.deltaTime;

			yield return null;
		}

		state = stoveStates.FOOD_READY;
	}

	public FoodScript giveFood()
	{
		foodGiven = true;
		return currentFood;
	}

	public void foodPickedUp()
	{
		state = stoveStates.FREE;
		currentFood = null;
		foodGiven = false;
	}
}
