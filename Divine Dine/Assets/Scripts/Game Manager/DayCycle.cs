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
            counter += Time.deltaTime*1.5f;
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
                    else if (hour == 13)
                    {
                        hour = 1;
                    }
                    else if (hour == 7)
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

                    //Check to see if the plot can expand
                    GameObject[] allGrass = GameObject.FindGameObjectsWithTag("Grass");
                    for (int i = 0; i < allGrass.Length; i++)
                    {
                        allGrass[i].GetComponent<LevelHiding>().Check();
                    }

                    GetComponent<MenuManagement>().ShowMainMenu();
                }
            }
        }
    }

    public void Activate()
    {
        if(!active)
        {
            Time.timeScale = 1.5f;
            day++;
            dayText.text = "Day " + day;
            timeText.text = "11:00AM";

            hour = 11;
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
        //Stop new things from happenin
        active = false;
        GetComponent<CustomerSpawn>().spawnCustomers(false);

        //Kill all current customers
        GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
        foreach(GameObject x in customers)
        {
            Destroy(x);
        }

        //Remove all food
        GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
        foreach (GameObject x in food)
        {
            Destroy(x);
        }

        //Check to see if the plot can expand
        GameObject[] allGrass = GameObject.FindGameObjectsWithTag("Grass");
        for (int i = 0; i < allGrass.Length; i++)
        {
            allGrass[i].GetComponent<LevelHiding>().Check();
        }

        //Reset button
        GetComponent<PlayButton>().Reset();
    }
}
