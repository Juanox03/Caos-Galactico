using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    [SerializeField] float _speedMovement;
    [SerializeField] float _lifeTime = 5;

    private void Update()
    {
        _lifeTime -= Time.deltaTime;

        transform.position += transform.forward * _speedMovement * Time.deltaTime;

        if (_lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
