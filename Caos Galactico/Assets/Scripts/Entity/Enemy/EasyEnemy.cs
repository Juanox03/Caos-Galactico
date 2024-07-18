using UnityEngine;
using UnityEngine.UI;

public class EasyEnemy : Enemy
{
    [SerializeField] Image _barLife;
    [SerializeField] float _maxLife;
    [SerializeField] float _life;

    [SerializeField] float _fireRate;
    float _timer;

    [SerializeField] EnemyBullet _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;

    Factory<EnemyBullet> _factory;
    ObjectPool<EnemyBullet> _objectPool;

    public float shootInterval = 1.0f;
    public int numberOfProjectiles = 5;
    public float projectileSpeed = 5.0f;

    private void Start()
    {
        _life = _maxLife;

        _factory = new EnemyBulletFactory(_bulletPrefab);
        _objectPool = new ObjectPool<EnemyBullet>(_factory.GetObj, EnemyBullet.TurnOff, EnemyBullet.TurnOn, 100);
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > shootInterval)
        {
            float startX = -numberOfProjectiles / 2.0f;
            for (int i = 0; i < numberOfProjectiles; i++)
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
    }
}