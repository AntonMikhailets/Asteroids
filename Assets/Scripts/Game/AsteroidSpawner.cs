using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject GameUI;
    [SerializeField] private GameObject[] Asteroids  = default;
    [SerializeField] private int asteroidsValue;
    [SerializeField] private List<GameObject> _asteroidsInScene = default;

    private void Start()
    {
    	SpawnAsteroids(asteroidsValue);
        Asteroid.Created += AddAsteroidInList;
        Asteroid.Crashed += RemoveAsteroidFromList;  
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
        Vector2 scale = newAsteroid.transform.localScale;
      	float y = Screen.height + size.y * scale.y * 0.5f;
      	float x = Random.Range(-Screen.width * scale.y * 0.5f, Screen.width * 0.5f);
      	newAsteroid.transform.localPosition = new Vector2(x,y);
    }

    private void AddAsteroidInList(GameObject newAsteroid)
    {
       _asteroidsInScene.Add(newAsteroid); 
    }

    private void RemoveAsteroidFromList(GameObject newAsteroid)
    {
       _asteroidsInScene.Remove(newAsteroid); 

       if(_asteroidsInScene.Count == 0)
       {
            SpawnAsteroids(++asteroidsValue);
       }
    }
}
