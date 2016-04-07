using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cheats : MonoBehaviour {

    public GameObject cheatBox;

    private Text cheatText;
    private string cheat;
    private bool active = false;

    void Start()
    {
        cheatText = cheatBox.transform.GetChild(1).GetComponent<Text>();
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            active = !active;
            ToggleCheatBox(active);
        }
    }

    public void BoxActive(bool value)
    {
        active = value;
    }

    public void CheckCheat()
    {
        cheat = cheatText.text;
        cheat = cheat.ToUpper();
        if (cheat == "GOLDEN APPLES")
        {
            GetComponent<GlobalVariables>().AddMoney(5000);
        }
        else if (cheat == "DIVINITY")
        {
            GetComponent<GlobalVariables>().AdvanceToNextLevel();
        }
        else if (cheat == "I'LL TAKE ONE OF EVERYTHING")
        {
            GetComponent<FoodVariables>().OneOfEverything();
        }
    }

    public void ToggleCheatBox(bool value)
    {
        cheatBox.GetComponent<InputField>().text = "";
        cheatBox.SetActive(value);
    }
}
