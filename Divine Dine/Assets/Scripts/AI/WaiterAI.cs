using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaiterAI : MonoBehaviour {

	// Use this for initialization

	private GameObject[] customers;
	private GameObject[] foodItems;
	private bool working; 
	private NavMeshAgent agent;
	private GameObject currentCustomer;
	private FoodScript currentFood;
	private GameObject currentStove;

	public enum waiterStates
	{
		NOTHING = 0,
		TAKING_ORDER = 1,
		DELIVERING_ORDER = 2,
		CLEANING = 3
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

			}
		if (state == waiterStates.DELIVERING_ORDER && currentStove != null)
			if(Vector3.Distance (currentStove.transform.position, agent.nextPosition) <= 0.3f) 
			{
				//deliverFood();
			}
	}

	private void takeCustomerOrder(GameObject customer)
	{
		currentCustomer = customer;
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
			if(stovesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && stovesTag[j].gameObject.GetComponent<StoveScript>().state == StoveScript.stoveStates.FREE)
			{
				stoves.Add(stovesTag[j]);
			}
		}
		
		if(stoves.Count != 0)
		{
			state = waiterStates.DELIVERING_ORDER;
			deliverFood(stoves[0]);
			//Instantiate(this);
			//StartCoroutine(cooking());
		}

	}

	private void deliverFood(GameObject stove)
	{
		currentStove = stove;
		agent.SetDestination (stove.gameObject.transform.position);
	}

	private void checkForDirtyTable()
	{
	}

	private void findStove()
	{

		
	}
}
