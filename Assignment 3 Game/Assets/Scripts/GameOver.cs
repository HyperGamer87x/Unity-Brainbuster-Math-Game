using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [Header("Scene Transition")]
    public SceneFader sceneFader;

    [Header("Scene Names")]
    public string mainMenu;

    [Header("Game Over Variables")]
    public static bool gameOver;
    public GameObject gameOverGO;

    [Header("Results Variables")]
    public GameObject showResults;
    private string grade;
    public Text questionsAnsweredText;
    public Text pointsGainedText;
    public Text gradeAchievedText;

    private void Start()
    {
        gameOver = false;
        gameOverGO.SetActive(false);
        showResults.SetActive(false);
    }

    private void Update()
    {
        if (gameOver == true)
        {
            gameOverGO.SetActive(true);
            Questions.endTheQuestion = false;
        }
    }

    public void ReturnToMenu()
    {
        gameOver = false;
        Debug.Log("Play...");
        sceneFader.FadeTo(mainMenu);
    }

    public void ViewResultsButton()
    {
        StartCoroutine(ViewResults());
    }

    public void QuitGame()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }

    IEnumerator ViewResults()
    {
        if (GameMaster.questionNumber <= 3)
        {
            grade = "U";
        }
        if (GameMaster.questionNumber >= 4 || GameMaster.questionNumber <= 6)
        {
            grade = "F";
        }
        if (GameMaster.questionNumber >= 7 || GameMaster.questionNumber <= 9)
        {
            grade = "E";
        }
        if (GameMaster.questionNumber >= 10 || GameMaster.questionNumber <= 13)
        {
            grade = "D";
        }
        if (GameMaster.questionNumber >= 14 || GameMaster.questionNumber <= 17)
        {
            grade = "C";
        }
        if (GameMaster.questionNumber >= 18)
        {
            grade = "B";
        }

        showResults.SetActive(true);
        questionsAnsweredText.text = "You answered " + GameMaster.questionNumber + " questions!";
        pointsGainedText.text = "You gained " + GameMaster.points + " points!";

        gradeAchievedText.text = "Your overall grade is";
        yield return new WaitForSeconds(9.5f);
        gradeAchievedText.text = "Your overall grade is.";
        yield return new WaitForSeconds(1f);
        gradeAchievedText.text = "Your overall grade is..";
        yield return new WaitForSeconds(1f);
        gradeAchievedText.text = "Your overall grade is...";
        yield return new WaitForSeconds(4f);
        gradeAchievedText.text = "Your overall grade is " + grade;

        yield return new WaitForSeconds(6f);
        showResults.SetActive(false);
    }
}
