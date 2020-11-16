using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject GameUI;
    public GameObject[] AsteroidsScene;
    [SerializeField] private GameObject[] Asteroids;
    [SerializeField] private int asteroidsValue;

    private void Start()
    {
    	SpawnAsteroids(asteroidsValue);
    	StartCoroutine(SearchAsteroidsInScene());
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

    private IEnumerator SearchAsteroidsInScene()
	{
		yield return new WaitForSeconds(1);
    	AsteroidsScene = GameObject.FindGameObjectsWithTag("Asteroid");

    	if(AsteroidsScene.Length == 0)
    	{
    		yield return new WaitForSeconds(2);
    		SpawnAsteroids(++asteroidsValue);
    	}
    	StartCoroutine(SearchAsteroidsInScene());
    }
}
