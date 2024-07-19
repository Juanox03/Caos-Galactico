using UnityEngine;

public class PlayerInputs
{
    Player _player;

    public PlayerInputs(Player player)
    {
        _player = player;
    }

    public void ArtificialUpdate()
    {
        GetInputs();
    }

    public void GetInputs()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0)
            Move(vertical: vertical);
        float horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal != 0)
            Move(horizontal: horizontal);

        if (Input.GetMouseButton(0))
            Shoot();

        if(Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.GamePause();
    }

    private void Move(float vertical = default, float horizontal = default)
    {
        _player.Movement(vertical, horizontal);
    }

    private void Shoot()
    {
        _player.Shoot();
    }
}