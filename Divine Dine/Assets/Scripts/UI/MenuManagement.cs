using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuManagement : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject gameCamera;
    public Color faded;

    private string Message = "";

    //All Menus
    private GameObject mainMenu;
    private GameObject shopScroll;
    private GameObject menuScroll;
    private GameObject marketScroll;
    private GameObject foodSelection;
    private GameObject ingredientScroll;
    private GameObject middleBar;

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
    private GameObject recipe1;
    private GameObject recipe2;
    private GameObject recipe3;
    private GameObject recipe4;
    private GameObject ingredient1_1;
    private GameObject ingredient1_2;
    private GameObject ingredient1_3;
    private GameObject ingredient1_4;
    private GameObject ingredient2_1;
    private GameObject ingredient2_2;
    private GameObject ingredient2_3;
    private GameObject ingredient2_4;
    private GameObject ingredient3_1;
    private GameObject ingredient3_2;
    private GameObject ingredient3_3;
    private GameObject ingredient3_4;
    private GameObject ingredient4_1;
    private GameObject ingredient4_2;
    private GameObject ingredient4_3;
    private GameObject ingredient4_4;
    private Text m_text1;
    private Text m_text2;
    private Text m_text3;
    private Text m_text4;

    //Market Menu

    //Food Selection
    private Button f_close;
    private Text f_desc;
    private Sprite f_image;
    private GameObject f_ingredient1;
    private GameObject f_ingredient2;
    private GameObject f_ingredient3;
    private GameObject f_ingredient4;
    private Button f_level_button;
    private Button f_select_button;
    private Button f_price_button;
    private Button f_yes_button;
    private Button f_no_button;
    private Text f_level_text;
    private Text f_select_text;
    private Text f_health_text;
    private GameObject f_button_panel1;
    private GameObject f_button_panel2;

    //Ingredient Scroll

    //Middle Bar
    private GameObject cheatBox;
    private Text cheatText;
    private Text cameraText;

    //Programming Objects
    private int shopScrollIndex;
    private int menuScrollIndex;
    private string MenuType;
    private Sprite defaultFoodSprite;
    private Sprite defaultIngredientSprite;

    private GameObject food1;
    private GameObject food2;
    private GameObject food3;
    private GameObject food4;

    void Start()
    {
        mainMenu = mainCanvas.transform.GetChild(0).gameObject;
        shopScroll = mainCanvas.transform.GetChild(1).gameObject;
        menuScroll = mainCanvas.transform.GetChild(2).gameObject;
        marketScroll = mainCanvas.transform.GetChild(3).gameObject;
        foodSelection = mainCanvas.transform.GetChild(4).gameObject;
        ingredientScroll = mainCanvas.transform.GetChild(5).gameObject;
        middleBar = mainCanvas.transform.GetChild(6).gameObject;

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
        recipe1 = m_scroll1.transform.GetChild(2).gameObject;
        recipe2 = m_scroll2.transform.GetChild(2).gameObject;
        recipe3 = m_scroll3.transform.GetChild(2).gameObject;
        recipe4 = m_scroll4.transform.GetChild(2).gameObject;
        ingredient1_1 = recipe1.transform.GetChild(0).gameObject;
        ingredient1_2 = recipe1.transform.GetChild(1).gameObject;
        ingredient1_3 = recipe1.transform.GetChild(2).gameObject;
        ingredient1_4 = recipe1.transform.GetChild(3).gameObject;
        ingredient2_1 = recipe2.transform.GetChild(0).gameObject;
        ingredient2_2 = recipe2.transform.GetChild(1).gameObject;
        ingredient2_3 = recipe2.transform.GetChild(2).gameObject;
        ingredient2_4 = recipe2.transform.GetChild(3).gameObject;
        ingredient3_1 = recipe3.transform.GetChild(0).gameObject;
        ingredient3_2 = recipe3.transform.GetChild(1).gameObject;
        ingredient3_3 = recipe3.transform.GetChild(2).gameObject;
        ingredient3_4 = recipe3.transform.GetChild(3).gameObject;
        ingredient4_1 = recipe4.transform.GetChild(0).gameObject;
        ingredient4_2 = recipe4.transform.GetChild(1).gameObject;
        ingredient4_3 = recipe4.transform.GetChild(2).gameObject;
        ingredient4_4 = recipe4.transform.GetChild(3).gameObject;
        m_text1 = m_scroll1.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text2 = m_scroll2.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text3 = m_scroll3.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text4 = m_scroll4.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        //Market Menu

        //Food Selection
        f_close = foodSelection.transform.GetChild(0).gameObject.GetComponent<Button>();
        f_desc = foodSelection.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        f_image = foodSelection.transform.GetChild(2).GetComponent<Image>().sprite;
        f_ingredient1 = foodSelection.transform.GetChild(3).GetChild(0).gameObject;
        f_ingredient2 = foodSelection.transform.GetChild(3).GetChild(1).gameObject;
        f_ingredient3 = foodSelection.transform.GetChild(3).GetChild(2).gameObject;
        f_ingredient4 = foodSelection.transform.GetChild(3).GetChild(3).gameObject;
        f_level_button = foodSelection.transform.GetChild(4).GetChild(0).GetComponent<Button>();
        f_select_button = foodSelection.transform.GetChild(4).GetChild(1).GetComponent<Button>();
        f_price_button = foodSelection.transform.GetChild(4).GetChild(2).GetComponent<Button>();
        f_yes_button = foodSelection.transform.GetChild(5).GetChild(0).GetComponent<Button>();
        f_no_button = foodSelection.transform.GetChild(5).GetChild(1).GetComponent<Button>();
        f_level_text = foodSelection.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>();
        f_select_text = foodSelection.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>();
        f_health_text = foodSelection.transform.GetChild(4).GetChild(2).GetChild(0).GetComponent<Text>();
        f_button_panel1 = foodSelection.transform.GetChild(4).gameObject;
        f_button_panel2 = foodSelection.transform.GetChild(5).gameObject;

        //Ingredient Scroll

        //Middle Bar
        cheatBox = middleBar.transform.GetChild(0).gameObject;
        cheatText = middleBar.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        cameraText = middleBar.transform.GetChild(2).GetChild(0).GetComponent<Text>();

    defaultFoodSprite = m_image1.GetComponent<Image>().sprite;
        defaultIngredientSprite = ingredient1_1.GetComponent<Image>().sprite;
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

        middleBar.SetActive(true);
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
        mainButton2.onClick.AddListener(() => CloseFoodSelection());
        mainButton3.onClick.AddListener(() => LoadAppetizers(0));
        mainButton3.onClick.AddListener(() => CloseFoodSelection());
        mainButton3.onClick.AddListener(() => ResetMenuScrollIndex());
        mainButton4.onClick.AddListener(() => LoadEntrees(0));
        mainButton4.onClick.AddListener(() => CloseFoodSelection());
        mainButton4.onClick.AddListener(() => ResetMenuScrollIndex());
        mainButton5.onClick.AddListener(() => LoadDesserts(0));
        mainButton5.onClick.AddListener(() => CloseFoodSelection());
        mainButton5.onClick.AddListener(() => ResetMenuScrollIndex());

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
        //mainButton4.onClick.AddListener(() => ShowWallpaperStore());

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

    public void ShowMarketMenu()
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

    public void ShowFood(GameObject food)
    {
        menuScroll.SetActive(false);
        bool canLevel = true;

        //Yes and No Buttons
        f_yes_button.onClick.RemoveAllListeners();
        f_yes_button.onClick.AddListener(() => ConfirmLevel(food));
        f_no_button.onClick.RemoveAllListeners();
        f_no_button.onClick.AddListener(() => DeclineLevel());

        //Back Button
        f_close.onClick.RemoveAllListeners();
        f_close.onClick.AddListener(() => CloseFoodSelection());
        if (MenuType == "Appetizers")
            f_close.onClick.AddListener(() => LoadAppetizers(menuScrollIndex));
        else if (MenuType == "Entrees")
            f_close.onClick.AddListener(() => LoadEntrees(menuScrollIndex));
        else if (MenuType == "Desserts")
            f_close.onClick.AddListener(() => LoadDesserts(menuScrollIndex));

        //Buttons
        f_level_button.onClick.RemoveAllListeners();
        if(food.GetComponent<Food>().level > 0)
        {
            f_level_text.text = "Level Up";
            f_select_button.interactable = true;
            f_select_button.onClick.AddListener(() => SelectToggle());
            f_price_button.interactable = true;
            f_price_button.onClick.AddListener(() => ShowPricingOptions());
        }
        else
        {
            f_level_text.text = "Unlock";
            f_select_button.interactable = false;
            f_price_button.interactable = false;
        }

        //Description
        f_desc.text = food.ToString().Replace(" (UnityEngine.GameObject)", "");
        if (food.GetComponent<Food>().level > 0)
            f_desc.text += "\nLevel " + food.GetComponent<Food>().level;
        else
            f_desc.text += "\n<Unlock>";

        //Food Image
        if (food.GetComponent<Food>().menuSprite != null)
            f_image = food.GetComponent<Food>().menuSprite;
        else
            f_image = defaultFoodSprite;

        //Ingredient Images
        try
        {
            if (food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image != null)
                f_ingredient1.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image;
            else
                f_ingredient1.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().quatity == 0)
            {
                canLevel = false;
                f_ingredient1.GetComponent<Image>().color = faded;
            }
            else
            {
                f_ingredient1.GetComponent<Image>().color = Color.white;
            }
            f_ingredient1.SetActive(true);
        }
        catch
        {
            f_ingredient1.SetActive(false);
        }

        try
        {
            if (food.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image != null)
                f_ingredient2.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image;
            else
                f_ingredient2.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().quatity == 0)
            {
                canLevel = false;
                f_ingredient2.GetComponent<Image>().color = faded;
            }
            else
            {
                f_ingredient2.GetComponent<Image>().color = Color.white;
            }
            f_ingredient2.SetActive(true);
        }
        catch
        {
            f_ingredient2.SetActive(false);
        }

        try
        {
            if (food.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image != null)
                f_ingredient3.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image;
            else
                f_ingredient3.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().quatity == 0)
            {
                canLevel = false;
                f_ingredient3.GetComponent<Image>().color = faded;
            }
            else
            {
                f_ingredient3.GetComponent<Image>().color = Color.white;
            }
            f_ingredient3.SetActive(true);
        }
        catch
        {
            f_ingredient3.SetActive(false);
        }

        try
        {
            if (food.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image != null)
                f_ingredient4.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image;
            else
                f_ingredient4.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().quatity == 0)
            {
                canLevel = false;
                f_ingredient4.GetComponent<Image>().color = faded;
            }
            else
            {
                f_ingredient4.GetComponent<Image>().color = Color.white;
            }
            f_ingredient4.SetActive(true);
        }
        catch
        {
            f_ingredient4.SetActive(false);
        }

        //Level Up Button Continued...
        if(canLevel)
        {
            f_level_button.onClick.AddListener(() => ShowLevelConfirmation());
            f_level_button.interactable = true;
        }
        else
        {
            f_level_button.interactable = false;
        }
        foodSelection.SetActive(true);
    }

    public void ShowLevelConfirmation()
    {
        f_button_panel1.SetActive(false);
        f_button_panel2.SetActive(true);
    }

    public void ConfirmLevel(GameObject food)
    {
        food.GetComponent<Food>().level++;
        f_button_panel1.SetActive(true);
        f_button_panel2.SetActive(false);
        for(int i = 0; i < food.GetComponent<Food>().recipe.Length; i++)
        {
            food.GetComponent<Food>().recipe[i].GetComponent<Ingredient>().quatity--;
        }
        ShowFood(food);
    }

    public void DeclineLevel()
    {
        f_button_panel1.SetActive(true);
        f_button_panel2.SetActive(false);
    }

    public void ShowPricingOptions()
    {

    }

    public void SelectToggle()
    {

    }

    public void LoadIngredients(int index)
    {
        MenuType = "Ingredients";

    }

    public void LoadAppetizers(int index)
    {
        MenuType = "Appetizers";
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 0)
        {
            food1 =  GetComponent<FoodVariables>().Appetizers[index + 0];
            LoadMenu1(food1);
            m_scroll1.SetActive(true);
        }
        else
        {
            m_scroll1.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 1)
        {
            food2 = GetComponent<FoodVariables>().Appetizers[index + 1];
            LoadMenu2(food2);
            m_scroll2.SetActive(true);
        }
        else
        {
            m_scroll2.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 2)
        {
            food3 = GetComponent<FoodVariables>().Appetizers[index + 2];
            LoadMenu3(food3);
            m_scroll3.SetActive(true);
        }
        else
        {
            m_scroll3.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 3)
        {
            food4 = GetComponent<FoodVariables>().Appetizers[index + 3];
            LoadMenu4(food4);
            m_scroll4.SetActive(true);
        }
        else
        {
            m_scroll4.SetActive(false);
        }

        menuScroll.SetActive(true);
    }

    public void LoadEntrees(int index)
    {
        MenuType = "Entrees";
        if (GetComponent<FoodVariables>().Entrees.Length > index + 0)
        {
            food1 = GetComponent<FoodVariables>().Entrees[index + 0];
            LoadMenu1(food1);
            m_scroll1.SetActive(true);
        }
        else
        {
            m_scroll1.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 1)
        {
            food2 = GetComponent<FoodVariables>().Entrees[index + 1];
            LoadMenu2(food2);
            m_scroll2.SetActive(true);
        }
        else
        {
            m_scroll2.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 2)
        {
            food3 = GetComponent<FoodVariables>().Entrees[index + 2];
            LoadMenu3(food3);
            m_scroll3.SetActive(true);
        }
        else
        {
            m_scroll3.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 3)
        {
            food4 = GetComponent<FoodVariables>().Entrees[index + 3];
            LoadMenu4(food4);
            m_scroll4.SetActive(true);
        }
        else
        {
            m_scroll4.SetActive(false);
        }

        menuScroll.SetActive(true);
    }

    public void LoadDesserts(int index)
    {
        MenuType = "Desserts";
        if (GetComponent<FoodVariables>().Desserts.Length > index + 0)
        {
            food1 = GetComponent<FoodVariables>().Desserts[index + 0];
            LoadMenu1(food1);
            m_scroll1.SetActive(true);
        }
        else
        {
            m_scroll1.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 1)
        {
            food2 = GetComponent<FoodVariables>().Desserts[index + 1];
            LoadMenu2(food2);
            m_scroll2.SetActive(true);
        }
        else
        {
            m_scroll2.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 2)
        {
            food3 = GetComponent<FoodVariables>().Desserts[index + 2];
            LoadMenu3(food3);
            m_scroll3.SetActive(true);
        }
        else
        {
            m_scroll3.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 3)
        {
            food4 = GetComponent<FoodVariables>().Desserts[index + 3];
            LoadMenu4(food4);
            m_scroll4.SetActive(true);
        }
        else
        {
            m_scroll4.SetActive(false);
        }

        menuScroll.SetActive(true);
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
        if(MenuType == "Appetizers")
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

    private void LoadMenu1(GameObject food1)
    {
        m_button1.onClick.RemoveAllListeners();
        m_button1.onClick.AddListener(() => ShowFood(food1));
        m_text1.text = food1.ToString().Replace(" (UnityEngine.GameObject)", "");
        if (food1.GetComponent<Food>().level > 0)
            m_text1.text += "\nLevel " + food1.GetComponent<Food>().level;
        else
            m_text1.text += "\n<Unlock>";

        //Food
        if (food1.GetComponent<Food>().menuSprite != null)
            m_image1.GetComponent<Image>().sprite = food1.GetComponent<Food>().menuSprite;
        else
            m_image1.GetComponent<Image>().sprite = defaultFoodSprite;

        //Ingredients
        try
        {
            if (food1.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image != null)
                ingredient1_1.GetComponent<Image>().sprite = food1.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image;
            else
                ingredient1_1.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient1_1.SetActive(true);
        }
        catch
        {
            ingredient1_1.SetActive(false);
        }

        try
        {
            if (food1.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image != null)
                ingredient1_2.GetComponent<Image>().sprite = food1.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image;
            else
                ingredient1_2.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient1_2.SetActive(true);
        }
        catch
        {
            ingredient1_2.SetActive(false);
        }

        try
        {
            if (food1.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image != null)
                ingredient1_3.GetComponent<Image>().sprite = food1.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image;
            else
                ingredient1_3.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient1_3.SetActive(true);
        }
        catch
        {
            ingredient1_3.SetActive(false);
        }

        try
        {
            if (food1.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image != null)
                ingredient1_4.GetComponent<Image>().sprite = food1.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image;
            else
                ingredient1_4.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient1_4.SetActive(true);
        }
        catch
        {
            ingredient1_4.SetActive(false);
        }
    }

    private void LoadMenu2(GameObject food2)
    {
        m_button2.onClick.RemoveAllListeners();
        m_button2.onClick.AddListener(() => ShowFood(food2));
        m_text2.text = food2.ToString().Replace(" (UnityEngine.GameObject)", "");
        if (food2.GetComponent<Food>().level > 0)
            m_text2.text += "\nLevel " + food2.GetComponent<Food>().level;
        else
            m_text2.text += "\n<Unlock>";

        //Food
        if (food2.GetComponent<Food>().menuSprite != null)
            m_image2.GetComponent<Image>().sprite = food2.GetComponent<Food>().menuSprite;
        else
            m_image2.GetComponent<Image>().sprite = defaultFoodSprite;

        //Ingredients
        try
        {
            if (food2.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image != null)
                ingredient2_1.GetComponent<Image>().sprite = food2.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image;
            else
                ingredient2_1.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient2_1.SetActive(true);
        }
        catch
        {
            ingredient2_1.SetActive(false);
        }

        try
        {
            if (food2.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image != null)
                ingredient2_2.GetComponent<Image>().sprite = food2.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image;
            else
                ingredient2_2.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient2_2.SetActive(true);
        }
        catch
        {
            ingredient2_2.SetActive(false);
        }

        try
        {
            if (food2.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image != null)
                ingredient2_3.GetComponent<Image>().sprite = food2.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image;
            else
                ingredient2_3.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient2_3.SetActive(true);
        }
        catch
        {
            ingredient2_3.SetActive(false);
        }

        try
        {
            if (food2.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image != null)
                ingredient2_4.GetComponent<Image>().sprite = food2.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image;
            else
                ingredient2_4.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient2_4.SetActive(true);
        }
        catch
        {
            ingredient2_4.SetActive(false);
        }
    }

    private void LoadMenu3(GameObject food3)
    {
        m_button3.onClick.RemoveAllListeners();
        m_button3.onClick.AddListener(() => ShowFood(food3));
        m_text3.text = food3.ToString().Replace(" (UnityEngine.GameObject)", "");
        if (food3.GetComponent<Food>().level > 0)
            m_text3.text += "\nLevel " + food3.GetComponent<Food>().level;
        else
            m_text3.text += "\n<Unlock>";

        //Food
        if (food3.GetComponent<Food>().menuSprite != null)
            m_image3.GetComponent<Image>().sprite = food3.GetComponent<Food>().menuSprite;
        else
            m_image3.GetComponent<Image>().sprite = defaultFoodSprite;

        //Ingredients
        try
        {
            if (food3.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image != null)
                ingredient3_1.GetComponent<Image>().sprite = food3.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image;
            else
                ingredient3_1.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient3_1.SetActive(true);
        }
        catch
        {
            ingredient3_1.SetActive(false);
        }

        try
        {
            if (food3.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image != null)
                ingredient3_2.GetComponent<Image>().sprite = food3.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image;
            else
                ingredient3_2.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient3_2.SetActive(true);
        }
        catch
        {
            ingredient3_2.SetActive(false);
        }

        try
        {
            if (food3.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image != null)
                ingredient3_3.GetComponent<Image>().sprite = food3.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image;
            else
                ingredient3_3.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient3_3.SetActive(true);
        }
        catch
        {
            ingredient3_3.SetActive(false);
        }

        try
        {
            if (food3.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image != null)
                ingredient3_4.GetComponent<Image>().sprite = food3.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image;
            else
                ingredient3_4.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient3_4.SetActive(true);
        }
        catch
        {
            ingredient3_4.SetActive(false);
        }
    }

    private void LoadMenu4(GameObject food4)
    {
        m_button4.onClick.RemoveAllListeners();
        m_button4.onClick.AddListener(() => ShowFood(food4));
        m_text4.text = food4.ToString().Replace(" (UnityEngine.GameObject)", "");
        if (food4.GetComponent<Food>().level > 0)
            m_text4.text += "\nLevel " + food4.GetComponent<Food>().level;
        else
            m_text4.text += "\n<Unlock>";

        //Food
        if (food4.GetComponent<Food>().menuSprite != null)
            m_image4.GetComponent<Image>().sprite = food4.GetComponent<Food>().menuSprite;
        else
            m_image4.GetComponent<Image>().sprite = defaultFoodSprite;

        //Ingredients
        try
        {
            if (food4.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image != null)
                ingredient4_1.GetComponent<Image>().sprite = food4.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image;
            else
                ingredient4_1.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient4_1.SetActive(true);
        }
        catch
        {
            ingredient4_1.SetActive(false);
        }

        try
        {
            if (food4.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image != null)
                ingredient4_2.GetComponent<Image>().sprite = food4.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image;
            else
                ingredient4_2.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient4_2.SetActive(true);
        }
        catch
        {
            ingredient4_2.SetActive(false);
        }

        try
        {
            if (food4.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image != null)
                ingredient4_3.GetComponent<Image>().sprite = food4.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image;
            else
                ingredient4_3.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient4_3.SetActive(true);
        }
        catch
        {
            ingredient4_3.SetActive(false);
        }

        try
        {
            if (food4.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image != null)
                ingredient4_4.GetComponent<Image>().sprite = food4.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image;
            else
                ingredient4_4.GetComponent<Image>().sprite = defaultIngredientSprite;
            ingredient4_4.SetActive(true);
        }
        catch
        {
            ingredient4_4.SetActive(false);
        }
    }

    public void ToggleCheatBox(bool value)
    {
        cheatText.text = "";
        cheatBox.SetActive(value);
    }

    public string GetCheat()
    {
        return cheatText.text;
    }

    public void ToggleCamera()
    {
        if(cameraText.text == "Unlock Camera")
        {
            cameraText.text = "Lock Camera";
            gameCamera.GetComponent<GodCam>().enabled = true;
        }
        else
        {
            cameraText.text = "Unlock Camera";
            gameCamera.GetComponent<GodCam>().enabled = false;
        }
    }

    private void ClearAll()
    {
        mainMenu.SetActive(false);
        shopScroll.SetActive(false);
        menuScroll.SetActive(false);
        marketScroll.SetActive(false);
        foodSelection.SetActive(false);
        ingredientScroll.SetActive(false);
        middleBar.SetActive(false);
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
        menuNext.onClick.RemoveAllListeners();
        menuBack.onClick.RemoveAllListeners();
    }

    private void ResetAllPanelsMainMenu()
    {
        main1.SetActive(true);
        main2.SetActive(true);
        main3.SetActive(true);
        main4.SetActive(true);
        main5.SetActive(true);
    }

    public void ResetMenuScrollIndex()
    {
        menuScrollIndex = 0;
    }

    public void CloseFoodSelection()
    {
        foodSelection.SetActive(false);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), Message);
    }

    void OnMouseEnter()
    {
        Message = "Here I am.";
    }

    void OnMouseExit()
    {
        Message = "";
    }
}
