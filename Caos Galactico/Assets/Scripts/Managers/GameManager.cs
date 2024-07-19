using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Instantiate Power Up")]
    [SerializeField] GameObject[] _powerUpPrefabs;
    [SerializeField] Transform _floor;
    float _timer = 0;

    [Header("Canvas Group")]
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

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 10)
        {
            InstantiatePowerUp();
            _timer = 0;
        }
    }

    void InstantiatePowerUp()
    {
        Vector3 tamañoSuperficie = _floor.localScale;

        float xAleatorio = Random.Range(-tamañoSuperficie.x / 2, tamañoSuperficie.x / 2);
        float zAleatorio = Random.Range(-tamañoSuperficie.z / 2, tamañoSuperficie.z / 2);

        Vector3 posicionAleatoria = _floor.position + _floor.TransformPoint(new Vector3(xAleatorio, 0.25f, zAleatorio));

        var powerUp = Random.Range(0, _powerUpPrefabs.Length);
        Instantiate(_powerUpPrefabs[powerUp], posicionAleatoria, Quaternion.identity);
    }

    public void GamePause()
    {
        _gamePauseScreen.alpha = 1;
        _gamePauseScreen.interactable = true;
        _gamePauseScreen.blocksRaycasts = true;
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        _gamePauseScreen.alpha = 0;
        _gamePauseScreen.interactable = false;
        _gamePauseScreen.blocksRaycasts = false;
        Time.timeScale = 1;
    }

    private void OnPLayerLose()
    {
        _gameOverScreen.alpha = 1;
        _gameOverScreen.interactable = true;
        _gameOverScreen.blocksRaycasts = true;
        Time.timeScale = 0;
    }

    private void OnPLayerWin()
    {
        _gameWinScreen.alpha = 1;
        _gameWinScreen.interactable = true;
        _gameWinScreen.blocksRaycasts = true;
        Time.timeScale = 0;
    }
}