using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public static Scenemanager Instance;

    [SerializeField] string _loadScene;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void ChangeLoadingScene()
    {
        StartCoroutine(ChargeSceneLoading(_loadScene));
    }

    IEnumerator ChargeSceneLoading(string levelName)
    {
        SceneManager.LoadScene(levelName);

        yield return null;
    }
}