using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {

    public GameObject[] placeablePrefabs;                  //List of objects you can place with the mouse

    private bool active = false;                           //If you are able to place an object with the mouse
    private bool replace = false;                          //If you are able to replace an existing object
    private bool canRotate = false;                        //Option to rotate object if just placed in scene 
    private bool alreadyExisted = false;                   //If the item is being replaced from an existing one or new from shop
    private int selectedPrefab;                            //Which object in the list you are going to place
    private float prefabSpaceOffset;                       //The Y offset position from the tile you are placing the new object on
    private float prefabRotationOffset;                    //The rotation offset so it faces south
    private GameObject previewObject;                      //Object created in the scene that is just a preview
    private GameObject placedObject;                       //Object created in the scene after clicking
    private GameObject floorRef;                           //Floorspace that the placed object is ontop of
    private Vector3 previewFloor = Vector3.zero;           //Position of floorspace that the preview is ontop of
    private Vector3 placedFloor = Vector3.zero;            //Position of floorspace that the placed object is ontop of
    private Vector3 facingFloor = Vector3.zero;            //Position of floorspace that the placed object should face during rotation

	void Update ()
    {
        if (active && !canRotate)
        {
            ShowPreview();
            //Place the new object by left clicking
            if (Input.GetMouseButtonDown(0))
            {
                CreateObject();
            }
        }
        else if(canRotate)
        {
            RotateObject();
        }
        else if (!active && replace && Input.GetMouseButtonDown(0))
        {
            ReplaceObject();
        }
    }

    //Select a prefab from the list
    public void SetPrefab(int prefabNumber)
    {
        selectedPrefab = prefabNumber;
        prefabSpaceOffset = placeablePrefabs[selectedPrefab].transform.position.y;
        prefabRotationOffset = placeablePrefabs[selectedPrefab].GetComponent<PlaceableObject>().rotationOffset;
    }

    //Allow or disallow the placing of objects
    public void SetActive(bool boolean)
    {
        active = boolean;
        if (!active && previewObject != null)
            Destroy(previewObject);
    }

    public void SetReplace(bool boolean)
    {
        replace = boolean;
    }

    private void CreateObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Floor" && !hit.transform.GetComponent<FloorBehavior>().IsUsed())
            {
                //Destroy preview
                Destroy(previewObject);
                previewFloor = Vector3.zero;
                placedFloor = hit.transform.position;
                floorRef = hit.transform.gameObject;

                //Create object in scene
                placedObject = Instantiate(placeablePrefabs[selectedPrefab],
                    new Vector3(hit.transform.position.x, hit.transform.position.y + prefabSpaceOffset, hit.transform.position.z),
                    placeablePrefabs[selectedPrefab].transform.rotation) as GameObject;

                //Update floor behavior
                hit.transform.GetComponent<FloorBehavior>().SetUsed(true);
                hit.transform.GetComponent<FloorBehavior>().SetObj(placeablePrefabs[selectedPrefab]);

                //Allow the player to rotate the object
                canRotate = true;

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
                    new Vector3(hit.transform.position.x, hit.transform.position.y + prefabSpaceOffset, hit.transform.position.z),
                    placeablePrefabs[selectedPrefab].transform.rotation) as GameObject;

                previewFloor = hit.transform.position;
            }
        }
    }

    private void RotateObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            facingFloor = hit.transform.position;

            if (facingFloor.x - placedFloor.x < 0)
            {
                placedObject.transform.eulerAngles = (new Vector3(0, prefabRotationOffset+ 90, 0));
                placedObject.GetComponent<PlaceableObject>().yRotation = 90;
            }
            else if (facingFloor.x - placedFloor.x > 0)
            {
                placedObject.transform.eulerAngles = (new Vector3(0, prefabRotationOffset + 270, 0));
                placedObject.GetComponent<PlaceableObject>().yRotation = 270;
            }
            else if (facingFloor.z - placedFloor.z < 0)
            {
                placedObject.transform.eulerAngles = (new Vector3(0, prefabRotationOffset, 0));
                placedObject.GetComponent<PlaceableObject>().yRotation = 0;
            }
            else if (facingFloor.z - placedFloor.z > 0)
            {
                placedObject.transform.eulerAngles = (new Vector3(0, prefabRotationOffset + 180, 0));
                placedObject.GetComponent<PlaceableObject>().yRotation = 180;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Object has been perminately placed in the scene
            canRotate = false;
            placedObject.GetComponent<PlaceableObject>().indexNumber = selectedPrefab;
            placedObject.GetComponent<PlaceableObject>().isPreview = false;
            placedObject.GetComponent<PlaceableObject>().floorSpace = floorRef;
            placedObject.GetComponent<BoxCollider>().enabled = true;
            if(!alreadyExisted)
            {
                GetComponent<GlobalVariables>().AddMoney(0 - placeablePrefabs[selectedPrefab].GetComponent<PlaceableObject>().cashValue);
            }
            alreadyExisted = false;
            MoneyCheck();
        }
    }

    private void ReplaceObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.transform.GetComponent<PlaceableObject>() != null)
            {
                alreadyExisted = true;
                hit.transform.GetComponent<PlaceableObject>().floorSpace.GetComponent<FloorBehavior>().SetUsed(false);
                ReadyObject(hit.transform.GetComponent<PlaceableObject>().indexNumber);
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public void ReadyObject(int index)
    {
        SetPrefab(index);
        active = true;
        if(!alreadyExisted)
        {
            MoneyCheck();
        }
    }

    private void MoneyCheck()
    {
        if (!(placeablePrefabs[selectedPrefab].GetComponent<PlaceableObject>().cashValue <= GetComponent<GlobalVariables>().money))
            active = false;
    }
}
