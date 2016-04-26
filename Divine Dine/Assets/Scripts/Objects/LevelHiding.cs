using UnityEngine;
using System.Collections;

public class LevelHiding : MonoBehaviour
{
    public int level;

    private GameObject manager;
    private bool set;

    void Awake ()
    {
        manager = GameObject.Find("Game Manager");
        set = false;
        tag = "Grass";
        GetComponent<Renderer>().material.mainTexture = manager.GetComponent<GlobalVariables>().grassMaterial.GetComponent<PlaceableMaterial>().material;
        Check();
    }

    public void Check()
    {
        manager.GetComponent<GlobalVariables>().CalculateLevel();
        if(level <= manager.GetComponent<GlobalVariables>().CurrentLevel() && !set)
        {
            set = true;
            tag = "Floor";
            GetComponent<Renderer>().material.mainTexture = manager.GetComponent<PaintMaterial>().textures[manager.GetComponent<PaintMaterial>().currentPrefab].GetComponent<PlaceableMaterial>().material;
        }
    }
}
