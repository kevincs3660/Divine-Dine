using UnityEngine;
using System.Collections;

public class FoodVariables : MonoBehaviour
{
    public GameObject[] Ingredients;
    public GameObject[] Appetizers;
    public GameObject[] Entrees;
    public GameObject[] Desserts;
    private ArrayList SelectedAppetizers;
    private ArrayList SelectedEntrees;
    private ArrayList SelectedDesserts;
    private ArrayList AllSelectedRecipes;

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
        for(int i = 0; i < Ingredients.Length; i++)
        {
            if(Ingredients[i].GetComponent<Ingredient>().quatity > 0)
                myReturn.Add(Ingredients[i]);
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
}
