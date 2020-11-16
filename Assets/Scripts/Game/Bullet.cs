using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float liftime = 0;

    private void Start()
    {
    	Destroy(gameObject, liftime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
   		if(other.tag == "Asteroid" || other.tag == "UFO")
   		{
   			other.gameObject.SendMessage("Crash");
   			Destroy(gameObject);
   		}
    }
}
