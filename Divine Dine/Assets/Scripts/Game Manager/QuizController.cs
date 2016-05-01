using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public GameObject[] quizzes;
    public int[] keys;
    public GameObject rewardMenu;
    public GameObject mailButton;

    public Color right;
    public Color wrong;

    private int selected;
    private bool correct;
    private bool answered;
    private bool tutorial;

    //Quizes
    private GameObject choice1;
    private GameObject choice2;
    private GameObject choice3;
    private GameObject choice4;
    private GameObject proceed;

    void Start()
    {
        mailButton.SetActive(false);
        rewardMenu.SetActive(false);

        rewardMenu.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => GetComponent<FoodVariables>().RandomPrize());
        rewardMenu.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => GetComponent<GlobalVariables>().AddMoney(500));
        rewardMenu.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => GetComponent<GlobalVariables>().AdvanceQuarterLevel());
    }

    public void Generate()
    {
        mailButton.SetActive(false);
        answered = false;
        selected = Random.Range(0, quizzes.Length);

        choice1 = quizzes[selected].transform.GetChild(1).gameObject;
        choice2 = quizzes[selected].transform.GetChild(2).gameObject;
        choice3 = quizzes[selected].transform.GetChild(3).gameObject;
        choice4 = quizzes[selected].transform.GetChild(4).gameObject;
        proceed = quizzes[selected].transform.GetChild(5).gameObject;

        choice1.GetComponent<Button>().GetComponent<Image>().color = Color.white;
        choice2.GetComponent<Button>().GetComponent<Image>().color = Color.white;
        choice3.GetComponent<Button>().GetComponent<Image>().color = Color.white;
        choice4.GetComponent<Button>().GetComponent<Image>().color = Color.white;

        choice1.GetComponent<Button>().onClick.RemoveAllListeners();
        choice2.GetComponent<Button>().onClick.RemoveAllListeners();
        choice3.GetComponent<Button>().onClick.RemoveAllListeners();
        choice4.GetComponent<Button>().onClick.RemoveAllListeners();

        choice1.GetComponent<Button>().onClick.AddListener(() => Answer1());
        choice2.GetComponent<Button>().onClick.AddListener(() => Answer2());
        choice3.GetComponent<Button>().onClick.AddListener(() => Answer3());
        choice4.GetComponent<Button>().onClick.AddListener(() => Answer4());

        proceed.GetComponent<Button>().onClick.RemoveAllListeners();
        proceed.GetComponent<Button>().onClick.AddListener(() => Exit());
        proceed.SetActive(false);

        quizzes[selected].SetActive(true);
    }

    public void Tutorial(bool set)
    {
        tutorial = set;
    }

    public void Answer1()
    {
        if(!answered)
        {
            answered = true;
            CheckAnswer(1);
            if (correct)
            {
                choice1.GetComponent<Button>().GetComponent<Image>().color = right;
            }
            else
            {
                choice1.GetComponent<Button>().GetComponent<Image>().color = wrong;
                ShowCorrect();
            }

            proceed.SetActive(true);
        }
    }

    public void Answer2()
    {
        if(!answered)
        {
            answered = true;
            CheckAnswer(2);
            if (correct)
            {
                choice2.GetComponent<Button>().GetComponent<Image>().color = right;
            }
            else
            {
                choice2.GetComponent<Button>().GetComponent<Image>().color = wrong;
                ShowCorrect();
            }

            proceed.SetActive(true);
        }
    }

    public void Answer3()
    {
        if(!answered)
        {
            answered = true;
            CheckAnswer(3);
            if (correct)
            {
                choice3.GetComponent<Button>().GetComponent<Image>().color = right;
            }
            else
            {
                choice3.GetComponent<Button>().GetComponent<Image>().color = wrong;
                ShowCorrect();
            }

            proceed.SetActive(true);
        }
    }

    public void Answer4()
    {
        if(!answered)
        {
            answered = true;
            CheckAnswer(4);
            if (correct)
            {
                choice4.GetComponent<Button>().GetComponent<Image>().color = right;
            }
            else
            {
                choice4.GetComponent<Button>().GetComponent<Image>().color = wrong;
                ShowCorrect();
            }
            proceed.SetActive(true);
        }
    }

    public void Exit()
    {
        if (correct)
        {
            rewardMenu.SetActive(true);
        }
        quizzes[selected].SetActive(false);

        if(tutorial)
        {
            GetComponent<TutorialController>().AcheivedTask(28);
        }
    }

    private void CheckAnswer(int ans)
    {
        if(ans == keys[selected])
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
    }

    private void ShowCorrect()
    {
        if(keys[selected] == 1)
        {
            choice1.GetComponent<Button>().GetComponent<Image>().color = right;
        }
        else if (keys[selected] == 2)
        {
            choice2.GetComponent<Button>().GetComponent<Image>().color = right;
        }
        else if (keys[selected] == 3)
        {
            choice3.GetComponent<Button>().GetComponent<Image>().color = right;
        }
        else if (keys[selected] == 4)
        {
            choice4.GetComponent<Button>().GetComponent<Image>().color = right;
        }
    }
}
