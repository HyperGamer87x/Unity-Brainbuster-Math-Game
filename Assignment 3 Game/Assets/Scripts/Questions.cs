using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour {


    [Header("Scene Transition")]
    public SceneFader sceneFader;

    [Header("Scenes")]
    public string minigame1;

    [Header("Question Data Ints")]
    private int numberAInt;
    private int numberBInt;

    [Header("Question Data Floats")]
    private float numberAFloat;
    private float numberBFloat;

    [Header("Answer Data Ints")]
    private int correctAnswerInt;
    private int incorrectAnswer1Int;
    private int incorrectAnswer2Int;
    private int incorrectAnswer3Int;
    private string correctLetter;
    private int randomiseChoicesInt;

    [Header("Answer Data Floats")]
    private float correctAnswerFloat;
    private float incorrectAnswer1Float;
    private float incorrectAnswer2Float;
    private float incorrectAnswer3Float;
    private float randomiseChoicesFloat;

    [Header("Text Objects")]
    public Text questiontxt;
    public Text answerAtxt;
    public Text answerBtxt;
    public Text answerCtxt;
    public Text answerDtxt;

    [Header("Game Objects")]
    public GameObject questionGO;
    public GameObject answerAGO;
    public GameObject answerBGO;
    public GameObject answerCGO;
    public GameObject answerDGO;

    [Header("Animations")]
    public Light lampA1;
    public Light lampA2;
    public Light lampB1;
    public Light lampB2;
    public Light lampC1;
    public Light lampC2;
    public Light lampD1;
    public Light lampD2;
    private bool startLampAnimations;
    private bool startTimerAnimation;
    public GameObject timer;
    private Quaternion timerRotation;
    private Vector3 timerRotationZ;

    [Header("Timer")]
    private int randomTimeLimit;
    public Text timerText;
    private bool forceTimerToStop;

    [Header("Questions")]
    private bool startNextQuestion;
    public Text questionNumberText;
    private int nextQuestionNumber;
    public static bool endTheQuestion;
    private int incorrectAnswers;
    private int correctAnswers;

    [Header("Cameras")]
    public GameObject gameCamera;
    public GameObject cameraA;
    public GameObject cameraB;
    public GameObject cameraC;
    public GameObject cameraD;

    [Header("Ticks & Crosses")]
    public GameObject tickA;
    public GameObject tickB;
    public GameObject tickC;
    public GameObject tickD;
    public GameObject crossA;
    public GameObject crossB;
    public GameObject crossC;
    public GameObject crossD;

    [Header("Answer Buttons")]
    public Button answerABtn;
    public Button answerBBtn;
    public Button answerCBtn;
    public Button answerDBtn;

    [Header("Audio Files")]
    public AudioSource soundtrack;

    [Header("Points Animation")]
    public GameObject points1;
    public GameObject points2;
    public GameObject points3;

    [Header("Tutorial Buttons")]
    public Button yesButton;
    public Button noButton;
    public Button nextButton;
    public GameObject yesButtonGO;
    public GameObject noButtonGO;
    public GameObject nextButtonGO;

    [Header("End The Question")]
    public GameObject questionCompletedTextGO;
    public Text questionCompletedText;
    public GameObject raycastToBlockAnswers;
    private int loadMinigameText;    

    void Start () {

        if (GameMaster.preloadedScene == false)
        {
            GameMaster.countdown = 25f;

            GameMaster.livesRemaining = 3;
            GameMaster.points = 0;
            
            questionGO.SetActive(false);
            answerAGO.SetActive(false);
            answerBGO.SetActive(false);
            answerCGO.SetActive(false);
            answerDGO.SetActive(false);

            lampA1.intensity = 0;
            lampA2.intensity = 0;
            lampB1.intensity = 0;
            lampB2.intensity = 0;
            lampC1.intensity = 0;
            lampC2.intensity = 0;
            lampD1.intensity = 0;
            lampD2.intensity = 0;
            startLampAnimations = false;

            gameCamera.SetActive(true);
            cameraA.SetActive(false);
            cameraB.SetActive(false);
            cameraC.SetActive(false);
            cameraD.SetActive(false);

            tickA.SetActive(false);
            tickB.SetActive(false);
            tickC.SetActive(false);
            tickD.SetActive(false);
            crossA.SetActive(false);
            crossB.SetActive(false);
            crossC.SetActive(false);
            crossD.SetActive(false);

            answerABtn.interactable = false;
            answerBBtn.interactable = false;
            answerCBtn.interactable = false;
            answerDBtn.interactable = false;

            forceTimerToStop = false;

            startNextQuestion = false;
            endTheQuestion = false;
            GameMaster.questionNumber = 0;
            questionCompletedTextGO.SetActive(false);

            GameMaster.returnedFromMinigame = false;

            TextTypeout.textNumber = 1;
            TextTypeout.showText = true;
            TextTypeout.tutorialInProgress = true;

            incorrectAnswers = 0;
            correctAnswers = 0;

        }

        points1.SetActive(false);
        points2.SetActive(false);
        points3.SetActive(false);

    }

    public void TutorialResponseNo()
    {
        TextTypeout.tutorialInProgress = false;
        StartCoroutine(WaitToShowQuestion());
    }

    public void TutorialResponseYes()
    {
        TextTypeout.showText = true;
        TextTypeout.textNumber = 2;
    }

    public void TutorialResponseNext()
    {
        if (TextTypeout.textNumber == 7)
        {
            TextTypeout.tutorialInProgress = false;
            StartCoroutine(WaitToShowQuestion());
        } else
        {
            TextTypeout.showText = true;
            TextTypeout.textNumber = TextTypeout.textNumber + 1;
        }
        
    }

    public void AdditionQuestion()
    {
        if (TopicSelector.chosenYear == 7)
        {
            numberAInt = Random.Range(0, 51);
            numberBInt = Random.Range(0, 51);
        }
        if (TopicSelector.chosenYear == 8)
        {
            numberAInt = Random.Range(0, 101);
            numberBInt = Random.Range(0, 101);
        }
        if (TopicSelector.chosenYear == 9)
        {
            numberAInt = Random.Range(0, 151);
            numberBInt = Random.Range(0, 151);
        }
        if (TopicSelector.chosenYear == 10)
        {
            numberAInt = Random.Range(0, 201);
            numberBInt = Random.Range(0, 201);
        }
        if (TopicSelector.chosenYear == 11)
        {
            numberAInt = Random.Range(0, 251);
            numberBInt = Random.Range(0, 251);
        }

        correctAnswerInt = numberAInt + numberBInt;
        incorrectAnswer1Int = (numberAInt + numberBInt) - Random.Range(1, 21);
        incorrectAnswer2Int = (numberAInt + numberBInt) + Random.Range(1, 21);
        incorrectAnswer3Int = (numberAInt + numberBInt) + Random.Range(1, 11);

        questiontxt.text = "What is " + numberAInt + " + " + numberBInt + "?";

        randomiseChoicesInt = Random.Range(1, 5);

        if (randomiseChoicesInt == 1)
        {
            correctLetter = "A";
            answerAtxt.text = correctAnswerInt.ToString();
            answerBtxt.text = incorrectAnswer1Int.ToString();
            answerCtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 2)
        {
            correctLetter = "B";
            answerBtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerCtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 3)
        {
            correctLetter = "C";
            answerCtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerBtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 4)
        {
            correctLetter = "D";
            answerDtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerBtxt.text = incorrectAnswer2Int.ToString();
            answerCtxt.text = incorrectAnswer3Int.ToString();
        }

    }

    public void SubtractionQuestion()
    {
        if (TopicSelector.chosenYear == 7)
        {
            numberAInt = Random.Range(0, 51);
            numberBInt = Random.Range(0, 51);
        }
        if (TopicSelector.chosenYear == 8)
        {
            numberAInt = Random.Range(0, 101);
            numberBInt = Random.Range(0, 101);
        }
        if (TopicSelector.chosenYear == 9)
        {
            numberAInt = Random.Range(0, 151);
            numberBInt = Random.Range(0, 151);
        }
        if (TopicSelector.chosenYear == 10)
        {
            numberAInt = Random.Range(0, 201);
            numberBInt = Random.Range(0, 201);
        }
        if (TopicSelector.chosenYear == 11)
        {
            numberAInt = Random.Range(0, 251);
            numberBInt = Random.Range(0, 251);
        }

        correctAnswerInt = numberAInt - numberBInt;
        incorrectAnswer1Int = (numberAInt - numberBInt) - Random.Range(1, 21);
        incorrectAnswer2Int = (numberAInt - numberBInt) + Random.Range(1, 21);
        incorrectAnswer3Int = (numberAInt - numberBInt) + Random.Range(1, 11);

        questiontxt.text = "What is " + numberAInt + " - " + numberBInt + "?";

        randomiseChoicesInt = Random.Range(1, 5);

        if (randomiseChoicesInt == 1)
        {
            correctLetter = "A";
            answerAtxt.text = correctAnswerInt.ToString();
            answerBtxt.text = incorrectAnswer1Int.ToString();
            answerCtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 2)
        {
            correctLetter = "B";
            answerBtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerCtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 3)
        {
            correctLetter = "C";
            answerCtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerBtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 4)
        {
            correctLetter = "D";
            answerDtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerBtxt.text = incorrectAnswer2Int.ToString();
            answerCtxt.text = incorrectAnswer3Int.ToString();
        }

    }

    public void MultiplicationQuestion()
    {
        numberAInt = Random.Range(0, 16);
        numberBInt = Random.Range(0, 16);
        
        correctAnswerInt = numberAInt * numberBInt;
        incorrectAnswer1Int = (numberAInt * numberBInt) - Random.Range(1, 21);
        incorrectAnswer2Int = (numberAInt * numberBInt) + Random.Range(1, 21);
        incorrectAnswer3Int = (numberAInt * numberBInt) + Random.Range(1, 11);

        questiontxt.text = "What is " + numberAInt + " x " + numberBInt + "?";

        randomiseChoicesInt = Random.Range(1, 5);

        if (randomiseChoicesInt == 1)
        {
            correctLetter = "A";
            answerAtxt.text = correctAnswerInt.ToString();
            answerBtxt.text = incorrectAnswer1Int.ToString();
            answerCtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 2)
        {
            correctLetter = "B";
            answerBtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerCtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 3)
        {
            correctLetter = "C";
            answerCtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerBtxt.text = incorrectAnswer2Int.ToString();
            answerDtxt.text = incorrectAnswer3Int.ToString();
        }
        if (randomiseChoicesInt == 4)
        {
            correctLetter = "D";
            answerDtxt.text = correctAnswerInt.ToString();
            answerAtxt.text = incorrectAnswer1Int.ToString();
            answerBtxt.text = incorrectAnswer2Int.ToString();
            answerCtxt.text = incorrectAnswer3Int.ToString();
        }

    }

    public void DivisionQuestion()
    {
        if (TopicSelector.chosenYear == 7)
        {
            numberAFloat = Random.Range(15, 51);
            numberBFloat = Random.Range(1, 16);
        }
        if (TopicSelector.chosenYear == 8)
        {
            numberAFloat = Random.Range(15, 101);
            numberBFloat = Random.Range(1, 16);
        }
        if (TopicSelector.chosenYear == 9)
        {
            numberAFloat = Random.Range(15, 151);
            numberBFloat = Random.Range(1, 16);
        }
        if (TopicSelector.chosenYear == 10)
        {
            numberAFloat = Random.Range(15, 201);
            numberBFloat = Random.Range(1, 16);
        }
        if (TopicSelector.chosenYear == 11)
        {
            numberAFloat = Random.Range(15, 251);
            numberBFloat = Random.Range(1, 16);
        }

        correctAnswerFloat = numberAFloat / numberBFloat;
        incorrectAnswer1Float = (numberAFloat / numberBFloat) - Random.Range(1f, 10f);
        incorrectAnswer2Float = (numberAFloat / numberBFloat) + Random.Range(1f, 10f);
        incorrectAnswer3Float = (numberAFloat / numberBFloat) + Random.Range(1f, 10f);

        questiontxt.text = "What is " + numberAFloat + " ÷ " + numberBFloat + "?";

        randomiseChoicesFloat = Random.Range(1, 5);

        if (randomiseChoicesFloat == 1)
        {
            correctLetter = "A";
            answerAtxt.text = correctAnswerFloat.ToString();
            answerBtxt.text = incorrectAnswer1Float.ToString();
            answerCtxt.text = incorrectAnswer2Float.ToString();
            answerDtxt.text = incorrectAnswer3Float.ToString();
        }
        if (randomiseChoicesFloat == 2)
        {
            correctLetter = "B";
            answerBtxt.text = correctAnswerFloat.ToString();
            answerAtxt.text = incorrectAnswer1Float.ToString();
            answerCtxt.text = incorrectAnswer2Float.ToString();
            answerDtxt.text = incorrectAnswer3Float.ToString();
        }
        if (randomiseChoicesFloat == 3)
        {
            correctLetter = "C";
            answerCtxt.text = correctAnswerFloat.ToString();
            answerAtxt.text = incorrectAnswer1Float.ToString();
            answerBtxt.text = incorrectAnswer2Float.ToString();
            answerDtxt.text = incorrectAnswer3Float.ToString();
        }
        if (randomiseChoicesFloat == 4)
        {
            correctLetter = "D";
            answerDtxt.text = correctAnswerFloat.ToString();
            answerAtxt.text = incorrectAnswer1Float.ToString();
            answerBtxt.text = incorrectAnswer2Float.ToString();
            answerCtxt.text = incorrectAnswer3Float.ToString();
        }

    }

    IEnumerator WaitToShowQuestion()
    {
        if (GameOver.gameOver == false)
        {
            soundtrack.Play();
            GameMaster.questionNumber = GameMaster.questionNumber + 1;

            randomTimeLimit = Random.Range(20, 31);
            GameMaster.countdown = randomTimeLimit;

            timerRotationZ.z = 0;
            endTheQuestion = false;
            forceTimerToStop = false;
            questionCompletedTextGO.SetActive(false);
            raycastToBlockAnswers.SetActive(true);
            yield return new WaitForSeconds(4.5f);

            raycastToBlockAnswers.SetActive(false);

            GameMaster.pointsToBeAwarded = 3;
            startLampAnimations = true;
            startTimerAnimation = true;
            GameMaster.questionInProgress = true;

            questionGO.SetActive(true);
            answerAGO.SetActive(true);
            answerBGO.SetActive(true);
            answerCGO.SetActive(true);
            answerDGO.SetActive(true);

            answerABtn.interactable = true;
            answerBBtn.interactable = true;
            answerCBtn.interactable = true;
            answerDBtn.interactable = true;

            if (TopicSelector.chosenTopic == "Add")
            {
                AdditionQuestion();
            }
            if (TopicSelector.chosenTopic == "Sub")
            {
                SubtractionQuestion();
            }
            if (TopicSelector.chosenTopic == "Mul")
            {
                MultiplicationQuestion();
            }
            if (TopicSelector.chosenTopic == "Div")
            {
                DivisionQuestion();
            }
        }
    }

 
    private void Update()
    {
        questionNumberText.text = GameMaster.questionNumber.ToString();
        nextQuestionNumber = GameMaster.questionNumber + 1;

        timerRotation = Quaternion.Euler(0f, 0f, timerRotationZ.z);
        timer.transform.rotation = timerRotation;
        timerText.text = string.Format("{0:00.00}", GameMaster.countdown);

        if (GameMaster.countdown <= 10)
        {
            timerText.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
        }
        else
        {
            timerText.color = new Color(0, 0, 0); ;
        }

        if (GameMaster.questionInProgress == true && forceTimerToStop == false)
        {
            GameMaster.countdown -= Time.deltaTime;
            GameMaster.countdown = Mathf.Clamp(GameMaster.countdown, 0f, Mathf.Infinity);


        }

        if (startLampAnimations == true)
        {
            StartCoroutine(LightUpLamps());
        }

        if (startTimerAnimation == true)
        {
            StartCoroutine(SpinTimer());
        }

        if (endTheQuestion == true)
        {
            GameMaster.questionInProgress = false;
            questionGO.SetActive(false);
            answerAGO.SetActive(false);
            answerBGO.SetActive(false);
            answerCGO.SetActive(false);
            answerDGO.SetActive(false);
            tickA.SetActive(false);
            tickB.SetActive(false);
            tickC.SetActive(false);
            tickD.SetActive(false);
            crossA.SetActive(false);
            crossB.SetActive(false);
            crossC.SetActive(false);
            crossD.SetActive(false);
        }

        if (GameOver.gameOver == false)
        {
            if (GameMaster.countdown == 0 || GameMaster.livesRemaining == -1 && GameMaster.questionInProgress == true)
            {
                forceTimerToStop = true;
                GameMaster.questionInProgress = false;
                GameMaster.livesRemaining = 0;
                GameOver.gameOver = true;
            }
        } else
        {
            questionCompletedTextGO.SetActive(false);
        }
        
        if (GameMaster.returnedFromMinigame == true)
        {
            //GameMaster.questionNumber = 4;
            GameMaster.questionInProgress = false;
            GameMaster.countdown = 30;
            //GameMaster.questionNumber = GameMaster.questionNumber - 1;
            StartCoroutine(WaitToShowQuestion());
            GameMaster.returnedFromMinigame = false;
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
        } else
        {
            yesButtonGO.SetActive(false);
            noButtonGO.SetActive(false);
            nextButtonGO.SetActive(false);
        }

        

        
    }

    IEnumerator LightUpLamps()
    {
        if (GameOver.gameOver == false)
        {
            startLampAnimations = false;

            lampA1.intensity = 10;
            lampA1.intensity = 10;
            yield return new WaitForSeconds(0.5f);

            lampA1.intensity = 0;
            lampA2.intensity = 0;
            lampB1.intensity = 10;
            lampB2.intensity = 10;
            yield return new WaitForSeconds(0.5f);

            lampB1.intensity = 0;
            lampB2.intensity = 0;
            lampC1.intensity = 10;
            lampC2.intensity = 10;
            yield return new WaitForSeconds(0.5f);

            lampC1.intensity = 0;
            lampC2.intensity = 0;
            lampD1.intensity = 10;
            lampD2.intensity = 10;
            yield return new WaitForSeconds(0.5f);

            lampD1.intensity = 0;
            lampD2.intensity = 0;
            lampA1.intensity = 10;
            lampA2.intensity = 10;

            if (endTheQuestion == false)
            {
                startLampAnimations = true;
            }
        }
    }

    IEnumerator SpinTimer()
    {
        if (GameOver.gameOver == false && forceTimerToStop == false)
        {
            startTimerAnimation = false;

            timerRotationZ.z = timerRotationZ.z + 5;
            yield return new WaitForSeconds(0.05f);
            startTimerAnimation = true;
        }
    }

    public void AnswerA()
    {
        StartCoroutine(AnswerACamera());
        answerABtn.interactable = false;
    }
    public void AnswerB()
    {
        StartCoroutine(AnswerBCamera());
        answerBBtn.interactable = false;

    }
    public void AnswerC()
    {
        StartCoroutine(AnswerCCamera());
        answerCBtn.interactable = false;

    }
    public void AnswerD()
    {
        StartCoroutine(AnswerDCamera());
        answerDBtn.interactable = false;

    }

    IEnumerator AnswerACamera()
    {
        gameCamera.SetActive(false);
        cameraA.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        
        if (correctLetter == "A")
        {
            tickA.SetActive(true);
            forceTimerToStop = true;
            GameMaster.points = GameMaster.points + GameMaster.pointsToBeAwarded;
            correctAnswers = correctAnswers + 1;
            StartCoroutine(CollectPointsAnimation());
        } else
        {
            crossA.SetActive(true);
            GameMaster.livesRemaining = GameMaster.livesRemaining - 1;
            GameMaster.pointsToBeAwarded = GameMaster.pointsToBeAwarded - 1;
            incorrectAnswers = incorrectAnswers + 1;
        }

        yield return new WaitForSeconds(2f);

        gameCamera.SetActive(true);
        cameraA.SetActive(false);

        if (forceTimerToStop == true)
        {
            endTheQuestion = true;

            yield return new WaitForSeconds(1f);
            questionCompletedTextGO.SetActive(true);
            questionCompletedText.text = "WELL DONE!";
            yield return new WaitForSeconds(3f);
            
            if (GameMaster.questionNumber == 21)
            {
                questionCompletedText.text = "MISSION SUCCESS!";
                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
            }
            if (GameMaster.questionNumber == 3 || GameMaster.questionNumber == 6 || GameMaster.questionNumber == 9 || GameMaster.questionNumber == 12 || GameMaster.questionNumber == 15 || GameMaster.questionNumber == 18)
            {
                loadMinigameText = Random.Range(0, 7);
                
                if (loadMinigameText == 0 || loadMinigameText == 1)
                {
                    questionCompletedText.text = "LET'S TAKE A BREAK!";
                }
                if (loadMinigameText == 2)
                {
                    questionCompletedText.text = "PREPARE FOR THIS!";
                }
                if (loadMinigameText == 3)
                {
                    questionCompletedText.text = "WARNING: MINIGAME INCOMING!";
                }
                if (loadMinigameText == 4)
                {
                    questionCompletedText.text = "TIME TO GO!";
                }
                if(loadMinigameText == 5)
                {
                    questionCompletedText.text = "LET'S GET OUTTA HERE!";
                }
                if(loadMinigameText == 6)
                {
                    questionCompletedText.text = "WHAT'S UP NEXT?";
                }
                
                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
                sceneFader.FadeTo(minigame1);
            }
            else
            {
                questionCompletedText.text = "QUESTION " + nextQuestionNumber;
                yield return new WaitForSeconds(4f);
                soundtrack.Stop();
                StartCoroutine(WaitToShowQuestion());
            }
            
        }
    }
    IEnumerator AnswerBCamera()
    {
        gameCamera.SetActive(false);
        cameraB.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        if (correctLetter == "B")
        {
            tickB.SetActive(true);
            forceTimerToStop = true;
            GameMaster.points = GameMaster.points + GameMaster.pointsToBeAwarded;
            correctAnswers = correctAnswers + 1;
            StartCoroutine(CollectPointsAnimation());
        }
        else
        {
            crossB.SetActive(true);
            GameMaster.livesRemaining = GameMaster.livesRemaining - 1;
            GameMaster.pointsToBeAwarded = GameMaster.pointsToBeAwarded - 1;
            incorrectAnswers = incorrectAnswers + 1;
        }

        yield return new WaitForSeconds(2f);
        gameCamera.SetActive(true);
        cameraB.SetActive(false);

        if (forceTimerToStop == true)
        {
            endTheQuestion = true;

            yield return new WaitForSeconds(1f);
            questionCompletedTextGO.SetActive(true);
            questionCompletedText.text = "WELL DONE!";
            yield return new WaitForSeconds(3f);

            if (GameMaster.questionNumber == 21)
            {
                questionCompletedText.text = "MISSION SUCCESS!";
                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
            }
            if (GameMaster.questionNumber == 3 || GameMaster.questionNumber == 6 || GameMaster.questionNumber == 9 || GameMaster.questionNumber == 12 || GameMaster.questionNumber == 15 || GameMaster.questionNumber == 18)
            {
                loadMinigameText = Random.Range(0, 7);

                if (loadMinigameText == 0 || loadMinigameText == 1)
                {
                    questionCompletedText.text = "LET'S TAKE A BREAK!";
                }
                if (loadMinigameText == 2)
                {
                    questionCompletedText.text = "PREPARE FOR THIS!";
                }
                if (loadMinigameText == 3)
                {
                    questionCompletedText.text = "WARNING: MINIGAME INCOMING!";
                }
                if (loadMinigameText == 4)
                {
                    questionCompletedText.text = "TIME TO GO!";
                }
                if (loadMinigameText == 5)
                {
                    questionCompletedText.text = "LET'S GET OUTTA HERE!";
                }
                if (loadMinigameText == 6)
                {
                    questionCompletedText.text = "WHAT'S UP NEXT?";
                }

                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
                sceneFader.FadeTo(minigame1);
            }
            else
            {
                questionCompletedText.text = "QUESTION " + nextQuestionNumber;
                yield return new WaitForSeconds(4f);
                soundtrack.Stop();
                StartCoroutine(WaitToShowQuestion());
            }
        }
    }
    IEnumerator AnswerCCamera()
    {
        gameCamera.SetActive(false);
        cameraC.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        if (correctLetter == "C")
        {
            tickC.SetActive(true);
            forceTimerToStop = true;
            GameMaster.points = GameMaster.points + GameMaster.pointsToBeAwarded;
            correctAnswers = correctAnswers + 1;
            StartCoroutine(CollectPointsAnimation());
        }
        else
        {
            crossC.SetActive(true);
            GameMaster.livesRemaining = GameMaster.livesRemaining - 1;
            GameMaster.pointsToBeAwarded = GameMaster.pointsToBeAwarded - 1;
            incorrectAnswers = incorrectAnswers + 1;
        }

        yield return new WaitForSeconds(2f);
        gameCamera.SetActive(true);
        cameraC.SetActive(false);

        if (forceTimerToStop == true)
        {
            endTheQuestion = true;

            yield return new WaitForSeconds(1f);
            questionCompletedTextGO.SetActive(true);
            questionCompletedText.text = "WELL DONE!";
            yield return new WaitForSeconds(3f);

            if (GameMaster.questionNumber == 21)
            {
                questionCompletedText.text = "MISSION SUCCESS!";
                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
            }
            if (GameMaster.questionNumber == 3 || GameMaster.questionNumber == 6 || GameMaster.questionNumber == 9 || GameMaster.questionNumber == 12 || GameMaster.questionNumber == 15 || GameMaster.questionNumber == 18)
            {
                loadMinigameText = Random.Range(0, 7);

                if (loadMinigameText == 0 || loadMinigameText == 1)
                {
                    questionCompletedText.text = "LET'S TAKE A BREAK!";
                }
                if (loadMinigameText == 2)
                {
                    questionCompletedText.text = "PREPARE FOR THIS!";
                }
                if (loadMinigameText == 3)
                {
                    questionCompletedText.text = "WARNING: MINIGAME INCOMING!";
                }
                if (loadMinigameText == 4)
                {
                    questionCompletedText.text = "TIME TO GO!";
                }
                if (loadMinigameText == 5)
                {
                    questionCompletedText.text = "LET'S GET OUTTA HERE!";
                }
                if (loadMinigameText == 6)
                {
                    questionCompletedText.text = "WHAT'S UP NEXT?";
                }

                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
                sceneFader.FadeTo(minigame1);
            }
            else
            {
                questionCompletedText.text = "QUESTION " + nextQuestionNumber;
                yield return new WaitForSeconds(4f);
                soundtrack.Stop();
                StartCoroutine(WaitToShowQuestion());
            }
        }
    }
    IEnumerator AnswerDCamera()
    {
        gameCamera.SetActive(false);
        cameraD.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        if (correctLetter == "D")
        {
            tickD.SetActive(true);
            forceTimerToStop = true;
            GameMaster.points = GameMaster.points + GameMaster.pointsToBeAwarded;
            correctAnswers = correctAnswers + 1;
            StartCoroutine(CollectPointsAnimation());
        }
        else
        {
            crossD.SetActive(true);
            GameMaster.livesRemaining = GameMaster.livesRemaining - 1;
            GameMaster.pointsToBeAwarded = GameMaster.pointsToBeAwarded - 1;
            incorrectAnswers = incorrectAnswers + 1;
        }

        yield return new WaitForSeconds(2f);
        gameCamera.SetActive(true);
        cameraD.SetActive(false);

        if (forceTimerToStop == true)
        {
            endTheQuestion = true;

            yield return new WaitForSeconds(1f);
            questionCompletedTextGO.SetActive(true);
            questionCompletedText.text = "WELL DONE!";
            yield return new WaitForSeconds(3f);

            if (GameMaster.questionNumber == 21)
            {
                questionCompletedText.text = "MISSION SUCCESS!";
                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
            }
            if (GameMaster.questionNumber == 3 || GameMaster.questionNumber == 6 || GameMaster.questionNumber == 9 || GameMaster.questionNumber == 12 || GameMaster.questionNumber == 15 || GameMaster.questionNumber == 18)
            {
                loadMinigameText = Random.Range(0, 7);

                if (loadMinigameText == 0 || loadMinigameText == 1)
                {
                    questionCompletedText.text = "LET'S TAKE A BREAK!";
                }
                if (loadMinigameText == 2)
                {
                    questionCompletedText.text = "PREPARE FOR THIS!";
                }
                if (loadMinigameText == 3)
                {
                    questionCompletedText.text = "WARNING: MINIGAME INCOMING!";
                }
                if (loadMinigameText == 4)
                {
                    questionCompletedText.text = "TIME TO GO!";
                }
                if (loadMinigameText == 5)
                {
                    questionCompletedText.text = "LET'S GET OUTTA HERE!";
                }
                if (loadMinigameText == 6)
                {
                    questionCompletedText.text = "WHAT'S UP NEXT?";
                }

                yield return new WaitForSeconds(4f);
                GameMaster.questionInProgress = false;
                sceneFader.FadeTo(minigame1);
            }
            else
            {
                questionCompletedText.text = "QUESTION " + nextQuestionNumber;
                yield return new WaitForSeconds(4f);
                soundtrack.Stop();
                StartCoroutine(WaitToShowQuestion());
            }
        }
    }

    IEnumerator CollectPointsAnimation()
    {
        yield return new WaitForSeconds(1f);

        if (GameMaster.pointsToBeAwarded >= 1)
        {
            points1.SetActive(true);
        }
        yield return new WaitForSeconds(0.75f);

        if (GameMaster.pointsToBeAwarded >= 2)
        {
            points2.SetActive(true);
        }
        yield return new WaitForSeconds(0.75f);

        if (GameMaster.pointsToBeAwarded == 3)
        {
            points3.SetActive(true);
        }
        yield return new WaitForSeconds(3.5f);
        points1.SetActive(false);
        points2.SetActive(false);
        points3.SetActive(false);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
    }

}
