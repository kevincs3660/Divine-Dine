using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaiterAI : MonoBehaviour {

	// Use this for initialization

	private GameObject[] customers;
	private GameObject[] foodItems;
	private bool working; 
	private NavMeshAgent agent;
	private CustomerAI currentCustomer;
	private FoodScript currentFood;
	private GameObject currentStove;
	private bool orderTaken = false;
	private bool orderPickedUp = false;
	private bool waitingForStove = false;
	private Animator anim;

	public enum waiterStates {
		NOTHING = 0,
		TAKING_ORDER = 1,
		ORDER_TO_STOVE = 2,
		PICKING_UP_ORDER = 3,
		DELIVERING_ORDER = 4,
		CLEANING = 5
	};
	public waiterStates state = waiterStates.NOTHING;

	void Start () {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
		anim = this.gameObject.GetComponent<Animator> ();
		anim.SetInteger ("Transition", 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(state == waiterStates.NOTHING) {
			checkForCustomer();
			if(state == waiterStates.NOTHING)
				checkForFoodWaiting();
		}

		if (state == waiterStates.TAKING_ORDER && currentCustomer != null)
			if(Vector3.Distance (currentCustomer.transform.position, agent.nextPosition) <= 1f) {
				currentStove = findFreeStove();
				//Debug.Log("Inside here");
				if(currentStove == null) {
					Debug.Log("CURRENT STOVE IS NULL");
					state = waiterStates.NOTHING;
					currentCustomer.hasWaiter = false;
					currentCustomer = null;
				}
				else {
					//Debug.Log("Found a stove. Moving there now");
					currentFood = currentCustomer.giveOrder();
					//Debug.Log("Got the order");
					agent.SetDestination(currentStove.gameObject.transform.position);
					//currentCustomer = null;
					state = waiterStates.ORDER_TO_STOVE;
				}
			}

		if(state == waiterStates.ORDER_TO_STOVE && currentStove != null)
			if(Vector3.Distance(currentStove.transform.position, agent.nextPosition) <= 1.2f) {
				//Debug.Log("Got to stove");
				agent.ResetPath();
				currentStove.GetComponent<StoveScript>().acceptFood(currentFood);
				currentStove = null;
				currentFood = null;
				currentCustomer = null;
				state = waiterStates.NOTHING;
			}

		if (state == waiterStates.PICKING_UP_ORDER && currentStove != null)
			if(Vector3.Distance (currentStove.transform.position, agent.nextPosition) <= 1.2f) {
				//Debug.Log("AT THE FUCKING STOVE");
				currentFood = currentStove.GetComponent<StoveScript>().giveFood();
				currentCustomer = currentFood.customer.gameObject.GetComponent<CustomerAI>();
				agent.SetDestination(currentCustomer.transform.position);
				state = waiterStates.DELIVERING_ORDER;
			}

		if(state == waiterStates.DELIVERING_ORDER && currentCustomer != null)
			if(Vector3.Distance(currentCustomer.transform.position, agent.nextPosition) <= 1.5f) {
				agent.ResetPath();
				currentCustomer.acceptFood();
				state = waiterStates.NOTHING;
				currentCustomer = null;
			}
	}

	private void takeCustomerOrder(GameObject customer) {
		currentCustomer = customer.GetComponent<CustomerAI>();
		agent.SetDestination (customer.gameObject.transform.position);
		//findStove();
	}


	private void checkForCustomer() {
		customers = GameObject.FindGameObjectsWithTag("Customer");

		if (customers != null) {
			for (int i = 0; i < customers.Length; i++) {
				//Debug.Log (customers.Length);
				CustomerAI cust = customers [i].gameObject.GetComponent<CustomerAI> ();
				if (cust != null) {
					if(cust.state == CustomerAI.customerStates.WAITING && cust.hasWaiter == false) {
						//Debug.Log("Found customer waiting");
						state = waiterStates.TAKING_ORDER;
						cust.hasWaiter = true;
						takeCustomerOrder (customers [i]);
						break;
					}
				}
			}
		}
	}

	private void checkForFoodWaiting() {
		GameObject[] stovesTag = GameObject.FindGameObjectsWithTag("Stove");
		List<GameObject> stoves = new List<GameObject>();

		for(int j = 0; j < stovesTag.Length; j++) {
			if(stovesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && stovesTag[j].gameObject.GetComponent<StoveScript>() != null) {
				if(stovesTag[j].gameObject.GetComponent<StoveScript>().state == StoveScript.stoveStates.FOOD_READY && stovesTag[j].gameObject.GetComponent<StoveScript>().hasWaiter == false) {
					
					//Debug.Log("FOUND READY FOOD");
					stoves.Add(stovesTag[j]);
					stoves[0].gameObject.GetComponent<StoveScript>().hasWaiter = true;

					state = waiterStates.PICKING_UP_ORDER;
					currentStove = stoves[0];
					agent.SetDestination (stoves[0].gameObject.transform.position);
					return;
					//pickUpFood(stoves[0]);
				}
			}
		}
	}

	private void pickUpFood(GameObject stove) {
		Debug.Log ("PICKING UP FOOD");
		state = waiterStates.PICKING_UP_ORDER;
		currentStove = stove;
		agent.SetDestination (stove.gameObject.transform.position);
	}

	private void checkForDirtyTable() {
		GameObject[] tablesTag = GameObject.FindGameObjectsWithTag("Table");
		List<GameObject> tables = new List<GameObject>();

		for(int j = 0; j < tablesTag.Length; j++) {
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(tablesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && tablesTag[j].gameObject.GetComponent<TableScript>().state == TableScript.tableStates.DIRTY) {
				tables.Add(tablesTag[j]);
			}
		}
		
		if(tables.Count != 0) {
			//state = waiterStates.CLEANING;
			//state = waiterStates.DELIVERING_ORDER;
			//deliverFood(tables[0]);
			//Instantiate(this);
			//StartCoroutine(cooking());
		}
	}

	private GameObject findFreeStove() {
		GameObject[] stovesTag = GameObject.FindGameObjectsWithTag("Stove");
		List<GameObject> stoves = new List<GameObject>();
		GameObject bestStove = null;
		int stoveOrderCount;

		for(int j = 0; j < stovesTag.Length; j++) {
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(stovesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && stovesTag[j].gameObject.GetComponent<StoveScript>() != null) {
				stoves.Add(stovesTag[j]);
			}
		}
		//Debug.Log ("Added stove to thing");
		if (stoves.Count != 0) {
			//Debug.Log("At least one stove");
			stoveOrderCount = stoves[0].gameObject.GetComponent<StoveScript>().getOrderCount();
			bestStove = stoves[0];
			if(stoves[0].gameObject.GetComponent<StoveScript>().state == StoveScript.stoveStates.FREE) {
				//Debug.Log("returning from first free check. Stove is: " + stoves[0]);
				return stoves[0];
			}
			foreach(GameObject stove in stoves) {
				if(stove.gameObject.GetComponent<StoveScript>().getOrderCount() <= stoveOrderCount) {
					stoveOrderCount = stove.gameObject.GetComponent<StoveScript>().getOrderCount();
					if(stove.gameObject.GetComponent<StoveScript>().state == StoveScript.stoveStates.FREE) {
						//Debug.Log("returning from second free check. Stove is: " + stoves[0]);
						return stove;
					}
					//Debug.Log("Just set bestStove to something");
					bestStove = stove;
				}
			}
		}
		//Debug.Log("returning from the end. Stove is : " + bestStove);
		return bestStove;
	}

	public void reset()
	{
		state = waiterStates.NOTHING;
		currentCustomer = null;
		currentFood = null;
		currentStove = null;
	}
}
