using UnityEngine;

public class SpaceShipGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForce;  

    public void Fire()
    {
        GameObject newBullet = Instantiate (bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
        newBullet.gameObject.transform.SetParent(gameObject.transform);
    }

    #region MonoBehaviour

  	private void OnValidate()
  	{
      	if(bulletForce < 0) bulletForce = 0;
  	}

  	#endregion 
}
