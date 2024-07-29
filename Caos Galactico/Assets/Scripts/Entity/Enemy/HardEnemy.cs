using System.Collections;
using UnityEngine;

public class HardEnemy : Enemy
{
    [Header("Values")]
    [SerializeField] int _numberOfSecondaryProjectiles = 5;
    [SerializeField] float _pauseDuration;

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

    void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > _fireRate)
        {
            int angle = 360 / _numberOfProjectiles;

            for (int i = 0; i < _numberOfProjectiles; i++)
            {
                int angleShoot = i * angle;

                EnemyBullet bullet = _objectPool.Get();
                bullet.AddReference(_objectPool);
                bullet.transform.position = _bulletSpawn.position;
                bullet.transform.forward = _bulletSpawn.forward;
                bullet.transform.rotation = Quaternion.Euler(0, angleShoot, 0);

                StartCoroutine(DivideProjectile(bullet));
            }
            _timer = 0;
        }
    }

    IEnumerator DivideProjectile(EnemyBullet b)
    {
        yield return new WaitForSeconds(_pauseDuration);

        int angle = 360 / _numberOfProjectiles;

        for (int i = 0; i < _numberOfSecondaryProjectiles; i++)
        {
            int angleShoot = i * angle;

            EnemyBullet bullet = _objectPool.Get();
            bullet.AddReference(_objectPool);
            bullet.transform.position = b.transform.position;
            bullet.transform.forward = b.transform.forward;
            bullet.transform.rotation = Quaternion.Euler(0, angleShoot, 0);
        }
    }

    public override void GetDamage(float dmg)
    {
        _life -= dmg;
        _barLife.fillAmount = _life / _maxLife;

        if (_life <= 0)
        {
            EventManager.Trigger("OnEnemyDeath");
            Destroy(gameObject);
        }
    }
}