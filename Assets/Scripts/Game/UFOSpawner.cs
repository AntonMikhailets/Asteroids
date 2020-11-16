using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] UFOs = default;
    [SerializeField] private GameObject parent = default;

    private void Start()
    {
    	StartCoroutine(UFOSpawnCoroutine());
    }

    private void UFOSpawn()
    {
    	if(UFOs.Length > 0){
    		int randomValue = Random.Range(0, UFOs.Length);
    		GameObject newUFO = Instantiate (UFOs[randomValue], transform.position, transform.rotation);
			newUFO.transform.SetParent(parent.transform);
			SetUFOPosition(newUFO);
		}
    }

    private void SetUFOPosition(GameObject newUFO)
    {
    	Vector2 size = newUFO.GetComponent<RectTransform>().sizeDelta;
        Vector2 scale = newUFO.transform.localScale;
      	float x = (Screen.width + size.x*scale.x * 0.9f) * Mathf.Sign(Random.Range(-1,2)) * 0.5f ;
      	float y = Random.Range(-Screen.height * 0.4f, Screen.height * 0.4f);
      	newUFO.transform.localPosition = new Vector2(x,y);
    }

    private IEnumerator UFOSpawnCoroutine()
	{
		yield return new WaitForSeconds(60);
    	UFOSpawn();
    	StartCoroutine(UFOSpawnCoroutine());
    }
}
