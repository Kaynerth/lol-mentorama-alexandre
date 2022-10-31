using System;
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

    [SerializeField] Image bonusText1;
    [SerializeField] TMP_Text buttonText1;
    [SerializeField] Image buttonImage1;
    [SerializeField] Button button1;
    [SerializeField] Image bonusPanel1;
    [SerializeField] Image bonusFrame1;

    [SerializeField] Image bonusText2;
    [SerializeField] TMP_Text buttonText2;
    [SerializeField] Image buttonImage2;
    [SerializeField] Button button2;
    [SerializeField] Image bonusPanel2;
    [SerializeField] Image bonusFrame2;

    [SerializeField] Image timerPanel;
    [SerializeField] Image timerFrame;
    [SerializeField] Image timerTextImage;
    [SerializeField] Image timerRoundDesign;
    [SerializeField] TMP_Text timerText;

    List<string> possibleAnswers = new List<string>();

    int index;
    int indexAnswers;
    int score;
    int highScore;
    bool isCorrectShowed;
    float timer;

    [SerializeField] int correctAnswerBonus;
    [SerializeField] int wrongAnswerBonus;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "EasyModeScene")
        {
            buttonText1.text = wrongAnswerBonus.ToString();
            buttonText2.text = correctAnswerBonus.ToString();
        }

        if (SceneManager.GetActiveScene().name == "HardModeScene")
        {
            timer = 30;
            timerText.text = Math.Floor(timer).ToString();
        }

        if (list.enigmasList.Count <= 0)
        {
            SceneManager.LoadScene("EndGameScene");
        }
        else
        {
            isCorrectShowed = false;
            scoreText.text = score.ToString();
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = highScore.ToString();
            index = UnityEngine.Random.Range(0, list.enigmasList.Count);

            possibleAnswers.Add(list.enigmasList[index].AnswerCorrect);
            possibleAnswers.Add(list.enigmasList[index].AnswerWrong1);
            possibleAnswers.Add(list.enigmasList[index].AnswerWrong2);
            possibleAnswers.Add(list.enigmasList[index].AnswerWrong3);

            indexAnswers = UnityEngine.Random.Range(0, possibleAnswers.Count);
            int indexButtons = 0;

            questionText.text = list.enigmasList[index].question;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.white;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
            indexAnswers = UnityEngine.Random.Range(0, possibleAnswers.Count);
            indexButtons++;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.white;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
            indexAnswers = UnityEngine.Random.Range(0, possibleAnswers.Count);
            indexButtons++;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.white;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
            indexAnswers = UnityEngine.Random.Range(0, possibleAnswers.Count);
            indexButtons++;

            buttonTexts[indexButtons].text = possibleAnswers[indexAnswers];
            buttonTexts[indexButtons].color = Color.white;
            possibleAnswers.Remove(possibleAnswers[indexAnswers]);
        }
    }

    private void Update()
    {
        if (correctAnswerBonus <= 0)
        {
            button2.interactable = false;
            buttonText2.gameObject.SetActive(false);
        }

        if (wrongAnswerBonus <= 0)
        {
            button1.interactable = false;
            buttonText1.gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "HardModeScene")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = Math.Floor(timer).ToString();

                if (timer <= 10)
                {
                    timerText.color = Color.red;
                }
            }
            else
            {
                timer = 0;
                list.enigmasList.Remove(list.enigmasList[index]);
                Start();
            }
        }
    }

    public void OnClick(TMP_Text buttonText)
    {
        if (buttonText.text == list.enigmasList[index].AnswerCorrect && SceneManager.GetActiveScene().name == "EasyModeScene")
        {
            list.enigmasList.Remove(list.enigmasList[index]);
            score += 5;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("Score", score);

            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = highScore.ToString();
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            Start();
        }
        else if (buttonText.text == list.enigmasList[index].AnswerCorrect && SceneManager.GetActiveScene().name == "HardModeScene")
        {
            list.enigmasList.Remove(list.enigmasList[index]);
            score += 10;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("Score", score);

            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = highScore.ToString();
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
                if ((buttonTexts[i].text == list.enigmasList[index].AnswerCorrect) && (buttonTexts[i].color == Color.white))
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
                if ((buttonTexts[i].text != list.enigmasList[index].AnswerCorrect) && (buttonTexts[i].color == Color.white))
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
