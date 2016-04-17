using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour
{
    public int costPerWaiter;
    public int costPerCook;
    private int waiters = 0;
    private int cooks = 0;
    private int avail = 0;

    public void PayEmployees()
    {
        GetComponent<GlobalVariables>().AddMoney(-TotalExpenses());
    }

    public int TotalExpenses()
    {
        return (WaiterCost()+CookCost());
    }

    public int WaiterCost()
    {
        return (waiters * costPerWaiter);
    }

    public int CookCost()
    {
        return (cooks * costPerCook);
    }

    public void SubWaiter()
    {
        if (waiters > 1)
        {
            waiters--;
            CheckAvail();
        }
    }

    public void AddWaiter()
    {
        if(avail > 0)
        {
            waiters++;
            CheckAvail();
        }
    }

    public void SubCook()
    {
        if(cooks > 1)
        {
            cooks--;
            CheckAvail();
        }
    }

    public void AddCook()
    {
        if(avail > 0)
        {
            GameObject[] stoves = GameObject.FindGameObjectsWithTag("Stove");
            if (stoves.Length > cooks)
            {
                cooks++;
                CheckAvail();
            }
        }
    }

    public void CheckCooks()
    {
        GameObject[] stoves = GameObject.FindGameObjectsWithTag("Stove");
        if(cooks > stoves.Length)
        {
            cooks--;
            CheckCooks();
        }
    }

    public void CheckAvail()
    {
        avail = 1 + GetComponent<GlobalVariables>().CurrentLevel() - waiters - cooks;
    }

    public int GetAvail()
    {
        return avail;
    }

    public int GetWaiters()
    {
        return waiters;
    }

    public int GetCooks()
    {
        return cooks;
    }
}
