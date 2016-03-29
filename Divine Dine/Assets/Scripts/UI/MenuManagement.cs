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
    private Text k_title;
    private GameObject k_panel1;
    private GameObject k_panel2;
    private GameObject k_panel3;
    private GameObject k_panel4;
    private GameObject k_image1;
    private GameObject k_image2;
    private GameObject k_image3;
    private GameObject k_image4;
    private Button k_button1;
    private Button k_button2;
    private Button k_button3;
    private Button k_button4;
    private Text k_text1;
    private Text k_text2;
    private Text k_text3;
    private Text k_text4;

    //Food Selection
    private Button f_close;
    private Text f_desc;
    private GameObject f_food_image;
    private GameObject f_ingredient_image;
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

    ArrayList saleItems;
    ArrayList marketItems;
    ArrayList rareItems;
    ArrayList unstockedItems;
    ArrayList myIngredients;

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
        k_title = marketScroll.transform.GetChild(0).GetComponent<Text>();
        k_panel1 = marketScroll.transform.GetChild(3).gameObject;
        k_panel2 = marketScroll.transform.GetChild(4).gameObject;
        k_panel3 = marketScroll.transform.GetChild(5).gameObject;
        k_panel4 = marketScroll.transform.GetChild(6).gameObject;
        k_image1 = k_panel1.transform.GetChild(0).gameObject;
        k_image2 = k_panel2.transform.GetChild(0).gameObject;
        k_image3 = k_panel3.transform.GetChild(0).gameObject;
        k_image4 = k_panel4.transform.GetChild(0).gameObject;
        k_button1 = k_panel1.transform.GetChild(1).GetComponent<Button>();
        k_button2 = k_panel2.transform.GetChild(1).GetComponent<Button>();
        k_button3 = k_panel3.transform.GetChild(1).GetComponent<Button>();
        k_button4 = k_panel4.transform.GetChild(1).GetComponent<Button>();
        k_text1 = k_panel1.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        k_text2 = k_panel2.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        k_text3 = k_panel3.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        k_text4 = k_panel4.transform.GetChild(1).GetChild(0).GetComponent<Text>();

        //Food Selection
        f_close = foodSelection.transform.GetChild(0).gameObject.GetComponent<Button>();
        f_desc = foodSelection.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        f_food_image = foodSelection.transform.GetChild(2).gameObject;
        f_ingredient_image = foodSelection.transform.GetChild(3).gameObject;
        f_ingredient1 = foodSelection.transform.GetChild(4).GetChild(0).gameObject;
        f_ingredient2 = foodSelection.transform.GetChild(4).GetChild(1).gameObject;
        f_ingredient3 = foodSelection.transform.GetChild(4).GetChild(2).gameObject;
        f_ingredient4 = foodSelection.transform.GetChild(4).GetChild(3).gameObject;
        f_level_button = foodSelection.transform.GetChild(5).GetChild(0).GetComponent<Button>();
        f_select_button = foodSelection.transform.GetChild(5).GetChild(1).GetComponent<Button>();
        f_price_button = foodSelection.transform.GetChild(5).GetChild(2).GetComponent<Button>();
        f_yes_button = foodSelection.transform.GetChild(6).GetChild(0).GetComponent<Button>();
        f_no_button = foodSelection.transform.GetChild(6).GetChild(1).GetComponent<Button>();
        f_level_text = foodSelection.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>();
        f_select_text = foodSelection.transform.GetChild(5).GetChild(1).GetChild(0).GetComponent<Text>();
        f_health_text = foodSelection.transform.GetChild(5).GetChild(2).GetChild(0).GetComponent<Text>();
        f_button_panel1 = foodSelection.transform.GetChild(5).gameObject;
        f_button_panel2 = foodSelection.transform.GetChild(6).gameObject;

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
        ClearAll();

        GetComponent<FoodVariables>().CalculateMarket();
        saleItems = GetComponent<FoodVariables>().GetSaleItems();
        marketItems = GetComponent<FoodVariables>().GetMarketItems();
        rareItems = GetComponent<FoodVariables>().GetRareItems();
        unstockedItems = GetComponent<FoodVariables>().GetUnstockedItems();

        ResetAllPanelsMainMenu();
        mainText1.text = "Back";
        mainText2.text = "My Ingredients";
        mainText3.text = "All Ingredients";
        mainText4.text = "Special Order";
        mainText5.text = "Market Stats";

        ClearButtonsMainMenu();
        mainButton1.onClick.AddListener(() => ShowMainMenu());
        mainButton2.onClick.AddListener(() => LoadIngredients(0));
        mainButton3.onClick.AddListener(() => ShowAllMarket());
        mainButton4.onClick.AddListener(() => ShowSepcialMarket());
        mainButton5.onClick.AddListener(() => ShowMarketStats());

        mainMenu.SetActive(true);
    }

    public void ShowTrophies()
    {
        //ClearAll();
    }

    public void ShowAllMarket()
    {
        MenuType = "Market All";

        menuScrollIndex = 0;
        LoadMarket(menuScrollIndex);
        marketScroll.SetActive(true);
    }

    public void ShowSepcialMarket()
    {

    }

    public void ShowMarketStats()
    {

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

    public void ShowIngredient(GameObject ingredient, int flag)
    {
        marketScroll.SetActive(false);
        f_button_panel1.SetActive(false);
        f_button_panel2.SetActive(true);

        f_food_image.SetActive(false);
        f_ingredient_image.SetActive(true);

        //Back Button
        f_close.onClick.RemoveAllListeners();
        f_close.onClick.AddListener(() => LoadMarket(menuScrollIndex));
        f_close.onClick.AddListener(() => CloseFoodSelection());


        //Description
        f_desc.text = ingredient.ToString().Replace(" (UnityEngine.GameObject)", "");

        //Food Image
        if (ingredient.GetComponent<Ingredient>().image != null)
            f_ingredient_image.GetComponent<Image>().sprite = ingredient.GetComponent<Ingredient>().image;
        else
            f_ingredient_image.GetComponent<Image>().sprite = defaultFoodSprite;

        foodSelection.SetActive(true);

        //Ingredient Images
        f_ingredient1.SetActive(false);
        f_ingredient2.SetActive(false);
        f_ingredient3.SetActive(false);
        f_ingredient4.SetActive(false);

        //Yes and No Buttons
        f_yes_button.interactable = true;
        f_yes_button.onClick.RemoveAllListeners();
        f_yes_button.onClick.AddListener(() => ingredient.GetComponent<Ingredient>().quatity++);
        f_yes_button.onClick.AddListener(() => LoadMarket(menuScrollIndex));
        f_yes_button.onClick.AddListener(() => CloseFoodSelection());

        f_no_button.interactable = true;
        f_no_button.onClick.RemoveAllListeners();
        f_no_button.onClick.AddListener(() => LoadMarket(menuScrollIndex));
        f_no_button.onClick.AddListener(() => CloseFoodSelection());

        if (flag == 0)
        {
            if (GetComponent<GlobalVariables>().money >= ingredient.GetComponent<Ingredient>().GetSalePrice())
                f_yes_button.onClick.AddListener(() => GetComponent<GlobalVariables>().AddMoney(-(ingredient.GetComponent<Ingredient>().GetSalePrice())));
            else
                f_yes_button.interactable = false;
            f_desc.text += "\nSale Price : $" + ingredient.GetComponent<Ingredient>().GetSalePrice();
        }
        else if (flag == 1)
        {
            if (GetComponent<GlobalVariables>().money >= ingredient.GetComponent<Ingredient>().marketPrice)
                f_yes_button.onClick.AddListener(() => GetComponent<GlobalVariables>().AddMoney(-(ingredient.GetComponent<Ingredient>().marketPrice)));
            else
                f_yes_button.interactable = false;
            f_desc.text += "\nMarket Price : $" + ingredient.GetComponent<Ingredient>().marketPrice;
        }
        else
        {
            if (GetComponent<GlobalVariables>().money >= ingredient.GetComponent<Ingredient>().GetRarePrice())
                f_yes_button.onClick.AddListener(() => GetComponent<GlobalVariables>().AddMoney(-(ingredient.GetComponent<Ingredient>().GetRarePrice())));
            else
                f_yes_button.interactable = false;
            f_desc.text += "\nRarity Price : $" + ingredient.GetComponent<Ingredient>().GetRarePrice();
        }
    }

    public void ShowFood(GameObject food)
    {
        menuScroll.SetActive(false);
        bool canLevel = true;
        f_food_image.SetActive(true);
        f_ingredient_image.SetActive(false);
        f_button_panel1.SetActive(true);
        f_button_panel2.SetActive(false);

        //Yes and No Buttons
        f_yes_button.interactable = true;
        f_yes_button.onClick.RemoveAllListeners();
        f_yes_button.onClick.AddListener(() => ConfirmLevel(food));
        f_no_button.interactable = true;
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
            f_price_button.interactable = true;
            f_price_button.onClick.RemoveAllListeners();
            f_price_button.onClick.AddListener(() => ShowPricingOptions());

            //Select Button
            f_select_button.onClick.RemoveAllListeners();
            f_select_button.interactable = true;
            if(GetComponent<FoodVariables>().GetAllSelectedRecipes().Contains(food))
            {
                //Already Selected
                f_select_text.text = "Unselect";
                f_select_button.onClick.AddListener(() => SelectToggle(true, food));
            }
            else
            {
                //Can Be Selected
                f_select_text.text = "Select";
                f_select_button.onClick.AddListener(() => SelectToggle(false, food));
            }
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
            f_food_image.GetComponent<Image>().sprite = food.GetComponent<Food>().menuSprite;
        else
            f_food_image.GetComponent<Image>().sprite = defaultFoodSprite;

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
            if (food.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().quatity == 0)
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
        GetComponent<FoodVariables>().calculatePrice(food.GetComponent<Food>());
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

    //This is on the "Show Food Menu" the button to change health options
    public void ShowPricingOptions()
    {

    }

    //This is on the "Show Food Menu" the button to select a dish
    public void SelectToggle(bool selected, GameObject food)
    {
        f_select_button.onClick.RemoveAllListeners();
        if(selected)
        {
            GetComponent<FoodVariables>().GetAllSelectedRecipes().Remove(food);
            f_select_text.text = "Select";
            f_select_button.onClick.AddListener(() => SelectToggle(false, food));
        }
        else
        {
            GetComponent<FoodVariables>().GetAllSelectedRecipes().Add(food);
            f_select_text.text = "Unselect";
            f_select_button.onClick.AddListener(() => SelectToggle(true, food));
        }
    }

    public void LoadMarket(int index)
    {
        GameObject ingredient;
        k_title.text = "THE MARKET";

        int saleIndex = 0;
        int marketIndex = 0;
        int rareIndex = 0;
        int unstockedIndex = 0;

        if (saleItems.Count > index + saleIndex)
        {
            ingredient = (GameObject)saleItems[index + saleIndex];
            LoadMarket(ingredient, k_image1, k_button1, k_text1, 0);
            k_panel1.SetActive(true);
            saleIndex++;
        }
        else
        {
            if(marketItems.Count > ((index-saleItems.Count) + marketIndex))
            {
                ingredient = (GameObject)marketItems[(index - saleItems.Count) + marketIndex];
                LoadMarket(ingredient, k_image1, k_button1, k_text1, 1);
                k_panel1.SetActive(true);
                marketIndex++;
            }
            else
            {
                if(rareItems.Count > ((index - saleItems.Count - marketItems.Count) + rareIndex))
                {
                    ingredient = (GameObject)rareItems[(index - saleItems.Count - marketItems.Count) + rareIndex];
                    LoadMarket(ingredient, k_image1, k_button1, k_text1, 2);
                    k_panel1.SetActive(true);
                    rareIndex++;
                }
                else
                {
                    if(unstockedItems.Count > ((index - saleItems.Count - marketItems.Count- rareItems.Count) + unstockedIndex))
                    {
                        ingredient = (GameObject)unstockedItems[(index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex];
                        LoadMarket(ingredient, k_image1, k_button1, k_text1, 3);
                        k_panel1.SetActive(true);
                        unstockedIndex++;
                    }
                    else
                    {
                        k_panel1.SetActive(false);
                    }
                }
            }
        }
        if (saleItems.Count > index + saleIndex)
        {
            ingredient = (GameObject)saleItems[index + saleIndex];
            LoadMarket(ingredient, k_image2, k_button2, k_text2, 0);
            k_panel2.SetActive(true);
            saleIndex++;
        }
        else
        {
            if (marketItems.Count > ((index - saleItems.Count) + marketIndex))
            {
                ingredient = (GameObject)marketItems[(index - saleItems.Count) + marketIndex];
                LoadMarket(ingredient, k_image2, k_button2, k_text2, 1);
                k_panel2.SetActive(true);
                marketIndex++;
            }
            else
            {
                if (rareItems.Count > ((index - saleItems.Count - marketItems.Count) + rareIndex))
                {
                    ingredient = (GameObject)rareItems[(index - saleItems.Count - marketItems.Count) + rareIndex];
                    LoadMarket(ingredient, k_image2, k_button2, k_text2, 2);
                    k_panel2.SetActive(true);
                    rareIndex++;
                }
                else
                {
                    if (unstockedItems.Count > ((index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex))
                    {
                        ingredient = (GameObject)unstockedItems[(index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex];
                        LoadMarket(ingredient, k_image2, k_button2, k_text2, 3);
                        k_panel2.SetActive(true);
                        unstockedIndex++;
                    }
                    else
                    {
                        k_panel2.SetActive(false);
                    }
                }
            }
        }
        if (saleItems.Count > index + saleIndex)
        {
            ingredient = (GameObject)saleItems[index + saleIndex];
            LoadMarket(ingredient, k_image3, k_button3, k_text3, 0);
            k_panel3.SetActive(true);
            saleIndex++;
        }
        else
        {
            if (marketItems.Count > ((index - saleItems.Count) + marketIndex))
            {
                ingredient = (GameObject)marketItems[(index - saleItems.Count) + marketIndex];
                LoadMarket(ingredient, k_image3, k_button3, k_text3, 1);
                k_panel3.SetActive(true);
                marketIndex++;
            }
            else
            {
                if (rareItems.Count > ((index - saleItems.Count - marketItems.Count) + rareIndex))
                {
                    ingredient = (GameObject)rareItems[(index - saleItems.Count - marketItems.Count) + rareIndex];
                    LoadMarket(ingredient, k_image3, k_button3, k_text3, 2);
                    k_panel3.SetActive(true);
                    rareIndex++;
                }
                else
                {
                    if (unstockedItems.Count > ((index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex))
                    {
                        ingredient = (GameObject)unstockedItems[(index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex];
                        LoadMarket(ingredient, k_image3, k_button3, k_text3, 3);
                        k_panel3.SetActive(true);
                        unstockedIndex++;
                    }
                    else
                    {
                        k_panel3.SetActive(false);
                    }
                }
            }
        }
        if (saleItems.Count > index + saleIndex)
        {
            ingredient = (GameObject)saleItems[index + saleIndex];
            LoadMarket(ingredient, k_image4, k_button4, k_text4, 0);
            k_panel4.SetActive(true);
            saleIndex++;
        }
        else
        {
            if (marketItems.Count > ((index - saleItems.Count) + marketIndex))
            {
                ingredient = (GameObject)marketItems[(index - saleItems.Count) + marketIndex];
                LoadMarket(ingredient, k_image4, k_button4, k_text4, 1);
                k_panel4.SetActive(true);
                marketIndex++;
            }
            else
            {
                if (rareItems.Count > ((index - saleItems.Count - marketItems.Count) + rareIndex))
                {
                    ingredient = (GameObject)rareItems[(index - saleItems.Count - marketItems.Count) + rareIndex];
                    LoadMarket(ingredient, k_image4, k_button4, k_text4, 2);
                    k_panel4.SetActive(true);
                    rareIndex++;
                }
                else
                {
                    if (unstockedItems.Count > ((index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex))
                    {
                        ingredient = (GameObject)unstockedItems[(index - saleItems.Count - marketItems.Count - rareItems.Count) + unstockedIndex];
                        LoadMarket(ingredient, k_image4, k_button4, k_text4, 3);
                        k_panel4.SetActive(true);
                        unstockedIndex++;
                    }
                    else
                    {
                        k_panel4.SetActive(false);
                    }
                }
            }
        }
        marketScroll.SetActive(true);
    }

    public void LoadSaleMarket(int index)
    {
        GameObject ingredient;
        if (saleItems.Count > index + 0)
        {
            ingredient = (GameObject)saleItems[index + 0];
            LoadMarket(ingredient, k_image1, k_button1, k_text1, 0);
            k_panel1.SetActive(true);
        }
        else
        {
            k_panel1.SetActive(false);
        }
        if (saleItems.Count > index + 1)
        {
            ingredient = (GameObject)saleItems[index + 1];
            LoadMarket(ingredient, k_image2, k_button2, k_text2, 0);
            k_panel2.SetActive(true);
        }
        else
        {
            k_panel2.SetActive(false);
        }
        if (saleItems.Count > index + 2)
        {
            ingredient = (GameObject)saleItems[index + 2];
            LoadMarket(ingredient, k_image3, k_button3, k_text3, 0);
            k_panel3.SetActive(true);
        }
        else
        {
            k_panel3.SetActive(false);
        }
        if (saleItems.Count > index + 3)
        {
            ingredient = (GameObject)saleItems[index + 3];
            LoadMarket(ingredient, k_image4, k_button4, k_text4, 0);
            k_panel4.SetActive(true);
        }
        else
        {
            k_panel4.SetActive(false);
        }
    }

    public void LoadIngredients(int index)
    {
        MenuType = "Ingredients";
        k_title.text = "YOUR INGREDIENTS";
        myIngredients = GetComponent<FoodVariables>().GetMyIngredients();
        GameObject ingredient;

        if (myIngredients.Count > index + 0)
        {
            ingredient = (GameObject)myIngredients[index + 0];
            LoadMarket(ingredient, k_image1, k_button1, k_text1, 4);
            k_panel1.SetActive(true);
        }
        else
        {
            k_panel1.SetActive(false);
        }
        if (myIngredients.Count > index + 1)
        {
            ingredient = (GameObject)myIngredients[index + 1];
            LoadMarket(ingredient, k_image2, k_button2, k_text2, 4);
            k_panel2.SetActive(true);
        }
        else
        {
            k_panel2.SetActive(false);
        }
        if (myIngredients.Count > index + 2)
        {
            ingredient = (GameObject)myIngredients[index + 2];
            LoadMarket(ingredient, k_image3, k_button3, k_text3, 4);
            k_panel3.SetActive(true);
        }
        else
        {
            k_panel3.SetActive(false);
        }
        if (myIngredients.Count > index + 3)
        {
            ingredient = (GameObject)myIngredients[index + 3];
            LoadMarket(ingredient, k_image4, k_button4, k_text4, 4);
            k_panel4.SetActive(true);
        }
        else
        {
            k_panel4.SetActive(false);
        }
        marketScroll.SetActive(true);
        menuScroll.SetActive(false);
    }

    public void LoadAppetizers(int index)
    {
        MenuType = "Appetizers";
        GameObject food;

        if (GetComponent<FoodVariables>().Appetizers.Length > index + 0)
        {
            food =  GetComponent<FoodVariables>().Appetizers[index + 0];
            LoadMenu(food, m_button1, m_text1, m_image1, ingredient1_1, ingredient1_2, ingredient1_3, ingredient1_4);
            m_scroll1.SetActive(true);
        }
        else
        {
            m_scroll1.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 1)
        {
            food = GetComponent<FoodVariables>().Appetizers[index + 1];
            LoadMenu(food, m_button2, m_text2, m_image2, ingredient2_1, ingredient2_2, ingredient2_3, ingredient2_4);
            m_scroll2.SetActive(true);
        }
        else
        {
            m_scroll2.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 2)
        {
            food = GetComponent<FoodVariables>().Appetizers[index + 2];
            LoadMenu(food, m_button3, m_text3, m_image3, ingredient3_1, ingredient3_2, ingredient3_3, ingredient3_4);
            m_scroll3.SetActive(true);
        }
        else
        {
            m_scroll3.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Appetizers.Length > index + 3)
        {
            food = GetComponent<FoodVariables>().Appetizers[index + 3];
            LoadMenu(food, m_button4, m_text4, m_image4, ingredient4_1, ingredient4_2, ingredient4_3, ingredient4_4);
            m_scroll4.SetActive(true);
        }
        else
        {
            m_scroll4.SetActive(false);
        }
        marketScroll.SetActive(false);
        menuScroll.SetActive(true);
    }

    public void LoadEntrees(int index)
    {
        MenuType = "Entrees";
        GameObject food;

        if (GetComponent<FoodVariables>().Entrees.Length > index + 0)
        {
            food = GetComponent<FoodVariables>().Entrees[index + 0];
            LoadMenu(food, m_button1, m_text1, m_image1, ingredient1_1, ingredient1_2, ingredient1_3, ingredient1_4);
            m_scroll1.SetActive(true);
        }
        else
        {
            m_scroll1.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 1)
        {
            food = GetComponent<FoodVariables>().Entrees[index + 1];
            LoadMenu(food, m_button2, m_text2, m_image2, ingredient2_1, ingredient2_2, ingredient2_3, ingredient2_4);
            m_scroll2.SetActive(true);
        }
        else
        {
            m_scroll2.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 2)
        {
            food = GetComponent<FoodVariables>().Entrees[index + 2];
            LoadMenu(food, m_button3, m_text3, m_image3, ingredient3_1, ingredient3_2, ingredient3_3, ingredient3_4);
            m_scroll3.SetActive(true);
        }
        else
        {
            m_scroll3.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Entrees.Length > index + 3)
        {
            food = GetComponent<FoodVariables>().Entrees[index + 3];
            LoadMenu(food, m_button4, m_text4, m_image4, ingredient4_1, ingredient4_2, ingredient4_3, ingredient4_4);
            m_scroll4.SetActive(true);
        }
        else
        {
            m_scroll4.SetActive(false);
        }
        marketScroll.SetActive(false);
        menuScroll.SetActive(true);
    }

    public void LoadDesserts(int index)
    {
        MenuType = "Desserts";
        GameObject food;

        if (GetComponent<FoodVariables>().Desserts.Length > index + 0)
        {
            food = GetComponent<FoodVariables>().Desserts[index + 0];
            LoadMenu(food, m_button1, m_text1, m_image1, ingredient1_1, ingredient1_2, ingredient1_3, ingredient1_4);
            m_scroll1.SetActive(true);
        }
        else
        {
            m_scroll1.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 1)
        {
            food = GetComponent<FoodVariables>().Desserts[index + 1];
            LoadMenu(food, m_button2, m_text2, m_image2, ingredient2_1, ingredient2_2, ingredient2_3, ingredient2_4);
            m_scroll2.SetActive(true);
        }
        else
        {
            m_scroll2.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 2)
        {
            food = GetComponent<FoodVariables>().Desserts[index + 2];
            LoadMenu(food, m_button3, m_text3, m_image3, ingredient3_1, ingredient3_2, ingredient3_3, ingredient3_4);
            m_scroll3.SetActive(true);
        }
        else
        {
            m_scroll3.SetActive(false);
        }
        if (GetComponent<FoodVariables>().Desserts.Length > index + 3)
        {
            food = GetComponent<FoodVariables>().Desserts[index + 3];
            LoadMenu(food, m_button4, m_text4, m_image4, ingredient4_1, ingredient4_2, ingredient4_3, ingredient4_4);
            m_scroll4.SetActive(true);
        }
        else
        {
            m_scroll4.SetActive(false);
        }
        marketScroll.SetActive(false);
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
        else if (MenuType == "Market All")
        {
            if (GetComponent<FoodVariables>().GetAllIngredients().Count > menuScrollIndex + 4)
            {
                menuScrollIndex += 4;
                LoadMarket(menuScrollIndex);
            }
        }
        else if (MenuType == "Market Sale")
        {
            if(saleItems.Count > menuScrollIndex +4)
            {
                menuScrollIndex += 4;
                LoadSaleMarket(menuScrollIndex);
            }
        }
        else if (MenuType == "Ingredients")
        {
            if (myIngredients.Count > menuScrollIndex + 4)
            {
                menuScrollIndex += 4;
                LoadIngredients(menuScrollIndex);
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
        else if (MenuType == "Market All")
        {
            if (menuScrollIndex - 4 >= 0)
            {
                menuScrollIndex -= 4;
                LoadMarket(menuScrollIndex);
            }
        }
        else if (MenuType == "Market Sale")
        {
            if (menuScrollIndex - 4 >= 0)
            {
                menuScrollIndex -= 4;
                LoadSaleMarket(menuScrollIndex);
            }
        }
    }

    private void LoadMarket(GameObject ingredient, GameObject k_image, Button k_button, Text k_text, int flag)
    {
        if (ingredient.GetComponent<Ingredient>().image != null)
            k_image.GetComponent<Image>().sprite = ingredient.GetComponent<Ingredient>().image;
        else
            k_image.GetComponent<Image>().sprite = defaultIngredientSprite;
        k_image.GetComponent<Image>().color = Color.white;

        k_text.text = ingredient.ToString().Replace(" (UnityEngine.GameObject)", "");

        k_button.interactable = true;
        k_button.onClick.RemoveAllListeners();

        if (flag == 0)
        {
            //Sale Items
            k_text.color = Color.green;
            k_text.text += "\nSale : $" + ingredient.GetComponent<Ingredient>().GetSalePrice();

            k_button.onClick.AddListener(() => ShowIngredient(ingredient, 0));
        }
        else if (flag == 1)
        {
            //Market Items
            k_text.color = Color.black;
            k_text.text += "\n$" + ingredient.GetComponent<Ingredient>().marketPrice;

            k_button.onClick.AddListener(() => ShowIngredient(ingredient, 1));
        }
        else if (flag == 2)
        {
            //Rare Items
            k_text.color = Color.red;
            k_text.text += "\nRare : $" + ingredient.GetComponent<Ingredient>().GetRarePrice();

            k_button.onClick.AddListener(() => ShowIngredient(ingredient, 2));
        }
        else if (flag == 3)
        {
            //Out of Stock Items
            k_text.color = Color.black;
            k_text.text += "\nOut of Stock";
            k_image.GetComponent<Image>().color = faded;
            k_button.interactable = false;
        }
        else if (flag == 4)
        {
            //Load Ingredients Only
            k_text.text += "\n" + ingredient.GetComponent<Ingredient>().quatity + " in stock";

        }

    }

    private void LoadMenu(GameObject food, Button m_button, Text m_text, GameObject m_image, GameObject i1, GameObject i2, GameObject i3, GameObject i4)
    {
        m_button.onClick.RemoveAllListeners();
        m_button.onClick.AddListener(() => ShowFood(food));
        m_text.text = food.ToString().Replace(" (UnityEngine.GameObject)", "");
        if (food.GetComponent<Food>().level > 0)
            m_text.text += "\nLevel " + food.GetComponent<Food>().level;
        else
            m_text.text += "\n<Unlock>";

        //Food
        if (food.GetComponent<Food>().menuSprite != null)
            m_image.GetComponent<Image>().sprite = food.GetComponent<Food>().menuSprite;
        else
            m_image.GetComponent<Image>().sprite = defaultFoodSprite;

        //Ingredients
        try
        {
            if (food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image != null)
                i1.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().image;
            else
                i1.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[0].GetComponent<Ingredient>().quatity > 0)
                i1.GetComponent<Image>().color = Color.white;
            else
                i1.GetComponent<Image>().color = faded;
            i1.SetActive(true);
        }
        catch
        {
            i1.SetActive(false);
        }

        try
        {
            if (food.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image != null)
                i2.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().image;
            else
                i2.GetComponent<Image>().sprite = defaultIngredientSprite;
            if(food.GetComponent<Food>().recipe[1].GetComponent<Ingredient>().quatity > 0)
                i2.GetComponent<Image>().color = Color.white;
            else
                i2.GetComponent<Image>().color = faded;
            i2.SetActive(true);
        }
        catch
        {
            i2.SetActive(false);
        }

        try
        {
            if (food.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image != null)
                i3.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().image;
            else
                i3.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[2].GetComponent<Ingredient>().quatity > 0)
                i3.GetComponent<Image>().color = Color.white;
            else
                i3.GetComponent<Image>().color = faded;
            i3.SetActive(true);
        }
        catch
        {
            i3.SetActive(false);
        }

        try
        {
            if (food.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image != null)
                i4.GetComponent<Image>().sprite = food.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().image;
            else
                i4.GetComponent<Image>().sprite = defaultIngredientSprite;
            if (food.GetComponent<Food>().recipe[3].GetComponent<Ingredient>().quatity > 0)
                i4.GetComponent<Image>().color = Color.white;
            else
                i4.GetComponent<Image>().color = faded;
            i4.SetActive(true);
        }
        catch
        {
            i4.SetActive(false);
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

}
