using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidShape : MonoBehaviour
{
    [SerializeField] private GameObject[] Asteroids = default;

    public GameObject SetAsteroidParameters()
    {
    	int randomValue = Random.Range(0, Asteroids.Length);
    	return Asteroids[randomValue];
    }
}
