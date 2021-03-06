﻿using UnityEngine;
using UnityEngine.UI;

public class HealthAndScoreUI : MonoBehaviour
{
    [SerializeField] private Text scoreText = default;
    [SerializeField] private HealthUI HealthUI = default;
    private int _health;

    private void Start()
    {
    	Health = 3;
    }

    public int Score
    {
    	set{
    		scoreText.text = value.ToString();
    	}
    }

    public int Health
    {
    	set{
    		_health = value;
    		HealthUI.ShowHealth(value);
    	}
    }
}
