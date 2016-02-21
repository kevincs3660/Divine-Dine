using UnityEngine;
using System.Collections;

public class CustomerSpawn : MonoBehaviour {

	private bool coroutineStarted = false;
	public int spawnTimer = 20;
	public GameObject spawnPoint;
	//public GameObject entrance;
	//public GameObject despawnPoint;
	public GameObject customer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (coroutineStarted == false) 
		{
			StartCoroutine(spawn ());
		}
	
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

		Instantiate (customer, spawnPoint.transform.position, Quaternion.identity);
		coroutineStarted = false;
	}
}
