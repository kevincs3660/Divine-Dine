using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	public static Texture[] textures;
	public static GameObject[] objects;
	private SaveData data;

	// Use this for initialization
	void Start () 
	{
		data = SaveLoad.Load ("SaveData.dd");


		for(int i = 1; i < 382; i++)
		{
			string currentMaterial = data.tileMaterials[i];
			string currentObject = data.tileObjects[i];
			GameObject tile = GameObject.Find("Floor Tile (" + i + ")");
			
			
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
		}
	}
}
