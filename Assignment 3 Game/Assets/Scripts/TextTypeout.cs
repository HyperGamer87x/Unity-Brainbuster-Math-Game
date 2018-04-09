using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTypeout : MonoBehaviour {

    [Header("Text")]
    private float letterPaused = 0.01f;
    public static int textNumber;
    public static bool showText;
    private string message;
    public Text displayedText;
    public GameObject textPanelGO;
    public GameObject textGO;

    [Header("Others")]
    public static bool accessButtons;
    public static bool tutorialInProgress;
    public AudioSource textSound;

    void Start()
    {
        displayedText.text = "";
        accessButtons = false;
    }

    void Update()
    {
        if (tutorialInProgress == true)
        {
            textPanelGO.SetActive(true);
            textGO.SetActive(true);
        } else
        {
            textPanelGO.SetActive(false);
            textGO.SetActive(false);
        }

        if (showText == true)
        {
            displayedText.text = "";

            textPanelGO.SetActive(true);
            textGO.SetActive(true);

            if (textNumber == 1)
            {
                message = "Hello and welcome to BrainBuster! Would you like to hear the tutorial for this game?";
                displayedText.fontSize = 60;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 2)
            {
                message = "This is a very simple game about maths. The difficulty and types of questions asked will depend on your responses that you entered before the game began.";
                displayedText.fontSize = 50;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 3)
            {
                message = "Once you start the game, a question will display on the screen. You can answer this question by clicking one of the four buildings. The answers on the buildings will be displayed on the floor.";
                displayedText.fontSize = 50;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 4)
            {
                message = "If you get the answer correct, you'll move onto the next question, whilst if you get it wrong, you'll lose a live. Your lives counter is displayed in the top-left corner.";
                displayedText.fontSize = 50;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 5)
            {
                message = "The other number is for the points. These will help improve your final grade when you have completed all 15 questions. You can get a maximum of 3 points per question, depending on how many times you get the question incorrect!";
                displayedText.fontSize = 45;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 6)
            {
                message = "You also have a timer in the top-right corner. If this reaches 0, it's game over no matter how many lives you have, so be careful.";
                displayedText.fontSize = 60;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 7)
            {
                message = "Now that's all you need to know at the moment, so good luck!";
                displayedText.fontSize = 60;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 11)
            {
                message = "After every 3 questions, you'll get the chance to play a minigame. Do you want to know how to play this minigame?";
                displayedText.fontSize = 60;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 12)
            {
                message = "For this minigame, you will need to use the number keys at the top of your keyboard, the minus key (-) for negative answers, the enter/return key to submit your answer, and the (x) key to cancel your response.";
                displayedText.fontSize = 50;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 13)
            {
                message = "You will be given a randomly generated addition or subtraction question. You can use the input box to enter the correct answer.";
                displayedText.fontSize = 60;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 14)
            {
                message = "If you get the answer correct, the question will be extended, and you'll need to answer the new calculation. If you get it incorrect, you'll lose a few seconds, and time is crucial here!";
                displayedText.fontSize = 50;
                showText = false;
                StartCoroutine(TypeText());
            }
            if (textNumber == 15)
            {
                message = "You will get 2 seconds added to the countdown when you get a question correct. Points and lives can be earned in this minigame, so make sure you do good! You should now be ready to start the minigame, so let's begin!";
                displayedText.fontSize = 50;
                showText = false;
                StartCoroutine(TypeText());
            }
        }

        if (message == displayedText.text)
        {
            accessButtons = true;
        } else
        {
            accessButtons = false;
        }
        
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textSound.Play();
            displayedText.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused * Time.deltaTime);
        }

    }

}
