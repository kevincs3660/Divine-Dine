using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public GameObject button;
    public GameObject mail;

    private int speed;
    private GameObject play;
    private GameObject ff;
    private GameObject ff3;

    private bool tutorial = false;

    void Start ()
    {
        speed = 0;
        play = button.transform.GetChild(0).gameObject;
        ff = button.transform.GetChild(1).gameObject;
        ff3 = button.transform.GetChild(2).gameObject;
        Reset();
    }

    public void Toggle()
    {
        if(speed == 0)
        {
            Time.timeScale = 3;
            play.SetActive(false);
            ff.SetActive(true);
            speed = 1;
        }
        else if (speed == 1)
        {
            ff.SetActive(false);
            ff3.SetActive(true);
            Time.timeScale = 4;
            speed = 2;
        }
        else if (speed == 2)
        {
            Time.timeScale = 1.5f;
            ff3.SetActive(false);
            play.SetActive(true);
            speed = 0;
        }
    }

    public void Reset ()
    {
        Time.timeScale = 1;
        ff.SetActive(false);
        ff3.SetActive(false);
        play.SetActive(true);
        speed = 0;

        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(() => Begin());
        button.GetComponent<Button>().onClick.AddListener(() => GetComponent<PlaceObject>().SetReplace(false));
        button.GetComponent<Button>().onClick.AddListener(() => GetComponent<PaintMaterial>().Disable());
    }

    public void Begin ()
    {
        if(MeetsRequirements())
        {
            if(tutorial)
            {
                GetComponent<TutorialController>().AcheivedTask(26);
            }
            //All calculations to begin the day are done here

            button.GetComponent<Button>().onClick.RemoveAllListeners();
            button.GetComponent<Button>().onClick.AddListener(() => Toggle());
            mail.SetActive(true);

            GetComponent<PlaceObject>().SetActive(false);
            GetComponent<PaintMaterial>().EnableColliders();
            GetComponent<PaintMaterial>().Disable();
            GetComponent<Management>().PayEmployees();
            GetComponent<SpawnStaff>().PlaceStaff();
            GetComponent<FoodVariables>().CalculateMarket();

            //Find out where customers can sit
            GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
            foreach (GameObject table in tables)
            {
                table.GetComponent<TableScript>().Calculate();
            }

            GetComponent<CustomerSpawn>().spawnCustomers(true);
            GetComponent<DayCycle>().Activate();
            GetComponent<MenuManagement>().ShowDayBar();
        }
    }

    private bool MeetsRequirements()
    {
        if(GetComponent<Management>().GetWaiters() > 0)
        {
            if(GetComponent<Management>().GetCooks() > 0)
            {
                return true;
            }
        }
        return false;
    }

    public void Tutorial(bool set)
    {
        tutorial = set;
    }
}
