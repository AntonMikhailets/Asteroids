using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text scoreText = default;
    [SerializeField] private HealthUI HealthUI = default;

    public int ScoreText
    {
    	set{
    		scoreText.text = value.ToString();
    	}
    }

    public int Health
    {
    	set{
    		//_health = value;
    		HealthUI.ShowHealth(value);
    	}
    }
}
