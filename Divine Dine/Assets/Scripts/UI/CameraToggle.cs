using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour
{
    public GameObject button;
    public GameObject gameCamera;
    public bool checkCamera = false;

    public void ToggleCamera()
    {
        if (!checkCamera)
        {
            button.transform.GetChild(0).gameObject.SetActive(false);
            button.transform.GetChild(1).gameObject.SetActive(true);
            gameCamera.GetComponent<GodCam>().enabled = true;
            checkCamera = true;
        }
        else
        {
            button.transform.GetChild(0).gameObject.SetActive(true);
            button.transform.GetChild(1).gameObject.SetActive(false);
            gameCamera.GetComponent<GodCam>().enabled = false;
            checkCamera = false;
        }
    }

}
