using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

	private string[] tileTextures;
	private string[] tileObjects;
	public int level;
	public int money;
	// Use this for initialization
	void Start () {
		tileTextures = new string[382];
		tileObjects = new string[382];

		for (int i = 1; i < 382; i++) 
		{
			GameObject tile = GameObject.Find("Floor Tile (" + i + ")");
			tileTextures[i] = tile.GetComponent<Renderer>().material.mainTexture.name;
		}

		SaveData data = new SaveData ();
		data.tileObjects = this.tileObjects;
		data.tileMaterials = tileTextures;
		data.levelReached = level;
		data.money = money;

		SaveLoad.Save ("SaveData.dd", data);

	}
}
