using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
	[SerializeField] private int score = 0;
  [SerializeField] private int health = 3;
  [SerializeField] private int asteroidsDestroyed;
  //[SerializeField] private int asteroidsInScene;
  [SerializeField] private HealthAndScoreUI healthAndScoreUI;

    private void Start()
    {
    	SmallAsteroid.AsteroidBroke += UpdateScore;
    	Spaceship.SetHealth += SetHealth;
    }

   	private void UpdateScore(int points)
   	{
   		score += points;
      if(healthAndScoreUI)
        healthAndScoreUI.Score = score;
	}

	private void SetHealth(int _health)
	{
		health = _health;
    if(healthAndScoreUI)
      healthAndScoreUI.Health = health;
	}
    
    private void CloseScene()
    {
    	SmallAsteroid.AsteroidBroke -= UpdateScore;
    	Spaceship.SetHealth -= SetHealth;
    }
}
