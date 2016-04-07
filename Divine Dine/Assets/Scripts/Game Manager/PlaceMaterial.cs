using UnityEngine;
using System.Collections;

public class PlaceMaterial : MonoBehaviour
{
    public GameObject[] textures;

    private bool active;
    private int selectedPrefab;
    private GameObject previewFloor;
    private GameObject placedFloor;
    private Texture oldTexture;
    private Texture newTexture;

    void Update()
    {
        if(active)
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Floor"
                && previewFloor != hit.transform.gameObject)
            {
                if(previewFloor != null)
                {
                    previewFloor.GetComponent<Renderer>().material.mainTexture = oldTexture;
                }
                oldTexture = hit.transform.GetComponent<Renderer>().material.mainTexture;
                previewFloor = hit.transform.gameObject;
                previewFloor.GetComponent<Renderer>().material.mainTexture = newTexture;
            }
        }
    }

    private void SetMaterial()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.transform.tag == "Floor")
            {
                previewFloor = null;
                GetComponent<GlobalVariables>().AddMoney(0 - textures[selectedPrefab].GetComponent<PlaceableMaterial>().cashValue);
                MoneyCheck();
            }
        }
    }

    public void ReadyMaterial(int index)
    {
        selectedPrefab = index;
        newTexture = textures[selectedPrefab].GetComponent<PlaceableMaterial>().material;
        active = true;
        MoneyCheck();
    }

    private void MoneyCheck()
    {
        if (!(textures[selectedPrefab].GetComponent<PlaceableMaterial>().cashValue <= GetComponent<GlobalVariables>().money))
            active = false;
    }

    public void Disable()
    {
        active = false;
        if (previewFloor != null)
        {
            previewFloor.GetComponent<Renderer>().material.mainTexture = oldTexture;
        }
    }
}
