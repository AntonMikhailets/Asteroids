using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	public delegate void SpaceshipState();
    public static event SpaceshipState SpaceshipDeath;

    private void Shot()
    {
        
    }

    public void Death()
    {
        Debug.Log("YouDead");
        SpaceshipDeath();
        Destroy(gameObject);
    }
}
