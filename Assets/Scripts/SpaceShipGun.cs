using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForce;  

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire"))
        {
        	GameObject newBullet = Instantiate (bullet, transform.position, transform.rotation);
        	newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
        }
    }
}
