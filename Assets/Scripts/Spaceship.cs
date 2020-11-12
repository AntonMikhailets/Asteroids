using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	public delegate void SpaceshipHealth(int health);
    public static event SpaceshipHealth SetHealth;
    public delegate void SpaceshipDealth();
    public static event SpaceshipDealth SetDeath;
    //public static event SpaceshipHealth SpacehipDeath;

    [SerializeField] private int health = 3;

    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Shot()
    {
       
    }

    public void Death()
    {
        collider.enabled = false;
        renderer.enabled = false;
        SetHealth(--health);

        if(health <= 0)
        {
            SetDeath();
        }else{
            Invoke("Respawn",1f);
        }
    }

    private void Respawn()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        collider.enabled = true;
        renderer.enabled = true;
    }
}
