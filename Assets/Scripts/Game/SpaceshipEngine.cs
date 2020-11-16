using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceshipEngine : FlyingObject
{
  [SerializeField] private float thrust;
	[SerializeField] private float torque;

	private float _thrustInput;
	private float _torqueInput;

  public override void Update()
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
      float x = Screen.width * 0.5f;
      float y = Screen.height * 0.5f;
      gameObject.transform.localPosition = new Vector2(Random.Range(-x,x), Random.Range(-y,y));
  }

  private void FixedUpdate()
  {
  		GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * _thrustInput * thrust);
      GetComponent<Rigidbody2D>().AddTorque(-_torqueInput * torque);
  }

  #region MonoBehaviour

  private void OnValidate()
  {
      if(thrust < 0) thrust = 0;
      if(torque < 0) torque = 0;
  }

  #endregion    
}
