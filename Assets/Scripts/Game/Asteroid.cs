using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Asteroid : FlyingObject, IAsteroid
{
	public int scorePoints;
	public delegate void SetScorePoints(int points);
  public static event SetScorePoints AsteroidBroke;

	[SerializeField] private float maxThrust;
	[SerializeField] private float minThrust;
	[SerializeField] private float maxTorque;
	[SerializeField] private float minTorque;
	[SerializeField] private bool separationAfterBreak;
	[SerializeField] private GameObject separationAstreroid;
	[SerializeField] private GameObject DeathParticle;  

	private Rigidbody2D rigidbody;

	private void Start()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		SetBordersAndPrivateObjects();
		SetDirection();

		GameObject canvas = GameObject.Find("/Canvas");
		gameObject.transform.SetParent(canvas.transform);
	}

	public void SetDirection()
	{
		Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
		float torque = Random.Range(-maxTorque, maxTorque);

		rigidbody.AddForce(thrust);
		rigidbody.AddTorque(torque); 
	}

   	private void OnTriggerEnter2D(Collider2D other)
   	{
   		if(other.tag == "Spaceship" || other.tag == "UFO")
   		{
   			Crash();
   			other.gameObject.SendMessage("Crash");
   		}
   	}

   	public void Collision(GameObject collisionObject)
   	{
   		collisionObject.SendMessage("Crash");
   	}

   	public void Crash()
   	{
   		AsteroidBroke(scorePoints);

   		if(separationAfterBreak)
   		{
   			for(int i =0; i < 2; i++)
   			{
   				GameObject newAsteroid = Instantiate (separationAstreroid, transform.position, transform.rotation);
          newAsteroid.transform.localScale = gameObject.transform.localScale * 0.5f;
          if(newAsteroid.transform.localScale.x == 0.25f) newAsteroid.GetComponent<Asteroid>().SeparationAfterBreak = false;
   			}
   		}

   		GameObject deathParticle = Instantiate (DeathParticle, transform.position, transform.rotation);
      deathParticle.gameObject.transform.SetParent(gameObject.transform);
      gameObject.GetComponent<PolygonCollider2D>().enabled = false;
      gameObject.GetComponent<Image>().enabled = false;
   		Destroy(gameObject, 0.5f);
   	}

    public bool SeparationAfterBreak
    {
      set{
        separationAfterBreak = value;
      }
    }
 }
