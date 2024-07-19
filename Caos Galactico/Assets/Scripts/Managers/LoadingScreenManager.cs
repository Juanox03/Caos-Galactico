using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    string _levelName;
    [SerializeField] Slider _sliderBar;

    private void Start()
    {
        _levelName = Scenemanager.Instance.LevelName;
        if (_levelName != null)
        {
            StartCoroutine(ChargeLevel(_levelName));
        }
    }

    IEnumerator ChargeLevel(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);

        while (!async.isDone)
        {
            float progreso = Mathf.Clamp01(async.progress / 0.9f);
            _sliderBar.value = progreso;

            yield return null;
        }
    }
}