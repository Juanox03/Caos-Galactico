using System;
using UnityEngine;

public class EasyEnemy : Enemy
{
    [Header("Values")]
    [Header("Parameters")]
    [SerializeField] float _speedMovement = 5;
    [SerializeField] float _movementRange = 4;

    public static event Action OnDeath;

    private void Start()
    {
        _life = _maxLife;

        _factory = new EnemyBulletFactory(_bulletPrefab);
        _objectPool = new ObjectPool<EnemyBullet>(_factory.GetObj, EnemyBullet.TurnOff, EnemyBullet.TurnOn, 50);
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float posicionX = Mathf.PingPong(Time.time * _speedMovement, _movementRange) - (_movementRange / 2);
        transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);
    }

    private void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > _fireRate)
        {
            float startX = -_numberOfProjectiles / 2.0f;
            for (int i = 0; i < _numberOfProjectiles; i++)
            {
                Vector3 spawnPosition = transform.position + new Vector3(startX + i, 0, 0);
                EnemyBullet bullet = _objectPool.Get();
                bullet.AddReference(_objectPool);
                bullet.transform.position = spawnPosition;
                bullet.transform.forward = _bulletSpawn.forward;
            }
            _timer = 0;
        }
    }

    public override void GetDamage(float dmg)
    {
        _life -= dmg;
        _barLife.fillAmount = _life / _maxLife;

        if (_life <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}