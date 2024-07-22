using System;
using UnityEngine;
using UnityEngine.UI;

public class MediumEnemy : Enemy
{
    [Header("Values")]
    [Header("Life Config")]
    [SerializeField] Image _barLife;
    [SerializeField] float _maxLife;
    [SerializeField] float _life;
    [Header("Bullet Config")]
    [SerializeField] EnemyBullet _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] float _fireRate = 1;
    float _timer;
    [SerializeField] int _numberOfProjectiles = 5;

    Factory<EnemyBullet> _factory;
    ObjectPool<EnemyBullet> _objectPool;

    public static event Action OnDeath;

    public Vector3 convergencePoint = new Vector3(0, 0, 10);
    public float projectileSpeed = 1;

    private void Start()
    {
        _life = _maxLife;

        _factory = new EnemyBulletFactory(_bulletPrefab);
        _objectPool = new ObjectPool<EnemyBullet>(_factory.GetObj, EnemyBullet.TurnOff, EnemyBullet.TurnOn, 50);
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > _fireRate)
        {
            var angle = 360 / _numberOfProjectiles;

            for (int i = 0; i < _numberOfProjectiles; i++)
            {
                var shootAngle = i * angle;
                Vector3 direction = Quaternion.Euler(0, shootAngle, 0) * Vector3.forward;
                Vector3 spawnPosition = _bulletSpawn.position + direction * 2.0f;

                EnemyBullet bullet = _objectPool.Get();
                bullet.AddReference(_objectPool);
                bullet.transform.position = _bulletSpawn.position;
                bullet.transform.forward = _bulletSpawn.forward;

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                Vector3 targetDirection = (convergencePoint + spawnPosition).normalized;
                rb.velocity = targetDirection * projectileSpeed;
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