using UnityEngine;

public class PowerUpHealth : PowerUp
{

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.RecuperarVida();

            Destroy(gameObject);
        }
    }

    public override void ActivatePowerUp()
    {
        
    }
}