using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{
    public Sprite image;
    public int quatity;         //How many the player owns
    public int rarity;          //How likely it is to appear in the market
    public int marketPrice;     //Base price item sells for in market

    public int GetSalePrice()
    {
        return (int)(marketPrice / 2);
    }
    public int GetRarePrice()
    {
        return (marketPrice * 2);
    }
}
