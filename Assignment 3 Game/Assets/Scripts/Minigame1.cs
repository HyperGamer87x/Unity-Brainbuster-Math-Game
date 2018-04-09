using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour {

    [Header("Scene Transition")]
    public SceneFader sceneFader;

    [Header("Scenes")]
    public string questions;

    [Header("Questions")]
    public Text questionText;
    public GameObject questionTextGO;
    private int randomFigure;
    private int randomSymbolGenerator;
    private string randomSymbolString;
    private int correctAnswer;
    private int originalCorrectAnswer;
    private int questionsAnswered;
    public Text questionsAnsweredTxt;

    [Header("Countdowns")]
    private float inGameCountdown;
    public Text inGameCountdownTxt;
    public Text startGameCountdownTxt;
    public GameObject startGameCountdownGO;
    private bool minigameInProgress;

    [Header("Animations")]
    public GameObject timer;
    private Quaternion timerRotation;
    private Vector3 timerRotationZ;
    private bool startTimerAnimation;

    [Header("Input")]
    public Button confirmInputBtn;
    public Text inputText;
    private bool enableUserInput;
    public GameObject incorrectInputPanel;

    [Header("Minigame Over")]
    public GameObject minigameOverPanel;
    public Text gradeTxt;
    public Text livesEarnedTxt;
    public Text pointsEarnedTxt;
    public Text questionsAnsweredOnPanel;
    private int livesEarned;
    private int pointsEarned;

    [Header("Tutorial Buttons")]
    public Button yesButton;
    public Button noButton;
    public Button nextButton;
    public GameObject yesButtonGO;
    public GameObject noButtonGO;
    public GameObject nextButtonGO;

    [Header("Tutorial Buttons")]
    public AudioSource soundtrack;

    private void Start()
    {
        inGameCountdown = 35.00F;
        startGameCountdownGO.SetActive(false);
        startGameCountdownTxt.text = "5";
        questionText.text = "What is 0 ";
        questionTextGO.SetActive(false);
        originalCorrectAnswer = 0;
        inputText.text = "";
        enableUserInput = false;
        minigameInProgress = false;
        startTimerAnimation = false;
        questionsAnswered = 0;
        incorrectInputPanel.SetActive(false);
        minigameOverPanel.SetActive(false);

        GameMaster.returnedFromMinigame = false;
        GameMaster.preloadedScene = true;

        TextTypeout.textNumber = 11;
        TextTypeout.showText = true;
        TextTypeout.tutorialInProgress = true;

        timerRotationZ.z = 0;

    }

    public void TutorialResponseNo()
    {
        TextTypeout.tutorialInProgress = false;
        StartCoroutine(StartGameCountdown());
    }

    public void TutorialResponseYes()
    {
        TextTypeout.showText = true;
        TextTypeout.textNumber = 12;
    }

    public void TutorialResponseNext()
    {
        if (TextTypeout.textNumber == 15)
        {
            TextTypeout.tutorialInProgress = false;
            StartCoroutine(StartGameCountdown());
        }
        else
        {
            TextTypeout.showText = true;
            TextTypeout.textNumber = TextTypeout.textNumber + 1;
        }

    }

    private void UpdateQuestion()
    {
        randomFigure = Random.Range(0, 31);
        randomSymbolGenerator = Random.Range(1, 6);

        if (randomSymbolGenerator == 1 || randomSymbolGenerator == 2 || randomSymbolGenerator == 3)
        {
            randomSymbolString = "+";
            correctAnswer = originalCorrectAnswer + randomFigure;
        }

        if (randomSymbolGenerator == 4 || randomSymbolGenerator == 5)
        {
            randomSymbolString = "-";
            correctAnswer = originalCorrectAnswer - randomFigure;
        }

        questionText.text = questionText.text + randomSymbolString + " " + randomFigure + " ";
        questionTextGO.SetActive(true);

        originalCorrectAnswer = correctAnswer;
        enableUserInput = true;
    }

    private void Update()
    {
        questionsAnsweredTxt.text = "Questions Answered = " + questionsAnswered.ToString();
        livesEarnedTxt.text = livesEarned.ToString();
        pointsEarnedTxt.text = pointsEarned.ToString();

        timerRotation = Quaternion.Euler(0f, 0f, timerRotationZ.z);
        timer.transform.rotation = timerRotation;
        inGameCountdownTxt.text = string.Format("{0:00.00}", inGameCountdown);

        if (startTimerAnimation == true)
        {
            StartCoroutine(SpinTimer());
        }

        inGameCountdownTxt.text = inGameCountdown.ToString();

        if (inGameCountdown <= 10)
        {
            inGameCountdownTxt.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
        }
        else
        {
            inGameCountdownTxt.color = new Color(255f, 255f, 255f); ;
        }

        if (inGameCountdown == 0)
        {
            enableUserInput = false;
            questionTextGO.SetActive(false);
            minigameInProgress = false;
            incorrectInputPanel.SetActive(false);

            if (questionsAnswered == 0)
            {
                gradeTxt.text = "U";
            }
            if (questionsAnswered >= 1 && questionsAnswered <= 3)
            {
                gradeTxt.text = "F";
            }
            if (questionsAnswered >= 4 && questionsAnswered <= 6)
            {
                gradeTxt.text = "E";
            }
            if (questionsAnswered >= 7 && questionsAnswered <= 9)
            {
                gradeTxt.text = "D";
            }
            if (questionsAnswered >= 10 && questionsAnswered <= 12)
            {
                gradeTxt.text = "C";
            }
            if (questionsAnswered >= 13 && questionsAnswered <= 15)
            {
                gradeTxt.text = "B";
            }
            if (questionsAnswered >= 16 && questionsAnswered <= 18)
            {
                gradeTxt.text = "A";
            }
            if (questionsAnswered >= 19)
            {
                gradeTxt.text = "A*";
            }

            StartCoroutine(FinishMinigame());
            inGameCountdown = 0.00001f;

            if (TextTypeout.tutorialInProgress == true)
            {
                if (TextTypeout.textNumber == 1)
                {
                    yesButtonGO.SetActive(true);
                    noButtonGO.SetActive(true);
                    nextButtonGO.SetActive(false);
                }
                if (TextTypeout.textNumber != 1)
                {
                    yesButtonGO.SetActive(false);
                    noButtonGO.SetActive(false);
                    nextButtonGO.SetActive(true);
                }

                if (TextTypeout.accessButtons == true)
                {
                    yesButton.interactable = true;
                    noButton.interactable = true;
                    nextButton.interactable = true;
                }
                else
                {
                    yesButton.interactable = false;
                    noButton.interactable = false;
                    nextButton.interactable = false;
                }
            }
            else
            {
                yesButtonGO.SetActive(false);
                noButtonGO.SetActive(false);
                nextButtonGO.SetActive(false);
            }
        }

        if (minigameInProgress == true)
        {
            inGameCountdown -= Time.deltaTime;
            inGameCountdown = Mathf.Clamp(inGameCountdown, 0f, Mathf.Infinity);
        }

        //Keys
        if (enableUserInput == true)
        {
            if (inputText.text.Length < 7)
            {
                if (Input.GetKeyDown("1"))
                {
                    inputText.text = inputText.text + "1";
                }
                if (Input.GetKeyDown("2"))
                {
                    inputText.text = inputText.text + "2";
                }
                if (Input.GetKeyDown("3"))
                {
                    inputText.text = inputText.text + "3";
                }
                if (Input.GetKeyDown("4"))
                {
                    inputText.text = inputText.text + "4";
                }
                if (Input.GetKeyDown("5"))
                {
                    inputText.text = inputText.text + "5";
                }
                if (Input.GetKeyDown("6"))
                {
                    inputText.text = inputText.text + "6";
                }
                if (Input.GetKeyDown("7"))
                {
                    inputText.text = inputText.text + "7";
                }
                if (Input.GetKeyDown("8"))
                {
                    inputText.text = inputText.text + "8";
                }
                if (Input.GetKeyDown("9"))
                {
                    inputText.text = inputText.text + "9";
                }
                if (Input.GetKeyDown("0"))
                {
                    inputText.text = inputText.text + "0";
                }
                if (Input.GetKeyDown("-"))
                {
                    if (inputText.text == "")
                    {
                        inputText.text = inputText.text + "-";
                    }
                }
            }
            
            if (Input.GetKeyDown("x"))
            {
                inputText.text = "";
            }

            if (Input.GetKeyDown("return"))
            {
                if (inputText.text == correctAnswer.ToString())
                {
                    Debug.Log("Correct");
                    inputText.text = "";
                    questionsAnswered = questionsAnswered + 1;
                    inGameCountdown = inGameCountdown + 2f;
                    UpdateQuestion();
                }
                else
                {
                    Debug.Log("Incorrect");
                    StartCoroutine(IncorrectAnswerInput());
                }
            }

            if (inputText.text == "")
            {
                confirmInputBtn.interactable = false;
            }
            else
            {
                confirmInputBtn.interactable = true;
            }

            if (questionsAnswered > 29)
            {
                inGameCountdown = 0;
            }

        }

        if (TextTypeout.tutorialInProgress == true)
        {
            if (TextTypeout.textNumber == 1 || TextTypeout.textNumber == 11)
            {
                yesButtonGO.SetActive(true);
                noButtonGO.SetActive(true);
                nextButtonGO.SetActive(false);
            }
            if (TextTypeout.textNumber != 1 && TextTypeout.textNumber != 11)
            {
                yesButtonGO.SetActive(false);
                noButtonGO.SetActive(false);
                nextButtonGO.SetActive(true);
            }

            if (TextTypeout.accessButtons == true)
            {
                yesButton.interactable = true;
                noButton.interactable = true;
                nextButton.interactable = true;
            }
            else
            {
                yesButton.interactable = false;
                noButton.interactable = false;
                nextButton.interactable = false;
            }
        }
        else
        {
            yesButtonGO.SetActive(false);
            noButtonGO.SetActive(false);
            nextButtonGO.SetActive(false);
        }

    }

    public void ConfirmInputButton()
    {
        if (inputText.text == correctAnswer.ToString())
        {
            Debug.Log("Correct");
            inputText.text = "";
            questionsAnswered = questionsAnswered + 1;
            inGameCountdown = inGameCountdown + 4f;
            UpdateQuestion();
        } else
        {
            Debug.Log("InCorrect");
            StartCoroutine(IncorrectAnswerInput());
        }
    }

    IEnumerator IncorrectAnswerInput()
    {
        enableUserInput = false;
        inputText.text = "";
        confirmInputBtn.interactable = false;
        incorrectInputPanel.SetActive(true);
        yield return new WaitForSeconds(6f);
        enableUserInput = true;
        incorrectInputPanel.SetActive(false);
    }

    IEnumerator SpinTimer()
    {
        if (minigameInProgress == true)
        {
            startTimerAnimation = false;

            timerRotationZ.z = timerRotationZ.z + 5;
            yield return new WaitForSeconds(0.05f);
            startTimerAnimation = true;
        }
    }

    IEnumerator StartGameCountdown()
    {
        soundtrack.Play();
        startGameCountdownGO.SetActive(true);
        yield return new WaitForSeconds(1f);
        startGameCountdownTxt.text = "4";
        yield return new WaitForSeconds(1f);
        startGameCountdownTxt.text = "3";
        yield return new WaitForSeconds(1f);
        startGameCountdownTxt.text = "2";
        yield return new WaitForSeconds(1f);
        startGameCountdownTxt.text = "1";
        yield return new WaitForSeconds(1f);
        startGameCountdownTxt.text = "GO GO GO!";
        yield return new WaitForSeconds(1f);
        startGameCountdownGO.SetActive(false);

        minigameInProgress = true;
        startTimerAnimation = true;
        UpdateQuestion();
    }

    IEnumerator FinishMinigame()
    {
        minigameOverPanel.SetActive(true);

        questionsAnsweredOnPanel.text = questionsAnswered.ToString();
        pointsEarned = questionsAnswered / 3;
        livesEarned = questionsAnswered / 10;

        GameMaster.livesRemaining = GameMaster.livesRemaining + livesEarned;
        GameMaster.points = GameMaster.points + pointsEarned;

        yield return new WaitForSeconds(23f);

        GameMaster.returnedFromMinigame = true;
        sceneFader.FadeTo(questions);

    }



}
