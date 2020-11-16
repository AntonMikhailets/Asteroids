using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject StartUI = default;
    [SerializeField] private GameObject GameUI = default;
    [SerializeField] private GameObject GameOverUI = default;
    
    private void Start()
    {
    	Pause();
    	GameUI.SetActive(false);
		GameOverUI.SetActive(false);
    	StartUI.SetActive(true);
        Spaceship.SetDeath += GameOver;
    }

    private void Pause()
    {
    	Time.timeScale = 0.0f;
    }

    public void Play()
    {
    	GameUI.SetActive(true);
    	if(StartUI.activeSelf ) 
            StartUI.SetActive(false);
    	Time.timeScale = 1.0f;
    }

    private void GameOver()
    {
        if(GameUI)
    	   GameUI.SetActive(false);
        if(GameOverUI)
		   GameOverUI.SetActive(true);
    }
}
