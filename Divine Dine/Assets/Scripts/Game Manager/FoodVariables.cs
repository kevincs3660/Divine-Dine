﻿using UnityEngine;
using System.Collections;

public class FoodVariables : MonoBehaviour
{
    public GameObject[] Appetizers;
    public GameObject[] Entrees;
    public GameObject[] Desserts;
    public int marketLevel = 0;
    public int baseSaleItems = 4;
    public int baseMarketItems = 4;
    public int baseRareItems = 4;
    public float saleMultiplier = 3;
    public float marketMultiplier = 2;
    public float rareMultiplier = 1;
    private ArrayList SelectedAppetizers = new ArrayList();
    private ArrayList SelectedEntrees = new ArrayList();
    private ArrayList SelectedDesserts = new ArrayList();
    private ArrayList AllSelectedRecipes = new ArrayList();
    private ArrayList AllIngredients = new ArrayList();
    private ArrayList MarketList = new ArrayList();
    private ArrayList SaleItems;
    private ArrayList MarketItems;
    private ArrayList RareItems;
    private int actualSaleItems;
    private int actualMarketItems;
    private int actualRareItems;

    void Awake()
    {
        //Reset All Variables
        for (int i = 0; i < Appetizers.Length; i++)
        {
            Appetizers[i].GetComponent<Food>().level = 0;
            ExtractIngredients(Appetizers[i]);
        }
        for (int i = 0; i < Entrees.Length; i++)
        {
            Entrees[i].GetComponent<Food>().level = 0;
            ExtractIngredients(Entrees[i]);
        }
        for (int i = 0; i < Desserts.Length; i++)
        {
            Desserts[i].GetComponent<Food>().level = 0;
            ExtractIngredients(Desserts[i]);
        }


        for (int i = 0; i < AllIngredients.Count; i++)
        {
            GameObject temp = (GameObject)AllIngredients[i];
            temp.GetComponent<Ingredient>().quatity = 0;
        }
    }

    public void SelectFood(GameObject food)
    {
        if (food.GetComponent<Food>().type == "Appetizer")
            SelectedAppetizers.Add(food);
        else if (food.GetComponent<Food>().type == "Entree")
            SelectedEntrees.Add(food);
        else if (food.GetComponent<Food>().type == "Dessert")
            SelectedDesserts.Add(food);
        AllSelectedRecipes.Add(food);
    }

    public void RemoveSelectedFood(GameObject food)
    {
        if (food.GetComponent<Food>().type == "Appetizer")
            SelectedAppetizers.Remove(food);
        else if (food.GetComponent<Food>().type == "Entree")
            SelectedEntrees.Remove(food);
        else if (food.GetComponent<Food>().type == "Dessert")
            SelectedDesserts.Remove(food);
        AllSelectedRecipes.Remove(food);
    }

    public ArrayList MyIngredients ()
    {
        ArrayList myReturn = new ArrayList();
        for (int i = 0; i < AllIngredients.Count; i++)
        {
            GameObject temp = (GameObject)AllIngredients[i];
            if (temp.GetComponent<Ingredient>().quatity > 0)
                myReturn.Add(temp);
        }
        return myReturn;
    }

    public ArrayList GetAppetizers()
    {
        return SelectedAppetizers;
    }

    public ArrayList GetEntrees()
    {
        return SelectedEntrees;
    }

    public ArrayList GetDesserts()
    {
        return SelectedDesserts;
    }

    public ArrayList GetAllSelectedRecipes()
    {
        return AllSelectedRecipes;
    }

    public ArrayList GetMarketList()
    {
        return MarketList;
    }
  
    public ArrayList GetSaleItems()
    {
        return SaleItems;
    }

    public ArrayList GetMarketItems()
    {
        return MarketItems;
    }

    public ArrayList GetRareItems()
    {
        return RareItems;
    }

    public void CalculateMarket()
    {
        SaleItems = new ArrayList();
        MarketItems = new ArrayList();
        RareItems = new ArrayList();

        int remainder = MarketList.Count;
        actualSaleItems = baseSaleItems + (int)(marketLevel / saleMultiplier);
        actualMarketItems = baseMarketItems + (int)(marketLevel / marketMultiplier);
        actualRareItems = baseMarketItems + (int)(marketLevel / rareMultiplier);

        actualSaleItems = Mathf.Min(remainder, actualSaleItems);
        remainder -= actualSaleItems;
        actualMarketItems = Mathf.Min(remainder, actualMarketItems);
        remainder -= actualMarketItems;
        actualRareItems = Mathf.Min(remainder, actualRareItems);
        remainder -= actualRareItems;

        for(int i = 0; i < actualSaleItems; i++)
        {
            SaleItems.Add(MarketList[Random.Range(0, MarketList.Count)]);
        }
        for(int i = 0; i < actualMarketItems; i++)
        {
            MarketItems.Add(MarketList[Random.Range(0, MarketList.Count)]);
        }
        for(int i = 0; i < actualRareItems; i++)
        {
            RareItems.Add(MarketList[Random.Range(0, MarketList.Count)]);
        }
    }

    public void OneOfEverything()
    {
        for (int i = 0; i < AllIngredients.Count; i++)
        {
            GameObject temp = (GameObject)AllIngredients[i];
            temp.GetComponent<Ingredient>().quatity++;
        }
    }

    private void ExtractIngredients(GameObject food)
    {
        for(int i = 0; i < food.GetComponent<Food>().recipe.Length; i++)
        {
            if (!AllIngredients.Contains(food.GetComponent<Food>().recipe[i]))
            {
                AllIngredients.Add(food.GetComponent<Food>().recipe[i]);
                for(int j = 0; j < food.GetComponent<Food>().recipe[i].GetComponent<Ingredient>().rarity; j++)
                {
                    MarketList.Add(food.GetComponent<Food>().recipe[i]);
                }
            }
        }
    }
}
