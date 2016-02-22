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
    private int currentIndex;
    private string MenuType;

    void Awake()
    {
        mainMenu = mainCanvas.transform.GetChild(0).gameObject;
        shopScroll = mainCanvas.transform.GetChild(1).gameObject;
        menuScroll = mainCanvas.transform.GetChild(2).gameObject;
        addMenu = mainCanvas.transform.GetChild(3).gameObject;

        //Main Menu
        main1 = mainCanvas.transform.GetChild(0).gameObject;
        main2 = mainCanvas.transform.GetChild(1).gameObject;
        main3 = mainCanvas.transform.GetChild(2).gameObject;
        main4 = mainCanvas.transform.GetChild(3).gameObject;
        main5 = mainCanvas.transform.GetChild(4).gameObject;
        mainButton1 = main1.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton2 = main2.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton3 = main3.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton4 = main4.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainButton5 = main5.transform.GetChild(0).gameObject.GetComponent<Button>();
        mainText1 = mainButton1.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText2 = mainButton2.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText3 = mainButton3.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText4 = mainButton4.transform.GetChild(0).gameObject.GetComponent<Text>();
        mainText5 = mainButton5.transform.GetChild(0).gameObject.GetComponent<Text>();

        //Shop Scroll
        home = shopScroll.transform.GetChild(0).gameObject;
        homeButton = home.transform.GetChild(0).gameObject.GetComponent<Button>();
        homeText = homeButton.transform.GetChild(0).gameObject.GetComponent<Text>();
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
        s_text1 = s_button1.transform.GetChild(0).gameObject.GetComponent<Text>();
        s_text2 = s_button2.transform.GetChild(0).gameObject.GetComponent<Text>();
        s_text3 = s_button3.transform.GetChild(0).gameObject.GetComponent<Text>();
        s_text4 = s_button4.transform.GetChild(0).gameObject.GetComponent<Text>();

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
        m_text1 = m_button1.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text2 = m_button2.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text3 = m_button3.transform.GetChild(0).gameObject.GetComponent<Text>();
        m_text4 = m_button4.transform.GetChild(0).gameObject.GetComponent<Text>();

        //Add Menu
        addButton1 = addMenu.transform.GetChild(0).GetComponent<Button>();
        addButton2 = addMenu.transform.GetChild(1).GetComponent<Button>();
        addButton3 = addMenu.transform.GetChild(2).GetComponent<Button>();
        addButton4 = addMenu.transform.GetChild(3).GetComponent<Button>();
    }
}
