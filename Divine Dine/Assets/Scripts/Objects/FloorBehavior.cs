using UnityEngine;
using System.Collections;

public class FloorBehavior : MonoBehaviour {

    private bool used = false;
    private GameObject obj = null;

    public bool IsUsed()
    {
        return used;
    }

    public void SetUsed(bool value)
    {
        used = value;
    }

    public GameObject GetObject()
    {
        return obj;
    }

    public void SetObj(GameObject value)
    {
        obj = value;
    }
}
