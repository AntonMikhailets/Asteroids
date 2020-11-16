using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
	[SerializeField] private int score = 0;
  [SerializeField] private int health = 3;
  [SerializeField] private int asteroidsDestroyed;
  [SerializeField] private HealthAndScoreUI healthAndScoreUI;

    private void Start()
    {
    	Asteroid.AsteroidBroke += UpdateScore;
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
    	Asteroid.AsteroidBroke -= UpdateScore;
    	Spaceship.SetHealth -= SetHealth;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        if(health < 0) health = 0;
        if(score < 0) score = 0;
        if(asteroidsDestroyed < 0) asteroidsDestroyed = 0;
    }

    #endregion 
}
