using UnityEngine;

public class Player_Inputs
{
    Player _player;

    public Player_Inputs(Player player)
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