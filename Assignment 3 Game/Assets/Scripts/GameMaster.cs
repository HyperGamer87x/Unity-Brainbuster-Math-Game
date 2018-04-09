using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    [Header("Scene Transition")]
    public SceneFader sceneFader;

    [Header("Scenes")]
    public string mainMenu;

    [Header("Pause Game")]
    public GameObject pausePanel;
    public static bool gamePaused;

    [Header("Lives")]
    public static int livesRemaining;
    public Text livesText;

    [Header("Points")]
    public static int points;
    public static int pointsToBeAwarded;
    public Text pointsText;

    [Header("Quesions")]
    public static bool questionInProgress;
    public static int questionNumber;
    public static float countdown;

    [Header("Switching Scenes")]
    public static bool returnedFromMinigame;
    public static bool preloadedScene;

    [Header("Audio")]
    public AudioSource tutorialSoundtrack;

    private void Start()
    {
        gamePaused = false;
        pausePanel.SetActive(false);

        if (TextTypeout.tutorialInProgress == true)
        {
            tutorialSoundtrack.Play();
        }
    }

    private void Update()
    {
        livesText.text = livesRemaining.ToString();
        pointsText.text = points.ToString();

        if (TextTypeout.tutorialInProgress == false)
        {
            tutorialSoundtrack.Stop();
        }

        if (Input.GetKeyDown("escape"))
        {
            if (gamePaused == true)
            {
                pausePanel.SetActive(false);
                AudioListener.pause = false;
                Time.timeScale = 1f;
                gamePaused = false;
            } else
            {
                pausePanel.SetActive(true);
                AudioListener.pause = true;
                Time.timeScale = 0f;
                gamePaused = true;
            }
        }

    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
    }

    public void Exit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
