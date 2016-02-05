using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {

    public GameObject[] placeablePrefabs;     //List of objects you can place with the mouse

    private bool active = false;               //If you are able to place an object with the mouse
    private int selectedPrefab;               //Which object in the list you are going to place
    private float prefabOffset;               //The Y offset position from the tile you are placing the new object on

	void Update ()
    {
        if (active)
        {
            //Place the new object by left clicking
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Instantiate(placeablePrefabs[selectedPrefab], 
                        new Vector3(hit.transform.position.x, hit.transform.position.y + prefabOffset, hit.transform.position.z),
                        hit.transform.rotation);
                }
            }
        }
    }

    //Select a prefab from the list
    public void SetPrefab(int prefabNumber)
    {
        selectedPrefab = prefabNumber;
        prefabOffset = placeablePrefabs[selectedPrefab].GetComponent<PlaceableObject>().offset;
    }

    //Allow or disallow the placeing of objects
    public void SetActive(bool boolean)
    {
        active = boolean;
    }
}
