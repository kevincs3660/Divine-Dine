using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

	private string[] tileTextures;
	private string[] tileObjects;
	public int experience;
	public int money;
	// Use this for initialization
	void Start () {


	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
			doSave ();
	}

	private void doSave()
	{
		tileTextures = new string[382];
		tileObjects = new string[382];
		GlobalVariables stats = GameObject.Find("Game Manager").GetComponent<GlobalVariables>();
		experience = stats.experience;
		money = stats.money;
		
		for (int i = 1; i < 382; i++) 
		{
			GameObject tile = GameObject.Find("Floor Tile (" + i + ")");
			Debug.Log(tile.GetComponent<Renderer>().material.mainTexture.name);
			tileTextures[i] = tile.GetComponent<Renderer>().material.mainTexture.name;
			if(tile.GetComponent<FloorBehavior>().GetObject() != null)
				tileObjects[i] = tile.GetComponent<FloorBehavior>().GetObject().ToString();
		}
		
		SaveData data = new SaveData ();
		data.tileObjects = this.tileObjects;
		data.tileMaterials = tileTextures;
		data.experience = experience;
		data.money = money;
		
		SaveLoad.Save ("SaveData.dd", data);
	}
}
