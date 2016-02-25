using UnityEngine;
using System.Collections;

public class GodCam : MonoBehaviour {

    public float movementSpeed = 5;      //How fast the camera can move
    public float zoomSpeed = 3;          //How fast the camera can zoom
    public bool isLeashedToCenterPoint;  //Is the camera stuck to a certain spot

    //The following public variables are only neccessary if isLeashedToCenterPoint is true

    public Transform centerPoint;        //Arbitrary object that marks the center point of movement
    public float maxRadius = 50;         //How far away your camera can move from the centerPoint
    public float maxHeight = 50;         //How high your camera can go from ground level
    public float minHeight = 1;          //How low your camera can go (avoid going underground)
    
    private Transform positionCopy;      //Copy of the current position (denoted by an empty child)
    private Vector3 startRotating;       //Point of middle click down to begin camera rotation
    private Vector3 startPosition;       //Copy of the start position for when resetting back to start position
    private Vector3 currentPosition;     //Copy the current position when resetting camera
    private Quaternion startRotation;    //Copy of the start rotation for when resetting back to the start position
    private Quaternion currentRotation;  //Copy the current rotation when resetting camera
    private float startZoom;             //Copy of the camera's starting zoom
    private float currentZoom;           //Copy of the current zoom on the camera
    private bool isResetting = false;    //Check to see if camera is performing Reset function
    private bool changingY = false;      //Make sure we're only going up or down if shift or space was pressed
    private float resetTimer;            //Keeps track of Lerp Time for smooth camera movement
    private float rotateFix = 200;       //How fast the camera can rotate (higher number = slower speed)
    private float radiusDistance;        //How far in XZ new position is from centerpoint
    private float heightDistance;        //How far in Y new position is from the centerpoint
    private float x_axis;                //X Axis movement
    private float y_axis;                //Y Axis movement
    private float z_axis;                //Z Axis movement
    private float x_rotate;              //X Rotation movement
    private float y_rotate;              //Y Rotation movement
    private float x_copy;                //Fix for moving left/right when just trying to move up down
    private float y_copy;                //Fix for moving left/right when just trying to move up down
    private float z_copy;                //Fix for moving up or down if shift or space wasn't pressed



    void Start ()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startZoom = GetComponent<Camera>().fieldOfView;
        positionCopy = transform.GetChild(0);
	}
	
	void Update ()
    {
        if(!isResetting)
        {
            //Always check if camera needs to be moved or rotated
            MoveCamera();
            RotateCamera();
            ZoomCamera();

            //Controls to reset camera back to the start position
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt))
            {
                StartReset();
            }
        }
        else
        {
            Reset();
        }
    }

    void MoveCamera()
    {
        //Reset horizontal and vertical axis
        x_axis = 0;
        y_axis = 0;
        z_axis = 0;

        //Reset vertical fix check variables
        changingY = false;
        x_copy = transform.position.x;
        y_copy = transform.position.y;
        z_copy = transform.position.z;

        //Camera moving right
        if (Input.GetAxis("Horizontal") > 0)
        {
            x_axis += movementSpeed * Time.deltaTime;
        }
        //Camera moving left
        if (Input.GetAxis("Horizontal") < 0)
        {
            x_axis -= movementSpeed * Time.deltaTime;
        }
        //Camera moving forward
        if (Input.GetAxis("Vertical") > 0)
        {
            z_axis += movementSpeed * Time.deltaTime;
        }
        //Camera moving backwards
        if (Input.GetAxis("Vertical") < 0)
        {
            z_axis -= movementSpeed * Time.deltaTime;
        }
        //Camera moving up
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.E))
        {
            y_axis += movementSpeed * Time.deltaTime;
            changingY = true;
        }
        //Camera moving down
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Q))
        {
            y_axis -= movementSpeed * Time.deltaTime;
            changingY = true;
        }

        if(isLeashedToCenterPoint)
        {
            //Check if movement will stay in radius and height bounds
            positionCopy.position = transform.position;
            positionCopy.Translate(new Vector3(x_axis, y_axis, z_axis));
            radiusDistance = Vector3.Distance(centerPoint.position, new Vector3(positionCopy.position.x, centerPoint.position.y, positionCopy.position.z));
            heightDistance = Vector3.Distance(centerPoint.position, new Vector3(centerPoint.position.x, positionCopy.position.y, centerPoint.position.z));

            if (radiusDistance < maxRadius &&
                heightDistance < maxHeight &&
                heightDistance > minHeight)
            {
                //Move the camera (Leashed)
                transform.Translate(new Vector3(x_axis, y_axis, z_axis));
                if(!changingY)
                {
                    transform.position = new Vector3(transform.position.x, y_copy, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(x_copy, transform.position.y, z_copy);
                }
            }
        }
        else
        {
            //Move the camera (Unleashed)
            transform.Translate(new Vector3(x_axis, y_axis, z_axis));
            if (!changingY)
            {
                transform.position = new Vector3(transform.position.x, y_copy, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(x_copy, transform.position.y, z_copy);
            }
        }
    }

    void RotateCamera()
    {
        //Are we getting a request to rotate the camera?
        if(Input.GetMouseButton(2) || (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0)))
        {
            //Is this a new request?
            if(Input.GetMouseButtonDown(2) || (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0)))
            {
                startRotating = Input.mousePosition;
            }
            else
            {
                //The further away the mouse is from it's initial position, the faster the rotation
                //rotateFix is there to slow it down dramatically
                x_rotate = (Input.mousePosition.x - startRotating.x)/rotateFix;
                y_rotate = (startRotating.y - Input.mousePosition.y) /rotateFix;
                transform.Rotate(new Vector3(y_rotate, x_rotate, 0));

                //Make sure that the Z axis is not moving (it likes to if this is not here)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
    }

    void ZoomCamera()
    {
        float x = GetComponent<Camera>().fieldOfView + Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * (-1);
        if (x >= 0 && x <= 100)
        {
            GetComponent<Camera>().fieldOfView += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * (-1);
        }
    }

    void Reset()
    {
        resetTimer += Time.deltaTime;
        transform.position = Vector3.Lerp(currentPosition, startPosition, resetTimer);
        transform.rotation = Quaternion.Lerp(currentRotation, startRotation, resetTimer);
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(currentZoom, startZoom, resetTimer);

        if(resetTimer > 1)
        {
            isResetting = false;
        }
    }

    public void StartReset()
    {
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        currentZoom = GetComponent<Camera>().fieldOfView;
        resetTimer = 0f;
        isResetting = true;
    }
}
