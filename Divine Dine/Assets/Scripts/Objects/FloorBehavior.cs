using UnityEngine;
using System.Collections;

public class FloorBehavior : MonoBehaviour {

    private bool used = false;
    private string objTag = "";

    public bool IsUsed()
    {
        return used;
    }

    public void SetUsed(bool value)
    {
        used = value;
    }

    public string GetObjTag()
    {
        return objTag;
    }

    public void SetObjTag(string value)
    {
        objTag = value;
    }
}
