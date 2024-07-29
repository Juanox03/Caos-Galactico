using UnityEngine;

public class PowerUp : MonoBehaviour, IPowerUp
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
            ActivatePowerUp(player);

            Destroy(gameObject);
        }
    }

    public void ActivatePowerUp(Player player)
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
    }
}