using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _speedMovement;
    [SerializeField] float _lifeTime = 5;

    public float counter;
    ObjectPool<EnemyBullet> _objectPool;

    private void Update()
    {
        transform.position += transform.forward * _speedMovement * Time.deltaTime;

        counter += Time.deltaTime;
        if (counter >= 2)
            _objectPool.StockAdd(this);

        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
            Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            if(player.CompareTag("Player"))
                player.GetDamage();

        }
        
        //Destroy(gameObject);
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