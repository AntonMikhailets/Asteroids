using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpaceShipGun))]
[RequireComponent(typeof(SpaceshipEngine))]
public class Spaceship : MonoBehaviour, ISpaceship
{
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject DeathParticle  = default;

    public delegate void SpaceshipHealth(int health);
    public static event SpaceshipHealth SetHealth;
    public delegate void SpaceshipDealth();
    public static event SpaceshipDealth SetDeath;

    private SpaceShipGun _spaceShipGun;
    private SpaceshipEngine _spaceShipEngine;
    private PolygonCollider2D _collider;
    private Image _image;
    private Rigidbody2D _rigidbody;

    private void Start()
    {   
        _spaceShipGun = gameObject.GetComponent<SpaceShipGun>();
        _spaceShipEngine = gameObject.GetComponent<SpaceshipEngine>();
        _collider = gameObject.GetComponent<PolygonCollider2D>();
        _image = gameObject.GetComponent<Image>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire"))
        {
           Shoot();
        }
    }

    public void Shoot()
    {
         _spaceShipGun.Fire();
    }

    public void Crash()
    {   
        _collider.enabled = false;
        _image.enabled = false;
        _spaceShipEngine.enabled = false;
        SetHealth(--health);

        GameObject deathParticle = Instantiate (DeathParticle, transform.position, transform.rotation);
        deathParticle.gameObject.transform.SetParent(gameObject.transform);
        _spaceShipGun.enabled = false;
        Destroy(deathParticle,0.5f);

        if(health == 0)
        {
            SetDeath();
        }else{
            Invoke("Respawn", 1f);
        }
    }

    private void Respawn()
    {
        _rigidbody.velocity = Vector2.zero;
        _collider.enabled = true;
        _image.enabled = true;
        _spaceShipEngine.enabled = true;
        transform.localPosition = Vector2.zero;
         transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        if(health < 0) health = 0;
    }

    #endregion 
}
