public class PowerUpDamage : PowerUp
{
    private int _amount = 2;
    public Player player;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePowerUp();

            Destroy(gameObject);
        }
    }

    public override void ActivatePowerUp()
    {
        player.PowerUpMoreDamage(_amount);
    }
}