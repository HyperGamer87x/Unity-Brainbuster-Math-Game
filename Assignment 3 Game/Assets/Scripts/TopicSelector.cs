using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicSelector : MonoBehaviour {

	[Header("Scene Transition")]
	public SceneFader sceneFader;

	[Header("Difficulty Panel")]
	public Text topicText;
	public GameObject difficultyPanel;
	public GameObject difficultyPanelClose;

	[Header("Scene Names")]
	public string mainMenu;
    public string questions;

    [Header("Question Configuration")]
    public static string chosenTopic;
    public static int chosenYear;

    private void Start()
	{
		difficultyPanel.SetActive(false);
		difficultyPanelClose.SetActive(false);
        chosenTopic = "None";
	}

	public void Addition()
	{
		topicText.text = "ADDITION";
        chosenTopic = "Add";
        difficultyPanel.SetActive(true);
		difficultyPanelClose.SetActive(false);
	}

	public void Subtraction()
	{
		topicText.text = "SUBTRACTION";
        chosenTopic = "Sub";
        difficultyPanel.SetActive(true);
		difficultyPanelClose.SetActive(false);
	}

	public void Multiplication()
	{
        topicText.text = "MULTIPLICATION";
        chosenTopic = "Mul";
        difficultyPanel.SetActive(true);
		difficultyPanelClose.SetActive(false);
	}

	public void Division()
	{
        topicText.text = "DIVISION";
        chosenTopic = "Div";
        difficultyPanel.SetActive(true);
		difficultyPanelClose.SetActive(false);
	}

    public void Year7()
    {
        sceneFader.FadeTo(questions);
        chosenYear = 7;
    }

    public void Year8()
    {
        sceneFader.FadeTo(questions);
        chosenYear = 8;
    }

    public void Year9()
    {
        sceneFader.FadeTo(questions);
        chosenYear = 9;
    }

    public void Year10()
    {
        sceneFader.FadeTo(questions);
        chosenYear = 10;
    }

    public void Year11()
    {
        sceneFader.FadeTo(questions);
        chosenYear = 11;
    }

    public void ChangeTopic()
	{
		difficultyPanel.SetActive(false);
		difficultyPanelClose.SetActive(true);
	}

	public void MainMenu()
	{
		sceneFader.FadeTo(mainMenu);
	}

}
