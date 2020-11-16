using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject GameOverUI;
    
    private void Start()
    {
    	Pause();
    	GameUI.active = false;
		GameOverUI.active = false;
    	StartUI.active = true;
        Spaceship.SetDeath += GameOver;
    }

    private void Pause()
    {
    	Time.timeScale = 0.0f;
    }

    public void Play()
    {
    	GameUI.active = true;
    	if(StartUI.active) StartUI.active = false;
    	Time.timeScale = 1.0f;
    }

    private void GameOver()
    {
        if(GameUI)
    	   GameUI.active = false;
        if(GameOverUI)
		GameOverUI.active = true;
    }
}
