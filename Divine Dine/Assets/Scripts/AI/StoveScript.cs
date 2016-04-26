using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoveScript : MonoBehaviour {

	private FoodScript currentFood;
	public float cookTime = 10;
	private bool foodGiven = false;
	private GameObject foodModel;
	public bool hasWaiter = false;
	public Queue<FoodScript> foodQueue;
	public int foodCount;
	public GameObject pot;
	public GameObject cloche;
	private GameObject clocheDestroy;

	public enum stoveStates {
		FREE = 0,
		COOKING = 1,
		FOOD_READY = 2
	};
	public stoveStates state = stoveStates.FREE;

	// Use this for initialization
	void Start () {
		foodQueue = new Queue<FoodScript> ();

		cookTime = cookTime * GameObject.Find("Game Manager").GetComponent<GlobalVariables>().gameSpeed;
	
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

    public void Reset ()
    {
        StopAllCoroutines();
        state = stoveStates.FREE;
        foodQueue = new Queue<FoodScript>();
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
		GameObject newPot = (GameObject)Instantiate(pot, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z), Quaternion.identity);
		newPot.tag = "Food";
		while(timer < cookTime) {
			timer += Time.deltaTime;

			yield return null;
		}
		Destroy (newPot);
		//Debug.Log ("FINISHED COOKING");
		state = stoveStates.FOOD_READY;
		//Instantiate(GameObject.Find("TomatoSoup"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z), Quaternion.identity);
		//foodModel = (GameObject)Instantiate(currentFood.recipe.GetComponent<Food>().model, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z), Quaternion.identity);
		clocheDestroy = (GameObject)Instantiate(cloche, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z), Quaternion.identity);
		clocheDestroy.tag = "Food";
        //foodModel.tag = "Food";
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
		//Destroy (foodModel);'
		Destroy (clocheDestroy);
		state = stoveStates.FREE;
		currentFood = null;
		foodGiven = false;
	}

	public void reset()
	{
		currentFood = null;
		state = stoveStates.FREE;
		foodQueue = new Queue<FoodScript> ();
		hasWaiter = false;
		foodGiven = false;
		foodCount = 0;
	}
}
