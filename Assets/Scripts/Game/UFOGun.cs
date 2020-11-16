using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOGun : MonoBehaviour
{
    [SerializeField] GameObject bullet = default;
	[SerializeField] private float bulletForce = 0;
	[SerializeField] bool aimed = false;

	private Vector2 direction;

    public void Shoot()
    {	
    	if(!aimed)
    	{
        	GameObject newBullet = Instantiate (bullet, transform.position, transform.rotation);
        	direction = Random.insideUnitCircle.normalized;
        	newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(direction * bulletForce);
        	newBullet.gameObject.transform.SetParent(gameObject.transform);
    	}else{
    		GameObject player = GameObject.FindGameObjectWithTag("Spaceship");
    		GameObject newBullet = Instantiate (bullet, transform.position, transform.rotation);

    		Vector2 scatter = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
    		Vector2 playerposition = new Vector2(player.transform.position.x, player.transform.position.y);
    		Vector2 position = new Vector2(transform.position.x, transform.position.y);

    		direction = -(position - playerposition + scatter).normalized;
        	newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(direction * bulletForce);
        	newBullet.gameObject.transform.SetParent(gameObject.transform);
    	}
    }
}
