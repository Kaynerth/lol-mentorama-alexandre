using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnigmaSelector : MonoBehaviour
{
    [SerializeField] EnigmasList list;
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text buttonText1;
    [SerializeField] TMP_Text buttonText2;
    [SerializeField] TMP_Text buttonText3;
    [SerializeField] TMP_Text buttonText4;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    List<string> possibleAnswers = new List<string>();
    int index;
    int score;
    int highScore;

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        highScore = PlayerPrefs.GetInt("High Score", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
        index = Random.Range(0, list.enigmasList.Count);

        possibleAnswers.Add(list.enigmasList[index].AnswerCorrect);
        possibleAnswers.Add(list.enigmasList[index].AnswerWrong1);
        possibleAnswers.Add(list.enigmasList[index].AnswerWrong2);
        possibleAnswers.Add(list.enigmasList[index].AnswerWrong3);

        int indexAnswers = Random.Range(0, possibleAnswers.Count);

        questionText.text = list.enigmasList[index].question;

        buttonText1.text = possibleAnswers[indexAnswers];
        possibleAnswers.Remove(possibleAnswers[indexAnswers]);
        indexAnswers = Random.Range(0, possibleAnswers.Count);

        buttonText2.text = possibleAnswers[indexAnswers];
        possibleAnswers.Remove(possibleAnswers[indexAnswers]);
        indexAnswers = Random.Range(0, possibleAnswers.Count);

        buttonText3.text = possibleAnswers[indexAnswers];
        possibleAnswers.Remove(possibleAnswers[indexAnswers]);
        indexAnswers = Random.Range(0, possibleAnswers.Count);

        buttonText4.text = possibleAnswers[indexAnswers];
        possibleAnswers.Remove(possibleAnswers[indexAnswers]);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
