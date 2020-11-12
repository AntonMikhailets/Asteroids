using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class HugeAsteroid : SmallAsteroid
{
	[SerializeField] private GameObject midleAstreroid;

   	public override void Break()
   	{	
   		for(int i =0; i < 2; i++)
   		{
   			Instantiate (midleAstreroid, transform.position, transform.rotation);
   		}
   		
   		Destroy(gameObject);
   	}
 }
