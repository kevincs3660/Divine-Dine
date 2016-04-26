using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    GameObject[] tutorials;
    GameObject bottomCanvas;
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

    }
}
