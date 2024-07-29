using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEntityManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject[] _enemy;
    [SerializeField] Transform _spawnPointPlayer;
    [SerializeField] Transform _spawnPointEnemy;

    private void Start()
    {
        var levelName = SceneManager.GetActiveScene().name;

        switch (levelName)
        {
            case "Level 1":
                Debug.Log("Instancio");
                Instantiate(_enemy[0], _spawnPointEnemy.position, _enemy[0].transform.rotation);
                Instantiate(_player, _spawnPointPlayer.position, Quaternion.identity);
                break;
            case "Level 2":
                Debug.Log("Instancio");
                Instantiate(_enemy[1], _spawnPointEnemy.position, _enemy[1].transform.rotation);
                Instantiate(_player, _spawnPointPlayer.position, Quaternion.identity);
                break;
            case "Level 3":
                Debug.Log("Instancio");
                Instantiate(_enemy[2], _spawnPointEnemy.position, _enemy[2].transform.rotation);
                Instantiate(_player, _spawnPointPlayer.position, Quaternion.identity);
                break;
        }
    }
}