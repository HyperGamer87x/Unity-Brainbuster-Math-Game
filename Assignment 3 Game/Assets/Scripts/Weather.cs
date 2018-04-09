using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {

    [Header("Weather")]
    public ParticleSystem rainPS;
    public GameObject rainGO;
    public ParticleSystem snowPS;
    private int randomWeatherCondition;
    private bool canChangeWeather;

    [Header("Light")]
    public Light mainLight;

    [Header("Environment")]
    public GameObject grassGround;
    public GameObject snowGround;
    public GameObject trees;
    public GameObject snowyTrees;

    private void Start()
    {
        canChangeWeather = true;
    }
    private void Update()
    {
        if (canChangeWeather == true)
        {
            randomWeatherCondition = Random.Range(1, 4);

            if (randomWeatherCondition == 1)
            {
                rainPS.Stop();
                rainGO.SetActive(false);
                snowPS.Stop();
                grassGround.SetActive(true);
                snowGround.SetActive(false);
                trees.SetActive(true);
                snowyTrees.SetActive(false);
                mainLight.intensity = 1.2f;
                canChangeWeather = false;
            }

            if (randomWeatherCondition == 2)
            {
                rainPS.Play();
                rainGO.SetActive(true);
                snowPS.Stop();
                grassGround.SetActive(true);
                snowGround.SetActive(false);
                trees.SetActive(true);
                snowyTrees.SetActive(false);
                mainLight.intensity = 0.8f;
                canChangeWeather = false;
            }

            if (randomWeatherCondition == 3)
            {
                rainPS.Stop();
                rainGO.SetActive(false);
                snowPS.Play();
                grassGround.SetActive(false);
                snowGround.SetActive(true);
                trees.SetActive(false);
                snowyTrees.SetActive(true);
                mainLight.intensity = 1.2f;
                canChangeWeather = false;
            }
        }
        
    }
}
