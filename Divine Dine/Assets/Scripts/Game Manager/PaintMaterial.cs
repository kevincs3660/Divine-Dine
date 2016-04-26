using UnityEngine;
using System.Collections;

public class PaintMaterial : MonoBehaviour
{

    public GameObject[] textures;
    public int currentPrefab = 0;

    private bool active;
    private int selectedPrefab = 0;
    private Texture oldTexture;
    private Texture newTexture;

    void Update()
    {
        if (active)
        {
            ShowPreview();
            if (Input.GetMouseButtonDown(0))
            {
                SetMaterial();
            }
        }
    }

    private void ShowPreview()
    {
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject f in floors)
        {
            f.GetComponent<Renderer>().material.mainTexture = newTexture;
        }
    }

    private void SetMaterial()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Floor")
            {
                if(selectedPrefab != currentPrefab)
                {
                    currentPrefab = selectedPrefab;
                    GetComponent<GlobalVariables>().AddMoney(0 - textures[selectedPrefab].GetComponent<PlaceableMaterial>().cashValue);
                    active = false;
                }
            }
        }
    }

    public void ReadyMaterial(int index)
    {
        if(index != selectedPrefab)
        {
            selectedPrefab = index;
            newTexture = textures[selectedPrefab].GetComponent<PlaceableMaterial>().material;
            oldTexture = textures[currentPrefab].GetComponent<PlaceableMaterial>().material;
            active = true;
            MoneyCheck();
        }
    }

    private void MoneyCheck()
    {
        if (!(textures[selectedPrefab].GetComponent<PlaceableMaterial>().cashValue <= GetComponent<GlobalVariables>().money))
            active = false;
    }

    public void Disable()
    {
        active = false;
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject f in floors)
        {
            f.GetComponent<Renderer>().material.mainTexture = textures[currentPrefab].GetComponent<PlaceableMaterial>().material;
        }
    }

    public void DisableColliders()
    {
        GameObject[] stoves = GameObject.FindGameObjectsWithTag("Stove");
        foreach (GameObject stove in stoves)
        {
            stove.GetComponent<BoxCollider>().enabled = false;
        }

        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        foreach (GameObject chair in chairs)
        {
            chair.GetComponent<BoxCollider>().enabled = false;
        }

        GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
        foreach (GameObject table in tables)
        {
            table.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void EnableColliders()
    {
        GameObject[] stoves = GameObject.FindGameObjectsWithTag("Stove");
        foreach (GameObject stove in stoves)
        {
            stove.GetComponent<BoxCollider>().enabled = true;
        }

        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        foreach (GameObject chair in chairs)
        {
            chair.GetComponent<BoxCollider>().enabled = true;
        }

        GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
        foreach (GameObject table in tables)
        {
            table.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
