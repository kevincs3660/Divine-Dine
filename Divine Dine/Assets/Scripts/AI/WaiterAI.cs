using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaiterAI : MonoBehaviour {

	// Use this for initialization

	private GameObject[] customers;
	private GameObject[] foodItems;
	private bool working; 
	private NavMeshAgent agent;
	void Start () {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!working)
		{
			checkForCustomer();
			if(!working)
				checkForFoodWaiting();
		}
	}

	private void takeCustomerOrder(GameObject customer)
	{
		//findStove();
	}

	private void deliverFood(GameObject food)
	{
	}

	private void checkForCustomer()
	{
		customers = GameObject.FindGameObjectsWithTag("Customer");
		for(int i = 0; i < customers.Length; i++)
		{
			if(customers[i].gameObject.GetComponent<CustomerAI>().waitingForFood == true)
			{
				takeCustomerOrder(customers[i]);
				break;
			}

		}
	}

	private void checkForFoodWaiting()
	{

		foodItems = GameObject.FindGameObjectsWithTag("FoodItem");
		for(int i = 0; i < customers.Length; i++)
		{
			if(foodItems[i].gameObject.GetComponent<FoodScript>().foodWaiting == true)
			{
				deliverFood(foodItems[i]);
				break;
			}
			
		}

	}

	private void checkForDirtyTable();
	{
	}

	private void findStove()
	{
		GameObject[] stovesTag = GameObject.FindGameObjectsWithTag("Stove");
		//chairs = new GameObject[chairsTag.Length];
		List<GameObject> stoves = new List<GameObject>();
		//int chairIndex = 0;
		for(int j = 0; j < stovesTag.Length; j++)
		{
			//Debug.Log( chairsTag[j].gameObject.transform.position);
			if(stovesTag[j].gameObject.GetComponent<PlaceableObject>().isPreview == false && stovesTag[j].gameObject.GetComponent<PlaceableObject>().taken == false)
			{
				stoves.Add(stovesTag[j]);
			}
		}
		
		if(stoves.Count != 0)
		{
			//Instantiate(this);
			//StartCoroutine(cooking());
		}
		
	}
}
