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
                    player.Damage *= _amount;
                    break;
                case PowerUpType.Health:
                    if(player.Health < 3)
                    player.Health = 3;
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}