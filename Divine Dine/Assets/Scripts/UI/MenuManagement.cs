using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManagement : MonoBehaviour
{
    public GameObject mainCanvas;

    private GameObject mainMenu;
    private GameObject shopScroll;
    private GameObject menuScroll;
    private GameObject addMenu;

    //Main Menu
    private GameObject main1;
    private GameObject main2;
    private GameObject main3;
    private GameObject main4;
    private GameObject main5;
    private Button mainButton1;
    private Button mainButton2;
    private Button mainButton3;
    private Button mainButton4;
    private Button mainButton5;
    private Text mainText1;
    private Text mainText2;
    private Text mainText3;
    private Text mainText4;
    private Text mainText5;

    //Shop Scroll
    private GameObject home;
    private Button homeButton;
    private Text homeText;
    private Button shopBack;
    private Button shopNext;
    private GameObject s_scroll1;
    private GameObject s_scroll2;
    private GameObject s_scroll3;
    private GameObject s_scroll4;
    private Button s_button1;
    private Button s_button2;
    private Button s_button3;
    private Button s_button4;
    private Text s_text1;
    private Text s_text2;
    private Text s_text3;
    private Text s_text4;

    //Menu Scroll
    private Button menuBack;
    private Button menuNext;
    private GameObject m_scroll1;
    private GameObject m_scroll2;
    private GameObject m_scroll3;
    private GameObject m_scroll4;
    private GameObject m_image1;
    private GameObject m_image2;
    private GameObject m_image3;
    private GameObject m_image4;
    private Button m_button1;
    private Button m_button2;
    private Button m_button3;
    private Button m_button4;
    private Text m_text1;
    private Text m_text2;
    private Text m_text3;
    private Text m_text4;

    //Add Menu
    private Button addButton1;
    private Button addButton2;
    private Button addButton3;
    private Button addButton4;

    //Programming Objects
    private int shopScrollIndex;
    private int menuScrollIndex;
    private string MenuType;

    void Awake()
    {
        mainMenu = mainCanvas.transform.GetChild(0).gameObject;
        shopScroll = mainCanvas.transform.GetChild(1).gameObject;
        menuScroll = mainCanvas.transform.GetChild(2).gameObject;
        addMenu = mainCanvas.transform.GetChild(3).gameObject;

        //Main Menu
        main1 = mainMenu.transform.GetChild(0).gameObject;
        main2 = mainMenu.transform.GetChild(1).gameObject;
        main3 = mainMenu.transform.GetChild(2).gameObject;
        main4 = mainMenu.transform.GetChild(3).gameObject;
        main5 = mainMenu.transform.GetChild(4).gameObject;
        mainButton1 = main1.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton2 = main2.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton3 = main3.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton4 = main4.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton5 = main5.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainText1 = main1.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText2 = main2.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText3 = main3.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText4 = main4.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText5 = main5.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        //Shop Scroll
        home = shopScroll.transform.GetChild(0).gameObject;
        homeButton = home.transform.GetChild(0).gameObject.GetComponent<Button>();
        homeText = home.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        shopBack = shopScroll.transform.GetChild(1).gameObject.GetComponent<Button>();
        shopNext = shopScroll.transform.GetChild(2).gameObject.GetComponent<Button>();
        s_scroll1 = shopScroll.transform.GetChild(3).gameObject;
        s_scroll2 = shopScroll.transform.GetChild(4).gameObject;
        s_scroll3 = shopScroll.transform.GetChild(5).gameObject;
        s_scroll4 = shopScroll.transform.GetChild(6).gameObject;
        s_button1 = s_scroll1.transform.GetChild(0).gameObject.GetComponent<Button>();
        s_button2 = s_scroll2.transform.GetChild(0).gameObject.GetComponent<Button>();
        s_button3 = s_scroll3.transform.GetChild(0).gameObject.GetComponent<Button>();
        s_button4 = s_scroll4.transform.GetChild(0).gameObject.GetComponent<Button>();
        s_text1 = s_scroll1.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        s_text2 = s_scroll2.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        s_text3 = s_scroll3.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        s_text4 = s_scroll4.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        //Menu Scroll
        menuBack = menuScroll.transform.GetChild(0).gameObject.GetComponent<Button>();
        menuNext = menuScroll.transform.GetChild(1).gameObject.GetComponent<Button>();
        m_scroll1 = menuScroll.transform.GetChild(2).gameObject;
        m_scroll2 = menuScroll.transform.GetChild(3).gameObject;
        m_scroll3 = menuScroll.transform.GetChild(4).gameObject;
        m_scroll4 = menuScroll.transform.GetChild(5).gameObject;
        m_image1 = m_scroll1.transform.GetChild(0).gameObject;
        m_image2 = m_scroll2.transform.GetChild(0).gameObject;
        m_image3 = m_scroll3.transform.GetChild(0).gameObject;
        m_image4 = m_scroll4.transform.GetChild(0).gameObject;
        m_button1 = m_scroll1.transform.GetChild(1).gameObject.GetComponent<Button>();
        m_button2 = m_scroll2.transform.GetChild(1).gameObject.GetComponent<Button>();
        m_button3 = m_scroll3.transform.GetChild(1).gameObject.GetComponent<Button>();
        m_button4 = m_scroll4.transform.GetChild(1).gameObject.GetComponent<Button>();
        m_text1 = m_scroll1.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text2 = m_scroll2.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text3 = m_scroll3.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text4 = m_scroll4.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        //Add Menu
        addButton1 = addMenu.transform.GetChild(0).GetComponent<Button>();
        addButton2 = addMenu.transform.GetChild(1).GetComponent<Button>();
        addButton3 = addMenu.transform.GetChild(2).GetComponent<Button>();
        addButton4 = addMenu.transform.GetChild(3).GetComponent<Button>();

        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        ClearAll();
        MenuType = "Main Menu";

        ResetAllPanelsMainMenu();
        mainText1.text = "Menu";
        mainText2.text = "Store";
        mainText3.text = "Management";
        mainText4.text = "Market";
        mainText5.text = "Trophies";

        ClearButtonsMainMenu();
        mainButton1.onClick.AddListener(() => ShowMenuCustomization());
        mainButton2.onClick.AddListener(() => ShowStoreMenu());
        mainButton3.onClick.AddListener(() => ShowManagement());
        mainButton4.onClick.AddListener(() => ShowMarket());
        mainButton5.onClick.AddListener(() => ShowTrophies());

        mainMenu.SetActive(true);
    }

    public void ShowMenuCustomization()
    {
        ClearAll();

        ResetAllPanelsMainMenu();
        mainText1.text = "Back";
        mainText2.text = "Ingredients";
        mainText3.text = "Appetizers";
        mainText4.text = "Entrees";
        mainText5.text = "Desserts";

        ClearButtonsMainMenu();
        mainButton1.onClick.AddListener(() => ShowMainMenu());
        mainButton2.onClick.AddListener(() => LoadIngredients(0));
        mainButton3.onClick.AddListener(() => LoadAppetizers(0));
        mainButton4.onClick.AddListener(() => LoadEntrees(0));
        mainButton5.onClick.AddListener(() => LoadDesserts(0));

        mainMenu.SetActive(true);
    }

    public void ShowStoreMenu()
    {
        ClearAll();
        MenuType = "Store Menu";

        ResetAllPanelsMainMenu();
        mainText1.text = "Back";
        mainText2.text = "Item Shop";
        mainText3.text = "Floor Shop";
        mainText4.text = "Wallpaper Shop";
        main5.SetActive(false);

        ClearButtonsMainMenu();
        mainButton1.onClick.AddListener(() => ShowMainMenu());
        mainButton2.onClick.AddListener(() => ShowItemStore());
        mainButton3.onClick.AddListener(() => ShowFlooringStore());
        mainButton4.onClick.AddListener(() => ShowWallpaperStore());

        mainMenu.SetActive(true);
    }

    public void ShowManagement()
    {
        //ClearAll();
    }

    public void ShowMarket()
    {
        //ClearAll();
    }

    public void ShowTrophies()
    {
        //ClearAll();
    }

    public void ShowItemStore()
    {
        ClearAll();
        MenuType = "Items";

        homeText.text = "Back";
        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(() => ShowStoreMenu());
        homeButton.onClick.AddListener(() => GetComponent<PlaceObject>().SetReplace(false));

        shopScrollIndex = 0;
        LoadItems(shopScrollIndex);
        GetComponent<PlaceObject>().SetReplace(true);

        shopScroll.SetActive(true);
    }

    public void ShowFlooringStore()
    {
        ClearAll();
        MenuType = "Flooring";

        homeText.text = "Back";
        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(() => ShowStoreMenu());

        shopScrollIndex = 0;
        LoadFlooring(shopScrollIndex);

        shopScroll.SetActive(true);
    }

    public void ShowWallpaperStore()
    {
        ClearAll();
        MenuType = "Wallpaper";

        homeText.text = "Back";
        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(() => ShowStoreMenu());

        shopScrollIndex = 0;
        LoadWallpaper(shopScrollIndex);

        shopScroll.SetActive(true);
    }

    public void LoadIngredients(int index)
    {
        MenuType = "Ingredients";
        if(GetComponent<FoodVariables>().Ingredients.Length > index + 0)
        {
            
        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Ingredients.Length > index + 1)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Ingredients.Length > index + 2)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Ingredients.Length > index + 3)
        {

        }
        else
        {

        }
    }

    public void LoadAppetizers(int index)
    {
        MenuType = "Appetizers";
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 0)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 1)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 2)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 3)
        {

        }
        else
        {

        }
    }

    public void LoadEntrees(int index)
    {
        MenuType = "Entrees";
        if (GetComponent<FoodVariables>().Entrees.Length > index + 0)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 1)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 2)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 3)
        {

        }
        else
        {

        }
    }

    public void LoadDesserts(int index)
    {
        MenuType = "Desserts";
        if (GetComponent<FoodVariables>().Desserts.Length > index + 0)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 1)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 2)
        {

        }
        else
        {

        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 3)
        {

        }
        else
        {

        }
    }

    public void LoadItems(int index)
    {
        if(GetComponent<PlaceObject>().placeablePrefabs.Length > index + 0)
        {
            s_text1.text = GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 0].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text1.text += "\n$" + GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 0].GetComponent<PlaceableObject>().cashValue.ToString();

            s_button1.onClick.RemoveAllListeners();
            s_button1.onClick.AddListener(() => GetComponent<PlaceObject>().ReadyObject(shopScrollIndex + 0));

            s_scroll1.SetActive(true);
        }
        else
        {
            s_scroll1.SetActive(false);
        }
        if (GetComponent<PlaceObject>().placeablePrefabs.Length > index + 1)
        {
            s_text2.text = GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 1].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text2.text += "\n$" + GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 1].GetComponent<PlaceableObject>().cashValue.ToString();

            s_button2.onClick.RemoveAllListeners();
            s_button2.onClick.AddListener(() => GetComponent<PlaceObject>().ReadyObject(shopScrollIndex + 1));

            s_scroll2.SetActive(true);
        }
        else
        {
            s_scroll2.SetActive(false);
        }
        if (GetComponent<PlaceObject>().placeablePrefabs.Length > index + 2)
        {
            s_text3.text = GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 2].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text3.text += "\n$" + GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 2].GetComponent<PlaceableObject>().cashValue.ToString();

            s_button3.onClick.RemoveAllListeners();
            s_button3.onClick.AddListener(() => GetComponent<PlaceObject>().ReadyObject(shopScrollIndex + 2));

            s_scroll3.SetActive(true);
        }
        else
        {
            s_scroll3.SetActive(false);
        }
        if (GetComponent<PlaceObject>().placeablePrefabs.Length > index + 3)
        {
            s_text4.text = GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 3].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text4.text += "\n$" + GetComponent<PlaceObject>().placeablePrefabs[shopScrollIndex + 3].GetComponent<PlaceableObject>().cashValue.ToString();

            s_button4.onClick.RemoveAllListeners();
            s_button4.onClick.AddListener(() => GetComponent<PlaceObject>().ReadyObject(shopScrollIndex + 3));

            s_scroll4.SetActive(true);
        }
        else
        {
            s_scroll4.SetActive(false);
        }
    }

    public void LoadFlooring(int index)
    {
        if (GetComponent<PlaceMaterial>().textures.Length > index + 0)
        {
            s_text1.text = GetComponent<PlaceMaterial>().textures[shopScrollIndex + 0].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text1.text += "\n$" + GetComponent<PlaceMaterial>().textures[shopScrollIndex + 0].GetComponent<PlaceableMaterial>().cashValue.ToString();

            s_button1.onClick.RemoveAllListeners();
            s_button1.onClick.AddListener(() => GetComponent<PlaceMaterial>().ReadyMaterial(shopScrollIndex + 0));

            s_scroll1.SetActive(true);
        }
        else
        {
            s_scroll1.SetActive(false);
        }
        if (GetComponent<PlaceMaterial>().textures.Length > index + 1)
        {
            s_text2.text = GetComponent<PlaceMaterial>().textures[shopScrollIndex + 1].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text2.text += "\n$" + GetComponent<PlaceMaterial>().textures[shopScrollIndex + 1].GetComponent<PlaceableMaterial>().cashValue.ToString();

            s_button2.onClick.RemoveAllListeners();
            s_button2.onClick.AddListener(() => GetComponent<PlaceMaterial>().ReadyMaterial(shopScrollIndex + 1));

            s_scroll2.SetActive(true);
        }
        else
        {
            s_scroll2.SetActive(false);
        }
        if (GetComponent<PlaceMaterial>().textures.Length > index + 2)
        {
            s_text3.text = GetComponent<PlaceMaterial>().textures[shopScrollIndex + 2].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text3.text += "\n$" + GetComponent<PlaceMaterial>().textures[shopScrollIndex + 2].GetComponent<PlaceableMaterial>().cashValue.ToString();

            s_button3.onClick.RemoveAllListeners();
            s_button3.onClick.AddListener(() => GetComponent<PlaceMaterial>().ReadyMaterial(shopScrollIndex + 2));

            s_scroll3.SetActive(true);
        }
        else
        {
            s_scroll3.SetActive(false);
        }
        if (GetComponent<PlaceMaterial>().textures.Length > index + 3)
        {
            s_text4.text = GetComponent<PlaceMaterial>().textures[shopScrollIndex + 3].ToString().Replace(" (UnityEngine.GameObject)", "");
            s_text4.text += "\n$" + GetComponent<PlaceMaterial>().textures[shopScrollIndex + 3].GetComponent<PlaceableMaterial>().cashValue.ToString();

            s_button4.onClick.RemoveAllListeners();
            s_button4.onClick.AddListener(() => GetComponent<PlaceMaterial>().ReadyMaterial(shopScrollIndex + 3));

            s_scroll4.SetActive(true);
        }
        else
        {
            s_scroll4.SetActive(false);
        }
    }

    public void LoadWallpaper(int index)
    {
        if (GetComponent<PlaceWallpaper>().textures.Length > index + 0)
        {

        }
        else
        {

        }
        if (GetComponent<PlaceWallpaper>().textures.Length > index + 1)
        {

        }
        else
        {

        }
        if (GetComponent<PlaceWallpaper>().textures.Length > index + 2)
        {

        }
        else
        {

        }
        if (GetComponent<PlaceWallpaper>().textures.Length > index + 3)
        {

        }
        else
        {

        }
    }

    public void MenuScrollNext()
    {
        if(MenuType == "Ingredients")
        {
            if(GetComponent<FoodVariables>().Ingredients.Length > menuScrollIndex + 4)
            {
                menuScrollIndex += 4;
                LoadIngredients(menuScrollIndex);
            }
        }
        else if(MenuType == "Appetizers")
        {
            if (GetComponent<FoodVariables>().Appetizers.Length > menuScrollIndex + 4)
            {
                menuScrollIndex += 4;
                LoadAppetizers(menuScrollIndex);
            }
        }
        else if (MenuType == "Entrees")
        {
            if (GetComponent<FoodVariables>().Entrees.Length > menuScrollIndex + 4)
            {
                menuScrollIndex += 4;
                LoadEntrees(menuScrollIndex);
            }
        }
        else if (MenuType == "Desserts")
        {
            if (GetComponent<FoodVariables>().Desserts.Length > menuScrollIndex + 4)
            {
                menuScrollIndex += 4;
                LoadDesserts(menuScrollIndex);
            }
        }
    }

    public void MenuScrollBack()
    {
        if (MenuType == "Ingredients")
        {
            if(menuScrollIndex - 4 >= 0)
            {
                menuScrollIndex -= 4;
                LoadIngredients(menuScrollIndex);
            }
        }
        else if (MenuType == "Appetizers")
        {
            if (menuScrollIndex - 4 >= 0)
            {
                menuScrollIndex -= 4;
                LoadAppetizers(menuScrollIndex);
            }
        }
        else if (MenuType == "Entrees")
        {
            if (menuScrollIndex - 4 >= 0)
            {
                menuScrollIndex -= 4;
                LoadEntrees(menuScrollIndex);
            }
        }
        else if (MenuType == "Desserts")
        {
            if (menuScrollIndex - 4 >= 0)
            {
                menuScrollIndex -= 4;
                LoadDesserts(menuScrollIndex);
            }
        }
    }

    private void ClearAll()
    {
        mainMenu.SetActive(false);
        shopScroll.SetActive(false);
        menuScroll.SetActive(false);
        addMenu.SetActive(false);
    }

    private void ClearButtonsMainMenu()
    {
        mainButton1.onClick.RemoveAllListeners();
        mainButton2.onClick.RemoveAllListeners();
        mainButton3.onClick.RemoveAllListeners();
        mainButton4.onClick.RemoveAllListeners();
        mainButton5.onClick.RemoveAllListeners();
    }

    private void ClearButtonsShopScroll()
    {
        homeButton.onClick.RemoveAllListeners();
        s_button1.onClick.RemoveAllListeners();
        s_button2.onClick.RemoveAllListeners();
        s_button3.onClick.RemoveAllListeners();
        s_button4.onClick.RemoveAllListeners();
    }

    private void ClearButtonsMenuScroll()
    {
        m_button1.onClick.RemoveAllListeners();
        m_button2.onClick.RemoveAllListeners();
        m_button3.onClick.RemoveAllListeners();
        m_button4.onClick.RemoveAllListeners();
    }

    private void ResetAllPanelsMainMenu()
    {
        main1.SetActive(true);
        main2.SetActive(true);
        main3.SetActive(true);
        main4.SetActive(true);
        main5.SetActive(true);
    }
}
