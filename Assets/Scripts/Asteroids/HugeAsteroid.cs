using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class HugeAsteroid : SmallAsteroid
{
	[SerializeField] private GameObject midleAstreroid;

   	public override void SpawnAsteroids()
   	{	
   		Instantiate (midleAstreroid, transform.position, transform.rotation);
   		Instantiate (midleAstreroid, transform.position, transform.rotation);
   		Destroy(gameObject);
   	}
 }
