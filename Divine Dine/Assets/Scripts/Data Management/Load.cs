using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	private static Texture[] textures;
	private static GameObject[] objects;
	private Quaternion[] rotations;
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

		int money = data.money;
		int experience = data.experience;
		rotations = data.objectRotations;

		GlobalVariables stats = GameObject.Find("Game Manager").GetComponent<GlobalVariables>();
		stats.money = money;
		stats.experience = experience;
		stats.Startup();

		GameObject[] placeableObjects = GameObject.Find("Game Manager").gameObject.GetComponent<PlaceObject>().placeablePrefabs;
		GameObject[] placeableMaterials = GameObject.Find ("Game Manager").gameObject.GetComponent<PlaceMaterial>().textures;
		
		for(int i = 1; i < 382; i++)
		{
			string currentMaterial = data.tileMaterials[i];
			string currentObject = data.tileObjects[i];
			GameObject tile = GameObject.Find("Floor Tile (" + i + ")");


			foreach(GameObject thing in placeableMaterials)
			{
				Debug.Log(thing.name);
				if(currentMaterial == thing.name)
				{
					Debug.Log("Yo in here dawg");
					tile.transform.GetComponent<Renderer>().material.mainTexture = thing.GetComponent<PlaceableMaterial>().material;
				}
			}

			
			foreach(GameObject thing in placeableObjects)
			{
				if(currentObject == thing.ToString())
				{
					thing.gameObject.GetComponent<PlaceableObject>().isPreview = false;
					Instantiate(thing, tile.transform.position, rotations[i]);

				}
			}
		}
	}
}
