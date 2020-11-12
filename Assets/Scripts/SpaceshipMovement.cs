using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceshipMovement : ScreenBorders
{
  
	[SerializeField] private float thrust = 1.0f;
	[SerializeField] private float torque = 1.0f;

	private float _thrustInput;
	private float _torqueInput;

  private Rigidbody2D rigidbody;

  private void Start()
  {
      rigidbody = gameObject.GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
  		BorderCheck();
  		_thrustInput = Input.GetAxis("Vertical");
  		_torqueInput = Input.GetAxis("Horizontal");
  }

  private void FixedUpdate()
  {
  		rigidbody.AddRelativeForce(Vector2.up * _thrustInput);
      rigidbody.AddTorque(-_torqueInput * torque);
  }   
}
