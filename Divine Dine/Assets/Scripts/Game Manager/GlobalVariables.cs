using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

    public int money;
    public int experience;
    public float gameSpeed;

    public GameObject experienceMeter;
    public GameObject levelText;
    public GameObject moneyText;

    private int currentLevel;
    private int nextLevelXP;
    private int baseXP;

    void Awake ()
    {
        Startup();
    }

    public void Startup()
    {
        AddMoney(0);
        CalculateLevel();
        AddExperience(0);
    }

    public void CalculateLevel()
    {
        currentLevel = 1;
        nextLevelXP = 25;
        baseXP  = 0;

        while (experience >= nextLevelXP)
        {
            currentLevel++;
            baseXP = nextLevelXP;
            nextLevelXP = nextLevelXP+(25*currentLevel);
        }
        levelText.GetComponent<Text>().text = "Level " + currentLevel;
    }

    public float GetLevelPercentage()
    {
        float current = experience - baseXP;
        float roof = nextLevelXP - baseXP;
        return (current / roof);
    }

    public void AdvanceToNextLevel()
    {
        int roof = nextLevelXP - baseXP;
        AddExperience(roof);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.GetComponent<Text>().text = "$" + money;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if(experience >= nextLevelXP)
        {
            //Level Up
            CalculateLevel();
            levelText.GetComponent<Text>().text = "Level " + currentLevel;

        }
        experienceMeter.GetComponent<RectTransform>().anchorMax = new Vector2(GetLevelPercentage(), 1);
    }

    public int CurrentLevel()
    {
        return currentLevel;
    }
}
