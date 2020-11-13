using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceshipMovement : FlyingObject
{
  
	[SerializeField] private float thrust = 1.0f;
	[SerializeField] private float torque = 1.0f;

	private float _thrustInput;
	private float _torqueInput;

  /*private Rigidbody2D rigidbody;

  private void Start()
  {
      rigidbody = gameObject.GetComponent<Rigidbody2D>();
  }*/

  private void Update()
  {
  		BorderCheck();
  		_thrustInput = Input.GetAxis("Up");
  		_torqueInput = Input.GetAxis("Horizontal");

      if(Input.GetButtonDown("Teleportation"))
        {
          Teleportation();
        }
    }

    private void Teleportation()
    {
      float x = Screen.width/2f;
      float y = Screen.height/2f;
      gameObject.transform.localPosition = new Vector2(Random.Range(-x,x), Random.Range(-y,y));
    }

  private void FixedUpdate()
  {
  		GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * _thrustInput * thrust);
      GetComponent<Rigidbody2D>().AddTorque(-_torqueInput * torque);
  }   
}
