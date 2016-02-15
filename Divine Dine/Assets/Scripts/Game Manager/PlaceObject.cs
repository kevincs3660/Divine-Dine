using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {

    public GameObject[] placeablePrefabs;                  //List of objects you can place with the mouse

    private bool active = false;                           //If you are able to place an object with the mouse
    private bool canRotate = false;                        //Option to rotate object if just placed in scene 
    private int selectedPrefab;                            //Which object in the list you are going to place
    private float prefabOffset;                            //The Y offset position from the tile you are placing the new object on
    private Object previewObject;                          //Object created in the scene that is just a preview
    private Vector3 previewFloor = Vector3.zero;           //Floorspace that the preview is ontop of

	void Update ()
    {
        if (active)
        {
            ShowPreview();
            //Place the new object by left clicking
            if (Input.GetMouseButtonDown(0))
            {
                CreateObject();
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

    private void CreateObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Floor" && !hit.transform.GetComponent<FloorBehavior>().IsUsed())
            {
                //Create object in scene
                Instantiate(placeablePrefabs[selectedPrefab],
                    new Vector3(hit.transform.position.x, hit.transform.position.y + prefabOffset, hit.transform.position.z),
                    hit.transform.rotation);

                //Update floor behavior
                hit.transform.GetComponent<FloorBehavior>().SetUsed(true);
                hit.transform.GetComponent<FloorBehavior>().SetObjTag(placeablePrefabs[selectedPrefab].tag);

                //Keep creating objects if they hold control
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    active = false;
                }
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
                && !hit.transform.GetComponent<FloorBehavior>().IsUsed()
                && previewFloor != hit.transform.position)
            {
                //If the position changed, remove the previous preview
                if(previewFloor != Vector3.zero)
                {
                    Destroy(previewObject);
                }

                //Create object in scene
                previewObject = Instantiate(placeablePrefabs[selectedPrefab],
                    new Vector3(hit.transform.position.x, hit.transform.position.y + prefabOffset, hit.transform.position.z),
                    hit.transform.rotation);

                previewFloor = hit.transform.position;
            }
        }
    }
}
