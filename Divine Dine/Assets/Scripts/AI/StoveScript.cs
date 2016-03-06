using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoveScript : MonoBehaviour {

	private FoodScript currentFood;
	public int cookTime = 10;
	private bool foodGiven = false;
	public bool hasWaiter = false;
	public Queue<FoodScript> foodQueue;
	public int foodCount;

	public enum stoveStates {
		FREE = 0,
		COOKING = 1,
		FOOD_READY = 2
	};
	public stoveStates state = stoveStates.FREE;

	// Use this for initialization
	void Start () {
		foodQueue = new Queue<FoodScript> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(foodGiven)
			foodPickedUp();
		if (state != stoveStates.COOKING && state != stoveStates.FOOD_READY) {
			if(foodQueue.Count != 0){
				currentFood = foodQueue.Dequeue();
				foodCount = foodQueue.Count;
				state = stoveStates.COOKING;
				StartCoroutine(cookFood());
			}
		}
	}

	public void acceptFood(FoodScript food) {
		//Debug.Log ("STOVE GOT FOOD");
		foodQueue.Enqueue (food);
		foodCount = foodQueue.Count;
		//currentFood = food;
		//state = stoveStates.COOKING;
		//StartCoroutine(cookFood());
	}

	private IEnumerator cookFood(){
		float timer = 0;
		
		while(timer < cookTime) {
			timer += Time.deltaTime;

			yield return null;
		}

		//Debug.Log ("FINISHED COOKING");
		state = stoveStates.FOOD_READY;
	}

	public int getOrderCount() {
		return foodQueue.Count;
	}

	public FoodScript giveFood() {
		foodGiven = true;
		return currentFood;
	}

	public void foodPickedUp() {
		hasWaiter = false;
		state = stoveStates.FREE;
		currentFood = null;
		foodGiven = false;
	}
}
