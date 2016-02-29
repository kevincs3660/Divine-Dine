using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	public static Texture[] textures;
	public static GameObject[] objects;
	private SaveData data;

	// Use this for initialization
	void Start () 
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
			doLoad ();
	}

	private void doLoad()
	{
		data = SaveLoad.Load ("SaveData.dd");
		
		
		for(int i = 1; i < 382; i++)
		{
			string currentMaterial = data.tileMaterials[i];
			string currentObject = data.tileObjects[i];
			GameObject tile = GameObject.Find("Floor Tile (" + i + ")");
			GameObject[] placeableObjects = GameObject.Find("Game Manager").gameObject.GetComponent<PlaceObject>().placeablePrefabs;
			GameObject[] placeableMaterials = GameObject.Find ("Game Manager").gameObject.GetComponent<PlaceMaterial>().textures;
			
			
			foreach(GameObject thing in placeableMaterials)
			{
				Debug.Log(thing.name);
				if(currentMaterial == thing.name)
				{
					Debug.Log("Yo in here dawg");
					tile.transform.GetComponent<Renderer>().material.mainTexture = thing.GetComponent<PlaceableMaterial>().material;
				}
			}
			
			/*
			if(currentMaterial == "Grass")
			{
				tile.transform.GetComponent<Renderer>().material.mainTexture = textures[0];
			}
			else if(currentMaterial == "Cement")
			{
				tile.transform.GetComponent<Renderer>().material.mainTexture = textures[1];
			}
			else if(currentMaterial == "DarkWood")
			{
				tile.transform.GetComponent<Renderer>().material.mainTexture = textures[2];
			}
			else if(currentMaterial == "CeramicTile")
			{
				tile.transform.GetComponent<Renderer>().material.mainTexture = textures[3];
			}
			*/
			
			foreach(GameObject thing in placeableObjects)
			{
				if(currentObject == thing.ToString())
				{
					thing.gameObject.GetComponent<PlaceableObject>().isPreview = false;
					Instantiate(thing, tile.transform.position, Quaternion.identity);

				}
			}
			/*
			if(currentObject == "Chair")
			{
				Instantiate(objects[0], tile.transform.position, Quaternion.identity);
			}
			else if(currentObject == "Table")
			{
				Instantiate(objects[1], tile.transform.position, Quaternion.identity);
			}
			else if (currentObject == "Stove");
			{
				Instantiate(objects[2], tile.transform.position, Quaternion.identity);
			}
			*/
		}
	}
}
