using UnityEngine;
using System.Collections;

public class FoodVariables : MonoBehaviour
{
    public GameObject[] Appetizers;
    public GameObject[] Entrees;
    public GameObject[] Desserts;
    public GameObject starterAppetizer;
    public GameObject starterEntree;
    public GameObject defaultModel;
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
    private ArrayList UnstockedItems = new ArrayList();
    private ArrayList SaleItems;
    private ArrayList MarketItems;
    private ArrayList RareItems;
    private int actualSaleItems;
    private int actualMarketItems;
    private int actualRareItems;
    private int marketXP = 0;
    private int marketScaler = 25;
    private int marketThreshold = 25;
    private int marketTarget = 25;
    private float saleIP = 0.05f;       //Food price calculation based on ingredient cost
    private float saleLP = 0.1f;        //Food price calculation based on dish level

    void Awake()
    {
        //Reset All Variables
        for (int i = 0; i < Appetizers.Length; i++)
        {
            Appetizers[i].GetComponent<Food>().level = 0;
            ExtractIngredients(Appetizers[i]);
            if(Appetizers[i].GetComponent<Food>().model == null)
            {
                Appetizers[i].GetComponent<Food>().model = defaultModel;
            }
        }
        for (int i = 0; i < Entrees.Length; i++)
        {
            Entrees[i].GetComponent<Food>().level = 0;
            ExtractIngredients(Entrees[i]);
            if (Entrees[i].GetComponent<Food>().model == null)
            {
                Entrees[i].GetComponent<Food>().model = defaultModel;
            }
        }
        for (int i = 0; i < Desserts.Length; i++)
        {
            Desserts[i].GetComponent<Food>().level = 0;
            ExtractIngredients(Desserts[i]);
            if (Desserts[i].GetComponent<Food>().model == null)
            {
                Desserts[i].GetComponent<Food>().model = defaultModel;
            }
        }


        for (int i = 0; i < AllIngredients.Count; i++)
        {
            GameObject temp = (GameObject)AllIngredients[i];
            temp.GetComponent<Ingredient>().quatity = 0;
        }

        //Starter Dishes
        starterAppetizer.GetComponent<Food>().level = 1;
        starterEntree.GetComponent<Food>().level = 1;
        SelectFood(starterAppetizer);
        SelectFood(starterEntree);

        //First market roll
        CalculateMarket();

    }

    public void SelectFood(GameObject food)
    {
        if (food.GetComponent<Food>().type == "Appetizer")
        {
            SelectedAppetizers.Add(food);
        }
        else if (food.GetComponent<Food>().type == "Entree")
        {
            SelectedEntrees.Add(food);
        }
        else if (food.GetComponent<Food>().type == "Dessert")
        {
            SelectedDesserts.Add(food);
        }
        else
            Debug.Log("Labeled Incorrectly");
        AllSelectedRecipes.Add(food);
    }

    public void RemoveSelectedFood(GameObject food)
    {
        if (food.GetComponent<Food>().type == "Appetizer")
        {
            SelectedAppetizers.Remove(food);
        }
        else if (food.GetComponent<Food>().type == "Entree")
        {
            SelectedEntrees.Remove(food);
        }
        else if (food.GetComponent<Food>().type == "Dessert")
        {
            SelectedDesserts.Remove(food);
        }
        else
            Debug.Log("Labeled Incorrectly");
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

    public void CalculateMarket()
    {
        SaleItems = new ArrayList();
        MarketItems = new ArrayList();
        RareItems = new ArrayList();
        UnstockedItems = new ArrayList(AllIngredients);

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
            //Sale Items
            var ingredient = MarketList[Random.Range(0, MarketList.Count)];
            if (!SaleItems.Contains(ingredient))
            {
                SaleItems.Add(ingredient);
                UnstockedItems.Remove(ingredient);
            }
            else
                i--;
        }
        for(int i = 0; i < actualMarketItems; i++)
        {
            //Market Items
            var ingredient = MarketList[Random.Range(0, MarketList.Count)];
            if (!SaleItems.Contains(ingredient) && !MarketItems.Contains(ingredient))
            {
                MarketItems.Add(ingredient);
                UnstockedItems.Remove(ingredient);
            }
            else
                i--;
        }
        for(int i = 0; i < actualRareItems; i++)
        {
            //Rare Items
            var ingredient = MarketList[Random.Range(0, MarketList.Count)];
            if (!SaleItems.Contains(ingredient) && !MarketItems.Contains(ingredient) && !RareItems.Contains(ingredient))
            {
                RareItems.Add(ingredient);
                UnstockedItems.Remove(ingredient);
            }
            else
                i--;
        }
    }

    public void AddMarketPoint(int n)
    {
        marketXP += n;
        checkMarketLevel();
    }

    public void calculatePrice(Food food)
    {
        float cost = 0f;
        foreach(GameObject r in food.recipe)
        {
            cost += r.GetComponent<Ingredient>().marketPrice * saleIP;
        }
        cost *= (food.level * saleLP);
        if(food.isHealthy)
        {
            food.sellPrice = (int)(cost/2);
        }
        else
        {
            food.sellPrice = (int)cost;
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
                for (int j = 0; j < food.GetComponent<Food>().recipe[i].GetComponent<Ingredient>().rarity; j++)
                {
                    MarketList.Add(food.GetComponent<Food>().recipe[i]);
                }
            }
        }
    }

    private void checkMarketLevel()
    {
        while(marketTarget <= marketXP)
        {
            marketLevel++;
            marketTarget += marketThreshold;
            marketThreshold += marketScaler;
        }
    }

    public ArrayList GetMyIngredients()
    {
        ArrayList myReturn = new ArrayList();
        for(int i = 0; i < AllIngredients.Count; i++)
        {
            GameObject ingredient = (GameObject)AllIngredients[i];
            if(ingredient.GetComponent<Ingredient>().quatity > 0)
            {
                myReturn.Add(ingredient);
            }
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

    public ArrayList GetAllIngredients()
    {
        return AllIngredients;
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

    public ArrayList GetUnstockedItems()
    {
        return UnstockedItems;
    }

    public int GetMarketLevel()
    {
        return (marketLevel + 1);
    }
}
