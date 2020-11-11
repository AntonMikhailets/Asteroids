using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class SmallAsteroid : ScreenBorders
{
	public delegate void SetScorePoints(int points);
    public static event SetScorePoints AsteroidBroke;

	[SerializeField] private float maxThrust;
	[SerializeField] private float minThrust;
	[SerializeField] private float maxTorque;
	[SerializeField] private float minTorque;

	[SerializeField] private int scorePoints;  

	private Rigidbody2D rigidbody;

	private void Start()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		SetDirection();
	}

	private void SetDirection()
	{
		Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
		float torque = Random.Range(-maxTorque, maxTorque);

		rigidbody.AddForce(thrust);
		rigidbody.AddTorque(torque); 
	}

   	private void OnTriggerEnter2D(Collider2D other)
   	{
   		if(other.tag == "Spaceship")
   		{
   			other.gameObject.SendMessage("Death");
   		}
   	}

   	public void Break()
   	{
   		AsteroidBroke(scorePoints);
   		SpawnAsteroids();
   	}

   	public virtual void SpawnAsteroids()
   	{
   		Destroy(gameObject);
   	}
 }
