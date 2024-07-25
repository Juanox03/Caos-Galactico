using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Values")]
    [Header("Life Config")]
    [SerializeField] protected Image _barLife;
    [SerializeField] protected float _maxLife;
    [SerializeField] protected float _life;

    [Header("Bullet Config")]
    [SerializeField] protected EnemyBullet _bulletPrefab;
    [SerializeField] protected Transform _bulletSpawn;
    [SerializeField] protected float _fireRate = 1;
    protected float _timer;
    [SerializeField] protected int _numberOfProjectiles = 5;

    protected Factory<EnemyBullet> _factory;
    protected ObjectPool<EnemyBullet> _objectPool;

    public abstract void GetDamage(float dmg);
}
