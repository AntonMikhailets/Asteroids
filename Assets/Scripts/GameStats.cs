using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
	[SerializeField] private int score = 0;
	[SerializeField] private int health = 3;

    private void Start()
    {
    	SmallAsteroid.AsteroidBroke += UpdateScore;
    	Spaceship.SpaceshipDeath += SetHealth;
    }

   	private void UpdateScore(int points)
   	{
   		score += points;
	}

	private void SetHealth()
	{
		health--;
	}
    
    private void CloseScene()
    {
    	SmallAsteroid.AsteroidBroke -= UpdateScore;
    	Spaceship.SpaceshipDeath -= SetHealth;;
    }
}
