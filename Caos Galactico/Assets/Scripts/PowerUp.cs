using UnityEngine;

public class PowerUp : MonoBehaviour
{
    enum PowerUpType
    {
        Damage,
        Health
    }
    [SerializeField] PowerUpType _powerUpType;
    [SerializeField] int _amount;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if(player != null)
        {
            switch (_powerUpType)
            {
                case PowerUpType.Damage:
                    player.PowerUpMoreDamage(_amount);
                    break;
                case PowerUpType.Health:
                    player.RecuperarVida();
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}