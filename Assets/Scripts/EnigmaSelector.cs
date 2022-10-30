using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnigmaSelector : MonoBehaviour
{
    [SerializeField] EnigmasList list;
    [SerializeField] TMP_Text questionText;
    [SerializeField] List<TMP_Text> buttonTexts;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text BonusText1;
    [SerializeField] TMP_Text buttonText1;
    [SerializeField] Image bonusPanel1;
    [SerializeField] TMP_Text BonusText2;
    [SerializeField] TMP_Text buttonText2;
    [SerializeField] Image bonusPanel2;

    List<string> possibleAnswers = new List<string>();

    int index;
    int indexAnswers;
    int score;
    int highScore;
    bool isCorrectShowed;

    [SerializeField] int correctAnswerBonus;
    [SerializeField] int wrongAnswerBonus;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "EasyModeScene")
        {
            buttonText1.text = wrongAnswerBonus.ToString();
            buttonText2.text = correctAnswerBonus.ToString();
        }
        else
        {
            BonusText1.gameObject.SetActive(false);
            BonusText2.gameObject.SetActive(false);
            buttonText1.gameObject.SetActive(false);
            buttonText2.gameObject.SetActive(false);
            bonusPanel1.gameObject.SetActive(false);
            bonusPanel2.gameObject.SetActive(false);
        }



        if (list.enigmasList.Count <= 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            isCorrectShowed = false;
            scoreText.text = "Score: " + score.ToString();
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "High Score: " + highScore.ToString();
            index = Random.Range(0, list.enigmasList.Count);

            possibleAnswers.Add(list.enigmasList[index].AnswerCorrect);
            possibleAnswers.Add(list.enigmasList[index].AnswerWrong1);
            possibleAnswers.Add(list.enigmasList[index].AnswerWrong2);
            possibleAnswers.Add(list.enigmasList[index].AnswerWrong3);

            indexAnswers = Random.Range(0, possibleAnswers.Count);
            int indexButtons = 0;

            questionText.text = list.enigmasList[index].question;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.black;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
            indexAnswers = Random.Range(0, possibleAnswers.Count);
            indexButtons++;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.black;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
            indexAnswers = Random.Range(0, possibleAnswers.Count);
            indexButtons++;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.black;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
            indexAnswers = Random.Range(0, possibleAnswers.Count);
            indexButtons++;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.black;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
        }
    }

    public void OnClick(TMP_Text buttonText)
    {
        if (buttonText.text == list.enigmasList[index].AnswerCorrect)
        {
            list.enigmasList.Remove(list.enigmasList[index]);
            score += 5;
            scoreText.text = "Score: " + score.ToString();
            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = "High Score: " + highScore.ToString();
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            Start();
        }
        else
        {
            list.enigmasList.Remove(list.enigmasList[index]);
            Start();
        }
    }

    public void CorrectAnswerBonus()
    {
        if (correctAnswerBonus > 0)
        {
            for (int i = 0; i < buttonTexts.Count; i++)
            {
                if ((buttonTexts[i].text == list.enigmasList[index].AnswerCorrect) && (buttonTexts[i].color == Color.black))
                {
                    buttonTexts[i].color = Color.green;
                    correctAnswerBonus--;
                    buttonText2.text = correctAnswerBonus.ToString();
                    isCorrectShowed = true;
                    break;
                }
            }
        }
    }

    public void WrongAnswerBonus()
    {
        if (wrongAnswerBonus > 0 && isCorrectShowed == false)
        {
            for (int i = 0; i < buttonTexts.Count; i++)
            {
                if ((buttonTexts[i].text != list.enigmasList[index].AnswerCorrect) && (buttonTexts[i].color == Color.black))
                {
                    buttonTexts[i].color = Color.red;
                    wrongAnswerBonus--;
                    buttonText1.text = wrongAnswerBonus.ToString();
                    break;
                }
            }
        }
    }
}
