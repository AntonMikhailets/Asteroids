using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject GameUI;
    [SerializeField] private GameObject[] Asteroids;

    private void Start()
    {
    	SpawnAsteroids(5);
    }

    public void SpawnAsteroids(int quantity)
    {
    	for(int i = 0; i < quantity; i++)
    	{	
    		AsteroidSpawn();
    	}
    }

    private void AsteroidSpawn()
    {
    	int randomValue = Random.Range(0,Asteroids.Length-1);
    	GameObject newAsteroid = Instantiate (Asteroids[randomValue], transform.position, transform.rotation);

		newAsteroid.transform.SetParent(GameUI.transform);

		SetAsteroidPosition(newAsteroid);
    }

    private void SetAsteroidPosition(GameObject newAsteroid)
    {
    	Vector2 size = newAsteroid.GetComponent<RectTransform>().sizeDelta;
      	float y = Screen.height + size.y/2f;
      	float x = Random.Range(-Screen.width/2f, Screen.width/2f);

      	newAsteroid.transform.localPosition = new Vector2(x,y);
    }
}
