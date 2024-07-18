public class PlayerBulletFactory : Factory<PlayerBullet>
{
    public PlayerBulletFactory(PlayerBullet p)
    {
        prefab = p;
    }
}