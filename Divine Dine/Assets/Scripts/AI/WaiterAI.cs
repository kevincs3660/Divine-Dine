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

	public enum waiterStates
	{
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
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(state == waiterStates.NOTHING)
		{
			checkForCustomer();
			if(state == waiterStates.NOTHING)
				checkForFoodWaiting();
		}

		if (state == waiterStates.TAKING_ORDER && currentCustomer != null)
			if(Vector3.Distance (currentCustomer.transform.position, agent.nextPosition) <= 0.3f) 
			{
				currentFood = currentCustomer.giveOrder();
				currentStove = findFreeStove();
				if(currentStove != null)
				{
					agent.SetDestination(currentStove.gameObject.transform.position);
					//currentCustomer = null;
					state = waiterStates.ORDER_TO_STOVE;
				}
			}

		if(state == waiterStates.ORDER_TO_STOVE && currentStove != null)
			if(Vector3.Distance(currentStove.transform.position, agent.nextPosition) <= 0.4f)
			{
				currentStove.GetComponent<StoveScript>().acceptFood(currentFood);
				currentStove = null;
				currentFood = null;
				currentCustomer = null;
				state = waiterStates.NOTHING;
			}

		if (state == waiterStates.PICKING_UP_ORDER && currentStove != null)
			if(Vector3.Distance (currentStove.transform.position, agent.nextPosition) <= 0.3f) 
			{
				currentFood = currentStove.GetComponent<StoveScript>().giveFood();
				currentCustomer = currentFood.customer.GetComponent<CustomerAI>();
				agent.SetDestination(currentCustomer.transform.position);
				state = waiterStates.DELIVERING_ORDER;
				//deliverFood();
			}

		if(state == waiterStates.DELIVERING_ORDER && currentCustomer != null)
			if(Vector3.Distance(currentCustomer.transform.position, agent.nextPosition) <= 0.3f)
			{
				currentCustomer.acceptFood();
				state = waiterStates.NOTHING;
				currentCustomer = null;
			}
	}

	private void takeCustomerOrder(GameObject customer)
	{
		currentCustomer = customer.GetComponent<CustomerAI>();
		agent.SetDestination (customer.gameObject.transform.position);
		//findStove();
	}


	private void checkForCustomer()
	{
		customers = GameObject.FindGameObjectsWithTag("Customer");
		for(int i = 0; i < customers.Length; i++)
		{
			if(customers[i].gameObject.GetComponent<CustomerAI>().state == CustomerAI.customerStates.WAITING)
			{
				state = waiterStates.TAKING_ORDER;
				takeCustomerOrder(customers[i]);
				break;
			}

		}
	}

	private void checkForFoodWaiting()
	{

		GameObject[] stovesTag = GameObject.FindGameObjectsWithTag("Stove");
		//chairs = new GameObject[chairsTag.Length];
		List<GameObject> stoves = new List<GameObject>();
		//int chairIndex = 0;
		for(int j = 0; j < stovesTag.Length; j++)
		{
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(stovesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && stovesTag[j].gameObject.GetComponent<StoveScript>().state == StoveScript.stoveStates.FOOD_READY)
			{
				stoves.Add(stovesTag[j]);
			}
		}
		
		if(stoves.Count != 0)
		{
			pickUpFood(stoves[0]);
			//Instantiate(this);
			//StartCoroutine(cooking());
		}

	}

	private void pickUpFood(GameObject stove)
	{
		state = waiterStates.PICKING_UP_ORDER;
		currentStove = stove;
		agent.SetDestination (stove.gameObject.transform.position);
	}

	private void checkForDirtyTable()
	{
		GameObject[] tablesTag = GameObject.FindGameObjectsWithTag("Table");
		//chairs = new GameObject[chairsTag.Length];
		List<GameObject> tables = new List<GameObject>();
		//int chairIndex = 0;
		for(int j = 0; j < tablesTag.Length; j++)
		{
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(tablesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && tablesTag[j].gameObject.GetComponent<TableScript>().state == TableScript.tableStates.DIRTY)
			{
				tables.Add(tablesTag[j]);
			}
		}
		
		if(tables.Count != 0)
		{
			//state = waiterStates.CLEANING;
			//state = waiterStates.DELIVERING_ORDER;
			//deliverFood(tables[0]);
			//Instantiate(this);
			//StartCoroutine(cooking());
		}
	}

	private GameObject findFreeStove()
	{
		GameObject[] stovesTag = GameObject.FindGameObjectsWithTag("Stove");
		//chairs = new GameObject[chairsTag.Length];
		List<GameObject> stoves = new List<GameObject>();
		//int chairIndex = 0;
		for(int j = 0; j < stovesTag.Length; j++)
		{
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(stovesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && stovesTag[j].gameObject.GetComponent<StoveScript>().state == StoveScript.stoveStates.FREE)
			{
				stoves.Add(stovesTag[j]);
			}
		}
		// just return first stove in list for now
		return stoves[0];
		
	}
}
