using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private SpaceShipGun SpaceShipGun;

    private PolygonCollider2D collider;
    private Image image;
    private Rigidbody2D rigidbody;

    public delegate void SpaceshipHealth(int health);
    public static event SpaceshipHealth SetHealth;
    public delegate void SpaceshipDealth();
    public static event SpaceshipDealth SetDeath;

    private void Start()
    {
        collider = gameObject.GetComponent<PolygonCollider2D>();
        image = gameObject.GetComponent<Image>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire"))
        {
            SpaceShipGun.Fire();
        }
    }

    public void Death()
    {   
        collider.enabled = false;
        image.enabled = false;
        SetHealth(--health);

        if(health <= 0)
        {
            SetDeath();
        }else{
            Invoke("Respawn", 1f);
        }
    }

    private void Respawn()
    {
        rigidbody.velocity = Vector2.zero;
        transform.localPosition = Vector2.zero;
        collider.enabled = true;
        image.enabled = true;
    }
}
