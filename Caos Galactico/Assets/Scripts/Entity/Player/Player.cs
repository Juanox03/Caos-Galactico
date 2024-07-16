using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [Header("Parameters")]
    [SerializeField] float _speedMovement;
    [Header("Bullet")]
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] float _fireRate;
    float _timer;

    Player_Inputs _inputs;

    private void Awake()
    {
        _inputs = new Player_Inputs(this);
    }

    private void Update()
    {
        _inputs.ArtificialUpdate();
    }

    public void Movement(float vertical, float horizontal)
    {
        transform.position += transform.forward  * vertical * _speedMovement * Time.deltaTime;
        transform.position += transform.right  * horizontal * _speedMovement * Time.deltaTime;
    }

    public void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > _fireRate)
        {
            Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.identity);
            _timer = 0;
        }

    }
}