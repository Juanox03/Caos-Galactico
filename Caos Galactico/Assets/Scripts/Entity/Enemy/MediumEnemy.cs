using UnityEngine;

public class MediumEnemy : Enemy
{
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
            int angle = 360 / _numberOfProjectiles;

            for (int i = 0; i < _numberOfProjectiles; i++)
            {
                int shootAngle = i * angle;

                EnemyBullet bullet = _objectPool.Get();
                bullet.AddReference(_objectPool);
                bullet.transform.position = _bulletSpawn.position;
                bullet.transform.forward = _bulletSpawn.forward;
                bullet.transform.rotation = Quaternion.Euler(0, shootAngle, 0);
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
            EventManager.Trigger("OnEnemyDeath");
            Destroy(gameObject);
        }
    }
}