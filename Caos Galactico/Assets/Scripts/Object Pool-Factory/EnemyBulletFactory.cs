public class EnemyBulletFactory : Factory<EnemyBullet>
{
    public EnemyBulletFactory(EnemyBullet p)
    {
        prefab = p;
    }
}