using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	[Header("Scene Transition")]
	public SceneFader sceneFader;

	[Header("Scene Names")]
	public string topicSelector;
	public string options;

	public GameObject exitPanel;
	public GameObject exitPanelClose;

	private void Start()
	{
		exitPanel.SetActive(false);
		exitPanelClose.SetActive(false);

        GameMaster.preloadedScene = false;
	}

	public void Play()
    {
        Debug.Log("Play...");
        sceneFader.FadeTo(topicSelector);
    }

	public void Quit()
	{
		exitPanel.SetActive(true);
		exitPanelClose.SetActive(false);
	}

	public void QuitYes()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

	public void QuitNo()
	{
		exitPanel.SetActive(false);
		exitPanelClose.SetActive(true);
	}

	public void Options()
	{
		sceneFader.FadeTo(options);
	}
}
