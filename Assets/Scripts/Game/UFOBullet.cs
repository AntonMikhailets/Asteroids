using UnityEngine;

public class UFOBullet : MonoBehaviour
{
    [SerializeField] private float liftime = 0;

    private void Start()
    {
    	Destroy(gameObject, liftime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
   		if(other.tag == "Spaceship" || other.tag == "Asteroid")
   		{
   			other.gameObject.SendMessage("Crash");
   			Destroy(gameObject);
   		}
    }
}
