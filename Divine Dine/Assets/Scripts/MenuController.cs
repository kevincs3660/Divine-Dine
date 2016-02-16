using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject menuScroller;

    private GameObject gameManager;

    private GameObject item1;
    private GameObject item2;
    private GameObject item3;
    private GameObject item4;
    private GameObject item1Button;
    private GameObject item2Button;
    private GameObject item3Button;
    private GameObject item4Button;
    private GameObject item1Text;
    private GameObject item2Text;
    private GameObject item3Text;
    private GameObject item4Text;

    private int startIndex;

    void Awake()
    {
        gameManager = GameObject.Find("Game Manager");

        item1 = menuScroller.transform.GetChild(2).gameObject;
        item2 = menuScroller.transform.GetChild(3).gameObject;
        item3 = menuScroller.transform.GetChild(4).gameObject;
        item4 = menuScroller.transform.GetChild(5).gameObject;
        item1Button = item1.transform.GetChild(0).gameObject;
        item2Button = item2.transform.GetChild(0).gameObject;
        item3Button = item3.transform.GetChild(0).gameObject;
        item4Button = item4.transform.GetChild(0).gameObject;
        item1Text = item1Button.transform.GetChild(0).gameObject;
        item2Text = item2Button.transform.GetChild(0).gameObject;
        item3Text = item3Button.transform.GetChild(0).gameObject;
        item4Text = item4Button.transform.GetChild(0).gameObject;
    }

    public void ShowHome()
    {
        ClearAll();
        mainMenu.SetActive(true);
    }

    public void ShowStore()
    {
        ClearAll();
        storeMenu.SetActive(true);
    }

    public void ShowItemStore()
    {
        ClearAll();
        menuScroller.SetActive(true);
        startIndex = 0;
        LoadItems(startIndex);
    }

    public void ShowFloorStore()
    {

    }

    public void ShowWallpaperStore()
    {

    }

    public void ShowManagement()
    {

    }

    public void ShowMenu()
    {

    }

    public void ShowMarket()
    {

    }

    public void ShowTrophies()
    {

    }

    public void PageNext()
    {
        if (gameManager.GetComponent<PlaceObject>().placeablePrefabs.Length > startIndex + 4)
        {
            startIndex += 4;
            LoadItems(startIndex);
        }
    }

    public void PageBack()
    {
        if(startIndex != 0)
        {
            startIndex -= 4;
            LoadItems(startIndex);
        }
    }

    private void LoadItems(int startingIndex)
    {
        if (gameManager.GetComponent<PlaceObject>().placeablePrefabs.Length > startingIndex + 0)
        {
            item1.SetActive(true);
            item1Text.GetComponent<Text>().text = gameManager.GetComponent<PlaceObject>().placeablePrefabs[startingIndex + 0].ToString().Replace(" (UnityEngine.GameObject)", "");
            item1Button.GetComponent<Button>().onClick.RemoveAllListeners();
            item1Button.GetComponent<Button>().onClick.AddListener(() => gameManager.GetComponent<PlaceObject>().ReadyObject(startingIndex + 0));
        }
        else
        {
            item1.SetActive(false);
        }
        if (gameManager.GetComponent<PlaceObject>().placeablePrefabs.Length > startingIndex + 1)
        {
            item2.SetActive(true);
            item2Text.GetComponent<Text>().text = gameManager.GetComponent<PlaceObject>().placeablePrefabs[startingIndex + 1].ToString().Replace(" (UnityEngine.GameObject)", "");
            item2Button.GetComponent<Button>().onClick.RemoveAllListeners();
            item2Button.GetComponent<Button>().onClick.AddListener(() => gameManager.GetComponent<PlaceObject>().ReadyObject(startingIndex + 1));
        }
        else
        {
            item2.SetActive(false);
        }
        if (gameManager.GetComponent<PlaceObject>().placeablePrefabs.Length > startingIndex + 2)
        {
            item3.SetActive(true);
            item3Text.GetComponent<Text>().text = gameManager.GetComponent<PlaceObject>().placeablePrefabs[startingIndex + 2].ToString().Replace(" (UnityEngine.GameObject)", "");
            item3Button.GetComponent<Button>().onClick.RemoveAllListeners();
            item3Button.GetComponent<Button>().onClick.AddListener(() => gameManager.GetComponent<PlaceObject>().ReadyObject(startingIndex + 2));
        }
        else
        {
            item3.SetActive(false);
        }
        if (gameManager.GetComponent<PlaceObject>().placeablePrefabs.Length > startingIndex + 3)
        {
            item4.SetActive(true);
            item4Text.GetComponent<Text>().text = gameManager.GetComponent<PlaceObject>().placeablePrefabs[startingIndex + 3].ToString().Replace(" (UnityEngine.GameObject)", "");
            item4Button.GetComponent<Button>().onClick.RemoveAllListeners();
            item4Button.GetComponent<Button>().onClick.AddListener(() => gameManager.GetComponent<PlaceObject>().ReadyObject(startingIndex + 3));
        }
        else
        {
            item4.SetActive(false);
        }
    }

    private void ClearAll()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(false);
        menuScroller.SetActive(false);
    }
}
