using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    public int day;
    public int hour;
    public int min;
    public GameObject bar;

    private Text timeText;
    private Text dayText;
    private float counter;
    private bool active;
    private bool ending;
    private string ampm;

    void Start ()
    {
        day = 0;
        timeText = bar.transform.GetChild(1).GetComponent<Text>();
        dayText = bar.transform.GetChild(2).GetComponent<Text>();
    }

    void Update ()
    {
        if(active)
        {
            counter += Time.deltaTime;
            if(counter >= 1)
            {
                min++;
                counter--;

                if(min < 10)
                {
                    timeText.text = hour + ":0" + min + ampm;
                }
                else if (min == 60)
                {
                    hour++;
                    min = 0;

                    if(hour == 12)
                    {
                        ampm = "PM";
                    }
                    else if (hour == 8)
                    {
                        ending = true;
                        GetComponent<CustomerSpawn>().spawnCustomers(false);
                    }

                    timeText.text = hour + ":00" + ampm;
                }
                else
                {
                    timeText.text = hour + ":" + min + ampm;
                }
            }

            if(ending)
            {
                if(GetComponent<CustomerSpawn>().allCustomersDead())
                {
                    active = false;
                    GetComponent<MenuManagement>().ShowMainMenu();
                }
            }
        }
    }

    public void Activate()
    {
        if(!active)
        {
            day++;
            dayText.text = "Day " + day;
            timeText.text = "9:00AM";

            hour = 9;
            min = 0;
            counter = 0;

            ampm = "AM";

            active = true;
            ending = false;

            GetComponent<CustomerSpawn>().spawnCustomers(true);
            GetComponent<FoodVariables>().CalculateMarket();
            GetComponent<Management>().PayEmployees();
        }
    }

    public void Deactivate()
    {
        active = false;
        GetComponent<CustomerSpawn>().spawnCustomers(false);
        GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
        foreach(GameObject x in customers)
        {
            Destroy(x);
        }
        GetComponent<PlayButton>().Reset();
    }
}
