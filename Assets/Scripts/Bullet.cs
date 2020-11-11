using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void Start()
    {
    	Destroy(gameObject, 0.8f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
   		if(other.tag == "Asteroid")
   		{
   			other.gameObject.SendMessage("Break");
   			Destroy(gameObject);
   		}
    }
}
