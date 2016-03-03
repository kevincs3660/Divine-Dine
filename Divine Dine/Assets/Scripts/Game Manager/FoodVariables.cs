using UnityEngine;
using System.Collections;

public class FoodVariables : MonoBehaviour
{
    public GameObject[] Appetizers;
    public GameObject[] Entrees;
    public GameObject[] Desserts;
    private ArrayList SelectedAppetizers = new ArrayList();
    private ArrayList SelectedEntrees = new ArrayList();
    private ArrayList SelectedDesserts = new ArrayList();
    private ArrayList AllSelectedRecipes = new ArrayList();
    private ArrayList AllIngredients = new ArrayList();

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

        IEnumerator list = AllIngredients.GetEnumerator();
        list.Reset();
        for (int i = 0; i < AllIngredients.Count; i++)
        {
            list.MoveNext();
            GameObject temp = (GameObject)list.Current;
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
        IEnumerator list = AllIngredients.GetEnumerator();
        list.Reset();
        for (int i = 0; i < AllIngredients.Count; i++)
        {
            list.MoveNext();
            GameObject temp = (GameObject)list.Current;
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

    public void OneOfEverything()
    {
        IEnumerator list = AllIngredients.GetEnumerator();
        list.Reset();
        for (int i = 0; i < AllIngredients.Count; i++)
        {
            list.MoveNext();
            GameObject temp = (GameObject)list.Current;
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
            }
        }
    }
}
