using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject[] tutorials;
    public GameObject bottomCanvas;
    public GameObject playButton;
    public GameObject cameraLock;
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
            mainButton1.onClick.AddListener(() => Next());
        }
        else if (current == 9)
        {
            mainButton1.interactable = false;
            mainButton2.interactable = false;
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
        if(current == 7)
        {
            GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
            foreach (GameObject table in tables)
            {
                table.GetComponent<TableScript>().Tutorial();
            }
            Next();
        }
    }
}
