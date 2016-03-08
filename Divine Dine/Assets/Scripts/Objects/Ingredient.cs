using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{
    public Sprite image;
    public int quatity;
    public int rarity;
    public int marketPrice;

    public int GetSalePrice()
    {
        return (int)(marketPrice / 2);
    }
    public int GetRarePrice()
    {
        return (marketPrice * 2);
    }
}
