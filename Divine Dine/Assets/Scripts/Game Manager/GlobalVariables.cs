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
        nextLevelXP = 250;
        baseXP  = 0;

        while (experience > nextLevelXP)
        {
            baseXP = nextLevelXP;
            nextLevelXP = nextLevelXP*2;
            nextLevelXP = (int)(nextLevelXP * 1.1);
            currentLevel++;
        }
        levelText.GetComponent<Text>().text = "Level " + currentLevel;
    }

    public float GetLevelPercentage()
    {
        float current = experience - baseXP;
        float roof = nextLevelXP - baseXP;
        return (current / roof);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.GetComponent<Text>().text = "$" + money;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if(experience > nextLevelXP)
        {
            //Level Up
            CalculateLevel();
            levelText.GetComponent<Text>().text = "Level " + currentLevel;

            //Check to see if the plot can expand
            GameObject[] allGrass = GameObject.FindGameObjectsWithTag("Grass");
            for(int i = 0; i < allGrass.Length; i++)
            {
                allGrass[i].GetComponent<LevelHiding>().Check();
            }
        }
        experienceMeter.GetComponent<RectTransform>().anchorMax = new Vector2(GetLevelPercentage(), 1);
    }

    public int CurrentLevel()
    {
        return currentLevel;
    }
}
