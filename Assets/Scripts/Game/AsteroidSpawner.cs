using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	[SerializeField] private GameObject GameUI = default;
    [SerializeField] private GameObject[] Asteroids = default;
    [SerializeField] private int asteroidsValue = 3;
    [SerializeField] private List<GameObject> _asteroidsInScene = default;
    [SerializeField] private UFOSpawner UFOSpawner;

    private void Start()
    {
    	SpawnAsteroids();
        Asteroid.Created += AddAsteroidInList;
        Asteroid.Crashed += RemoveAsteroidFromList;
        //UFO.Created += AddAsteroidInList;
       // UFO.Crashed += RemoveAsteroidFromList;   
    }

    public void SpawnAsteroids()
    {
    	asteroidsValue++;
    	for(int i = 0; i < asteroidsValue; i++)
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
       Invoke("UFOSpawnCheck", 0.5f);
       Invoke("RestartCheck", 0.5f);
    }

    private void UFOSpawnCheck()
    {
    	if(_asteroidsInScene.Count == 2)
        {
           UFOSpawner.UFOSpawn();
        } 
    }

    private void RestartCheck()
    {
    	if(_asteroidsInScene.Count == 0)
        {
            Invoke("SpawnAsteroids", 2f);
        }
    }
}
