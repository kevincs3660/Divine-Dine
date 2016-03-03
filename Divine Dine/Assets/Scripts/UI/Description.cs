using UnityEngine;
using System.Collections;

public class Description : MonoBehaviour {

    public string description = "";
    private string message = "";

    void OnGUI()
    {
        //Debug.Log("OnGUI");
        GUI.Label(new Rect(10, 10, 200, 30), message);
    }

    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
        message = description;
    }

    void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
        message = "";
    }
}
