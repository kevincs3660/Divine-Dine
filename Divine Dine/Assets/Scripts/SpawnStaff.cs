using UnityEngine;
using System.Collections;

public class SpawnStaff : MonoBehaviour
{
    public GameObject waiterPrefab;
    public GameObject cookPrefab;

    public void PlaceStaff()
    {
        PlaceWaiters();
        PlaceCooks();
    }

    public void PlaceWaiters()
    {
        int remaining = GetComponent<Management>().GetWaiters();
        GameObject[] flooring = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject tile in flooring)
        {
            if(!tile.GetComponent<FloorBehavior>().IsUsed())
            {
                Instantiate(waiterPrefab, tile.transform.position, waiterPrefab.transform.rotation);
                remaining--;
                if(remaining == 0)
                {
                    break;
                }
            }
        }
    }

    public void PlaceCooks()
    {
        int remaining = GetComponent<Management>().GetCooks();
        GameObject[] stoves = GameObject.FindGameObjectsWithTag("Stove");
        foreach (GameObject stove in stoves)
        {
            Vector3 spawnPoint;
            if(stove.GetComponent<PlaceableObject>().rotationOffset == 270)
            {
                spawnPoint = new Vector3(stove.transform.position.x + 1, stove.transform.position.y, stove.transform.position.z);
            }
            else if (stove.GetComponent<PlaceableObject>().rotationOffset == 90)
            {
                spawnPoint = new Vector3(stove.transform.position.x - 1, stove.transform.position.y, stove.transform.position.z);
            }
            else if (stove.GetComponent<PlaceableObject>().rotationOffset == 180)
            {
                spawnPoint = new Vector3(stove.transform.position.x, stove.transform.position.y, stove.transform.position.z + 1);
            }
            else
            {
                spawnPoint = new Vector3(stove.transform.position.x, stove.transform.position.y, stove.transform.position.z - 1);
            }

            Instantiate(cookPrefab, spawnPoint, waiterPrefab.transform.rotation);
            remaining--;
            if (remaining == 0)
            {
                break;
            }
        }
    }
}
