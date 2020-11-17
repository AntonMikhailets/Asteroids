using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(PolygonCollider2D))]
public class UFO : FlyingObject, ISpaceship
{
	[SerializeField] private float horizontalThrust;
	[SerializeField] private float verticalThrust = 0;
	[SerializeField] private UFOGun UFOGun = default;
	[SerializeField] private GameObject deathParticle = default;

	private Vector2 _thrust;
	private Rigidbody2D _rigidbody;
	private float nowVerticalThrust;

    private void Start()
    {
    	_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    	SetBordersAndPrivateObjects();
    	StartCoroutine(HorizontalMooving());
    	StartCoroutine(Shooting());
    	horizontalThrust = Mathf.Sign(-transform.localPosition.x)*horizontalThrust;
    }

    public void Shoot()
    {
        UFOGun.Shoot();
    }

    public void Crash()
    {
   		GameObject particle = Instantiate (deathParticle, transform.position, transform.rotation);
      particle.gameObject.transform.SetParent(gameObject.transform);
      gameObject.GetComponent<PolygonCollider2D>().enabled = false;
      gameObject.GetComponent<Image>().enabled = false;
      UFOGun.enabled = false;
   		Destroy(gameObject, 0.5f);
    }

    public override void HorizontalBorder()
    {
    	Destroy(gameObject);
    }

    private void FixedUpdate()
  	{
  		_thrust = new Vector2(horizontalThrust, nowVerticalThrust);
  		_rigidbody.AddForce(_thrust);
  	}

    private IEnumerator HorizontalMooving()
    {
    	yield return new WaitForSeconds(2f);
    	nowVerticalThrust = verticalThrust*Random.Range(-1f,2f);
    	yield return new WaitForSeconds(1);
		nowVerticalThrust = 0;
		StartCoroutine(HorizontalMooving());
    }

    private IEnumerator Shooting()
    {
    	yield return new WaitForSeconds(1f);
      Shoot();
    	StartCoroutine(Shooting());
    }

    private void OnTriggerEnter2D(Collider2D other)
   	{
   		if(other.tag == "Spaceship" || other.tag == "Asteroid")
   		{
   			other.gameObject.SendMessage("Crash");
   		}
   	}
}
