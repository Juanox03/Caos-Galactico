using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _speedMovement;

    public float counter;
    ObjectPool<EnemyBullet> _objectPool;

    private void Update()
    {
        transform.position += transform.forward * _speedMovement * Time.deltaTime;

        counter += Time.deltaTime;
        if (counter >= 2)
            _objectPool.StockAdd(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.GetDamage();
            _objectPool.StockAdd(this);
        }

        if (other.CompareTag("Wall"))
            _objectPool.StockAdd(this);
    }

    public void AddReference(ObjectPool<EnemyBullet> op)
    {
        _objectPool = op;
    }

    public static void TurnOff(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public static void TurnOn(EnemyBullet bullet)
    {
        bullet.counter = 0;
        bullet.gameObject.SetActive(true);
    }
}