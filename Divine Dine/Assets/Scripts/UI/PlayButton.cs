using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public GameObject button;

    private bool normal;
    private GameObject play;
    private GameObject ff;

    void Start ()
    {
        normal = true;
        play = button.transform.GetChild(0).gameObject;
        ff = button.transform.GetChild(2).gameObject;
    }

    public void Toggle()
    {
        if(normal)
        {
            Time.timeScale = 2;
            play.SetActive(false);
            ff.SetActive(true);
            normal = false;
        }
        else
        {
            Time.timeScale = 1;
            ff.SetActive(false);
            play.SetActive(true);
            normal = true;
        }
    }

    public void Reset ()
    {
        Time.timeScale = 1;
        ff.SetActive(false);
        play.SetActive(true);
        normal = true;

        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(() => GetComponent<MenuManagement>().ShowDayBar());
        button.GetComponent<Button>().onClick.AddListener(() => GetComponent<DayCycle>().Activate());
        button.GetComponent<Button>().onClick.AddListener(() => Begin());
    }

    public void Begin ()
    {
        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(() => Toggle());
    }
}
