using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public static Scenemanager Instance;

    string _levelName;
    public string LevelName { get { return _levelName; } }

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

    public void ChangeLevel(string levelName)
    {
        _levelName = levelName;
        SceneManager.LoadScene("Loading");
    }
}