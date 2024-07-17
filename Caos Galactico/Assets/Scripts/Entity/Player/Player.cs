using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [Header("Parameters")]
    [SerializeField] float _speedMovement;
    [Header("Bullet")]
    [SerializeField] PlayerBullet _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] float _fireRate;
    [SerializeField] float _damage;
    float _timer;
    [SerializeField] int _health = 3;

    Factory<PlayerBullet> _factory;
    ObjectPool<PlayerBullet> _objectPool;

    PlayerInputs _inputs;

    public float Damage { get { return _damage; } set { _damage = value; } }
    public int Health { get { return _health; } set { _health = value; } }

    private void Start()
    {
        _inputs = new PlayerInputs(this);

        _factory = new PlayerBulletFactory(_bulletPrefab);
        _objectPool = new ObjectPool<PlayerBullet>(_factory.GetObj, PlayerBullet.TurnOff, PlayerBullet.TurnOn, 4);
    }

    private void Update()
    {
        _inputs.ArtificialUpdate();
    }

    public void Movement(float vertical, float horizontal)
    {
        transform.position += transform.forward  * vertical * _speedMovement * Time.deltaTime;
        transform.position += transform.right  * horizontal * _speedMovement * Time.deltaTime;
    }

    public void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > _fireRate)
        {
            PlayerBullet bullet = _objectPool.Get();
            bullet.AddReference(_objectPool);
            bullet.transform.position = _bulletSpawn.position;
            bullet.transform.forward = _bulletSpawn.forward;
            bullet.Damage = _damage;
            _timer = 0;
        }
    }

    public void GetDamage(int dmg)
    {

    }
}