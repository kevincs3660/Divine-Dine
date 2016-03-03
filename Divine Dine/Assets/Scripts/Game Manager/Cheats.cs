using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {

    private string cheat;
    private bool active = false;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            active = !active;
            GetComponent<MenuManagement>().ToggleCheatBox(active);
        }
    }

    public void BoxActive(bool value)
    {
        active = value;
    }

    public void CheckCheat()
    {
        cheat = GetComponent<MenuManagement>().GetCheat();
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
}
