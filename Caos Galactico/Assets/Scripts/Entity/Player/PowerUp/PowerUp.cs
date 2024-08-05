using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(other.CompareTag("Player"))
        {
            ActivatePowerUp();

            Destroy(gameObject);
        }
    }

    public abstract void ActivatePowerUp();
}