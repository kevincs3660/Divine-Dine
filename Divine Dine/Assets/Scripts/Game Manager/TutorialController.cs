using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject[] tutorials;
    public GameObject bottomCanvas;
    public GameObject playButton;
    public GameObject cameraLock;
    public GameObject mail;
    public int current = 0;

    private bool accomplishedTask = true;


    //Main Menu
    private Button mainButton1;
    private Button mainButton2;
    private Button mainButton3;
    private Button mainButton4;
    private Button mainButton5;

    //Shop Scroll
    private Button homeButton;
    private Button shopBack;
    private Button shopNext;
    private Button s_button1;
    private Button s_button2;
    private Button s_button3;
    private Button s_button4;

    void Start()
    {
        mainButton1 = bottomCanvas.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton2 = bottomCanvas.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton3 = bottomCanvas.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton4 = bottomCanvas.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton5 = bottomCanvas.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<Button>();

        homeButton = bottomCanvas.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Button>();
        shopBack = bottomCanvas.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Button>();
        shopNext = bottomCanvas.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<Button>();
        s_button1 = bottomCanvas.transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<Button>();
        s_button2 = bottomCanvas.transform.GetChild(1).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<Button>();
        s_button3 = bottomCanvas.transform.GetChild(1).transform.GetChild(5).transform.GetChild(0).gameObject.GetComponent<Button>();
        s_button4 = bottomCanvas.transform.GetChild(1).transform.GetChild(6).transform.GetChild(0).gameObject.GetComponent<Button>();

        playButton.GetComponent<Button>().interactable = false;
        cameraLock.GetComponent<Button>().interactable = false;
        mainButton1.interactable = false;
        mainButton2.interactable = false;
        mainButton3.interactable = false;
        mainButton4.interactable = false;
        mainButton5.interactable = false;
        homeButton.interactable = false;
        shopBack.interactable = false;
        shopNext.interactable = false;
        s_button1.interactable = false;
        s_button2.interactable = false;
        s_button3.interactable = false;
        s_button4.interactable = false;

        tutorials[current].SetActive(true);
    }

    public void Next()
    {
        if(accomplishedTask)
        {
            tutorials[current].SetActive(false);
            current++;
            tutorials[current].SetActive(true);
            Special();
        }
    }

    public void Hide()
    {
        tutorials[current].SetActive(false);
    }

    public void AcheivedTask(int set)
    {
        if(set == current)
        {
            accomplishedTask = true;
        }
    }

    public void Finish()
    {
        playButton.GetComponent<Button>().interactable = true;
        cameraLock.GetComponent<Button>().interactable = true;
        mainButton1.interactable = true;
        mainButton2.interactable = true;
        mainButton3.interactable = true;
        mainButton4.interactable = true;
        mainButton5.interactable = true;
        homeButton.interactable = true;
        shopBack.interactable = true;
        shopNext.interactable = true;
        s_button1.interactable = true;
        s_button2.interactable = true;
        s_button3.interactable = true;
        s_button4.interactable = true;

        tutorials[current].SetActive(false);

        enabled = false;
    }

    private void Special()
    {
        if(current == 2)
        {
            mainButton2.interactable = true;
            mainButton2.onClick.AddListener(() => Next());
        }
        else if(current == 3)
        {
            mainButton2.onClick.AddListener(() => Next());
        }
        else if (current == 5)
        {
            s_button1.interactable = true;
            s_button1.onClick.AddListener(() => Hide());
        }
        else if (current == 6)
        {
            s_button1.interactable = false;
        }
        else if (current == 7)
        {
            s_button2.interactable = true;
            s_button3.interactable = true;
            s_button2.onClick.AddListener(() => Hide());
            s_button3.onClick.AddListener(() => Hide());
            accomplishedTask = false;
        }
        else if (current == 8)
        {
            homeButton.interactable = true;
            mainButton1.interactable = true;
            s_button1.interactable = true;
            mainButton1.onClick.AddListener(() => Next());
        }
        else if (current == 13)
        {
            mainButton1.interactable = false;
            mainButton2.interactable = false;
            mainButton3.interactable = false;
            mainButton4.interactable = true;
        }
        else if (current == 14)
        {
            mainButton1.interactable = false;
            mainButton2.interactable = false;
            mainButton3.interactable = false;
            mainButton4.interactable = false;
            mainButton5.interactable = false;
        }
        else if (current == 15)
        {
            mainButton3.interactable = true;
        }
        else if (current == 17)
        {
            mainButton1.interactable = true;
            mainButton2.interactable = true;
        }
        else if (current == 19)
        {
            mainButton1.onClick.AddListener(() => Next());
        }
        else if (current == 20)
        {
            mainButton1.interactable = false;
            mainButton2.interactable = false;
            mainButton3.interactable = true;
            mainButton4.interactable = false;
            mainButton5.interactable = false;
        }
        else if (current == 26)
        {
            accomplishedTask = false;
            playButton.GetComponent<Button>().interactable = true;
            GetComponent<PlayButton>().Tutorial(true);
        }
        else if (current == 27)
        {
            GetComponent<PlayButton>().Tutorial(false);
            mail.GetComponent<Button>().interactable = false;
        }
        else if (current == 28)
        {
            accomplishedTask = false;
            mail.GetComponent<Button>().interactable = true;
            mail.GetComponent<Button>().onClick.AddListener(() => Hide());
            GetComponent<QuizController>().Tutorial(true);
        }
        else if (current == 29)
        {
            GetComponent<QuizController>().Tutorial(false);
            cameraLock.GetComponent<Button>().interactable = true;
        }
        else if (current == 36)
        {
            accomplishedTask = false;
            GetComponent<DayCycle>().Tutorial(true);
        }
    }

    void Update()
    {
        if(current == 5)
        {
            GameObject[] stoves = GameObject.FindGameObjectsWithTag("Stove");
            if (stoves.Length > 0)
            {
                if(!stoves[0].GetComponent<PlaceableObject>().isPreview)
                {
                    Next();
                    GetComponent<PlaceObject>().SetActive(false);
                }
            }
        }
        else if(current == 7)
        {
            GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
            foreach (GameObject table in tables)
            {
                if(!table.GetComponent<PlaceableObject>().isPreview)
                {
                    table.GetComponent<TableScript>().Tutorial();
                }
            }
            Next();
        }
        else if (current == 8)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu")
            {
                Next();
            }
        }
        else if(current == 11)
        {
            if(GetComponent<MenuManagement>().GetMenuType() == "Main Menu")
            {
                tutorials[current].SetActive(true);
                if (GetComponent<Management>().GetWaiters() > 0 && GetComponent<Management>().GetCooks() > 0)
                {
                    Next();
                }
            }
            else
            {
                Hide();
            }
        }
        else if (current == 13)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "Market")
            {
                Next();
            }
        }
        else if (current == 15)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "The Market")
            {
                Next();
            }
        }
        else if (current == 17)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu")
            {
                Next();
                Next();
                mainButton1.interactable = true;
            }
        }
        else if (current == 19)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "Menu")
            {
                Next();
            }
        }
        else if (current == 20)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "Appetizers")
            {
                Next();
            }
        }
        else if (current == 21)
        {
            if (GetComponent<FoodVariables>().starterAppetizer.GetComponent<Food>().level == 2 && GetComponent<FoodVariables>().bonusDish.GetComponent<Food>().level == 1)
            {
                Next();
            }
        }
        else if (current == 26)
        {
            Next();
        }
        else if (current == 28)
        {
            Next();
        }
        else if (current == 36)
        {
            Next();
        }

        if(current >= 2)
        {
            if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu" || GetComponent<MenuManagement>().GetMenuType() == "Management" || GetComponent<MenuManagement>().GetMenuType() == "Store Menu")
            {
                mainButton2.interactable = true;
            }
            if (current >= 8 && current < 19)
            {
                if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu" || GetComponent<MenuManagement>().GetMenuType() == "Management")
                {
                    mainButton1.interactable = false;
                }
                else
                {
                    if(GetComponent<MenuManagement>().GetMenuType() == "Store Menu" || GetComponent<MenuManagement>().GetMenuType() == "Items")
                    {
                        mainButton1.interactable = true;
                    }
                }
            }
            if (current >= 11)
            {
                if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu" || GetComponent<MenuManagement>().GetMenuType() == "Management")
                {
                    mainButton3.interactable = true;
                }
                else
                {
                    if (GetComponent<MenuManagement>().GetMenuType() == "Store Menu" || GetComponent<MenuManagement>().GetMenuType() == "Items")
                    {
                        mainButton3.interactable = false;
                    }
                }
                if (current >= 13)
                {
                    if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu" || GetComponent<MenuManagement>().GetMenuType() == "Management")
                    {
                        mainButton4.interactable = true;
                    }
                    if (current >= 19)
                    {
                        if (GetComponent<MenuManagement>().GetMenuType() == "Market")
                        {
                            mainButton4.interactable = true;
                        }
                        else if (GetComponent<MenuManagement>().GetMenuType() == "Main Menu")
                        {
                            mainButton1.interactable = true;
                        }
                    }
                }
            }
        }

        if(current >= 24)
        {
            mainButton1.interactable = true;
            mainButton2.interactable = true;
            mainButton3.interactable = true;
            mainButton4.interactable = true;
            mainButton5.interactable = true;
        }

    }
}
