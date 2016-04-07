using UnityEngine;
using System.Collections;

public class CustomerSpawn : MonoBehaviour {

	private bool coroutineStarted = false;
	public int spawnTimer = 20;
	public GameObject spawnPoint;
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

	IEnumerator spawn()
	{
		coroutineStarted = true;
		float timer = 0;

		while (timer < spawnTimer)
		{
			timer += Time.deltaTime;
			
			yield return null;
		}

		float decision = Random.value;
		if(spawnCustomersCheck)
		{
			if(decision > 0.5f)
				Instantiate (customerMale, spawnPoint.transform.position, Quaternion.identity);
			else
				Instantiate (customerFemale, spawnPoint.transform.position + new Vector3(0,-1,0), Quaternion.identity);
			coroutineStarted = false;
		}
	}
}
