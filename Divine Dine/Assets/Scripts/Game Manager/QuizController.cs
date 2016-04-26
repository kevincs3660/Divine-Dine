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
    }

    public void Generate()
    {
        mailButton.SetActive(false);
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
        proceed.SetActive(false);

        quizzes[selected].SetActive(true);
    }

    public void Answer1()
    {
        CheckAnswer(1);
        if(correct)
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

    public void Answer2()
    {
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

    public void Answer3()
    {
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

    public void Answer4()
    {
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

    public void Continue()
    {
        if (correct)
        {
            rewardMenu.SetActive(true);
        }
        quizzes[selected].SetActive(false);
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
