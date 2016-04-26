using UnityEngine;
using System.Collections;

public class CustomerSpawn : MonoBehaviour {

	private bool coroutineStarted = false;
	public int spawnTimer = 20;
	public GameObject spawnPoint1;
	public GameObject spawnPoint2;
	//public GameObject entrance;
	//public GameObject despawnPoint;
	public GameObject customerMale;
	public GameObject customerFemale;
	private bool spawnCustomersCheck = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (coroutineStarted == false && spawnCustomersCheck) 
		{
			StartCoroutine(spawn ());
		}
	
	}

	public void spawnCustomers(bool choice)
	{
		spawnCustomersCheck = choice;
        StopAllCoroutines();
        coroutineStarted = false;
	}

	public bool allCustomersDead()
	{
		GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
		if(customers.Length == 0)
			return true;
		else 
			return false;
	}

	public void resetAllScripts()
	{
		GameObject[] allChairs = GameObject.FindGameObjectsWithTag ("Chair");
		GameObject[] allTables = GameObject.FindGameObjectsWithTag ("Table");
		GameObject[] allStoves = GameObject.FindGameObjectsWithTag ("Stove");
		GameObject[] allWaiters = GameObject.FindGameObjectsWithTag ("Waiter");

		foreach (GameObject obj in allChairs) {
			PlaceableObject chair = obj.GetComponent<PlaceableObject>();
			chair.taken = false;
		}
		foreach (GameObject obj in allTables) {
			TableScript table = obj.GetComponent<TableScript>();
			table.reset();
		}
		foreach (GameObject obj in allStoves) {
			StoveScript stove = obj.GetComponent<StoveScript>();
			stove.reset();
		}
		foreach (GameObject obj in allWaiters) {
			WaiterAI waiter = obj.GetComponent<WaiterAI>();
			waiter.reset();
		}
	}

	IEnumerator spawn()
	{
		coroutineStarted = true;
		float timer = 0;
		float spawnTimeMax = spawnTimer * 2;
		float rand = Random.Range (spawnTimer, spawnTimeMax);
	
		int spawnCheck = Random.Range (0, 2);
		Debug.Log ("SPAWNCHECK: " + spawnCheck);
		while (timer < rand)
		{
			timer += Time.deltaTime;
			
			yield return null;
		}

		float decision = Random.value;
		if(spawnCustomersCheck)
		{
			if(spawnCheck < 1)
			{
				if(decision > 0.5f)
					Instantiate (customerMale, spawnPoint1.transform.position, Quaternion.identity);
				else
					Instantiate (customerFemale, spawnPoint1.transform.position, Quaternion.identity);
			}
			else if(spawnCheck == 1)
			{
				if(decision > 0.5f)
					Instantiate (customerMale, spawnPoint2.transform.position, Quaternion.identity);
				else
					Instantiate (customerFemale, spawnPoint2.transform.position, Quaternion.identity);
			}
			coroutineStarted = false;
		}
	}
}
