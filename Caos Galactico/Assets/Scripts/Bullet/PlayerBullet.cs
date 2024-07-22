using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float _speedMovement;
    [SerializeField] float _damage;

    public float counter;
    ObjectPool<PlayerBullet> _objectPool;

    public float Damage { get { return _damage; } set { _damage = value; } }

    private void Update()
    {
        transform.position += transform.forward * _speedMovement * Time.deltaTime;

        counter += Time.deltaTime;
        if (counter >= 2)
        {
            _objectPool.StockAdd(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GetDamage(_damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall"))
            Destroy(gameObject);

    }

    public void AddReference(ObjectPool<PlayerBullet> op)
    {
        _objectPool = op;
    }

    public static void TurnOff(PlayerBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public static void TurnOn(PlayerBullet bullet)
    {
        bullet.counter = 0;
        bullet.gameObject.SetActive(true);
    }
}