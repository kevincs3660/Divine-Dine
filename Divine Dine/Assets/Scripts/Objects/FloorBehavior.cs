using UnityEngine;
using System.Collections;

public class FloorBehavior : MonoBehaviour {

    private bool used = false;
    private GameObject obj = null;
    private float objRotation = 0;

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

    public float GetRotation()
    {
        return objRotation;
    }

    public void SetRotation(float value)
    {
        objRotation = value;
    }
}
