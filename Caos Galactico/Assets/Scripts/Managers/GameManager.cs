using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] CanvasGroup _gameOverScreen;
    [SerializeField] CanvasGroup _gameWinScreen;
    [SerializeField] CanvasGroup _gamePauseScreen;

    private void Awake()
    {
        Player.OnDeath += OnPLayerLose;
        EasyEnemy.OnDeath += OnPLayerWin;
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void GamePause()
    {
        _gamePauseScreen.alpha = 1;
        _gamePauseScreen.interactable = true;
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        _gamePauseScreen.alpha = 0;
        _gamePauseScreen.interactable = false;
        Time.timeScale = 0;
    }

    private void OnPLayerLose()
    {
        _gameOverScreen.alpha = 1;
        _gameOverScreen.interactable = true;
        Time.timeScale = 0;
    }

    private void OnPLayerWin()
    {
        _gameWinScreen.alpha = 1;
        _gameWinScreen.interactable = true;
        Time.timeScale = 0;
    }
}