using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Slider _sliderBar;

    public void LoadingLevel(string levelName)
    {
        StartCoroutine(LoadingScene(levelName));
    }

    IEnumerator LoadingScene(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}