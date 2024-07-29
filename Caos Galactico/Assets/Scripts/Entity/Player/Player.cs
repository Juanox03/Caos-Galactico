using System;
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
    float _timer;
    [SerializeField] float _damage;
    [Header("Health")]
    [SerializeField] int _health = 3;
    [SerializeField] GameObject[] _hearts;

    Factory<PlayerBullet> _factory;
    ObjectPool<PlayerBullet> _objectPool;

    PlayerInputs _inputs;

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
        transform.position += transform.forward * vertical * _speedMovement * Time.deltaTime;
        transform.position += transform.right * horizontal * _speedMovement * Time.deltaTime;
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

    public void RecuperarVida()
    {
        if (_health < 3)
        {
            _health = 3;
            for (int i = 0; i < 2; i++)
                _hearts[i].SetActive(true);
        }
        else return;
    }

    public void PowerUpMoreDamage(int amount)
    {
        _damage *= amount;
    }

    public void GetDamage()
    {
        _health--;
        _hearts[_health].SetActive(false);

        if (_health <= 0)
        {
            EventManager.Trigger("OnPlayerDeath");
            Destroy(gameObject);
        }
    }
}