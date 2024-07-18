using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverScreen;

    private void Awake()
    {
        Player.OnDeath += OnPLayerLose;
    }

    private void OnPLayerLose()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}