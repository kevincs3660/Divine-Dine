using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

    public GameObject menu;
    private bool active;

    void Start ()
    {
        active = false;
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toggle();
        }
	
	}

    public void Exit ()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void toggle()
    {
        if (active)
        {
            active = false;
            menu.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            active = true;
            menu.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
