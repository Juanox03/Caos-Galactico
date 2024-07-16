using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenemanager : MonoBehaviour
{
    [SerializeField] GameObject _loadScreen;
    [SerializeField] Slider _sliderBar;

    public void ChangeLevel1(string levelName)
    {
        StartCoroutine(ChargeLevel1(levelName));
    }

    public void ChangeLevel2(string levelName)
    {
        StartCoroutine(ChargeLevel2(levelName));
    }

    public void ChangeLevel3(string levelName)
    {
        StartCoroutine(ChargeLevel3(levelName));
    }

    public void ChangeLevelTest(string levelName)
    {
        StartCoroutine(ChargeLevelTest(levelName));
    }

    #region Corrutinas
    IEnumerator ChargeLevel1(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        _loadScreen.SetActive(true);

        while (!async.isDone)
        {
            float progreso = Mathf.Clamp01(async.progress / 0.9f);
            _sliderBar.value = progreso;

            yield return null;
        }
    }
    
    IEnumerator ChargeLevel2(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        _loadScreen.SetActive(true);

        while (!async.isDone)
        {
            float progreso = Mathf.Clamp01(async.progress / 0.9f);
            _sliderBar.value = progreso;

            yield return null;
        }
    }
    
    IEnumerator ChargeLevel3(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        _loadScreen.SetActive(true);

        while (!async.isDone)
        {
            float progreso = Mathf.Clamp01(async.progress / 0.9f);
            _sliderBar.value = progreso;

            yield return null;
        }
    }
    
    IEnumerator ChargeLevelTest(string levelName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        _loadScreen.SetActive(true);

        while (!async.isDone)
        {
            float progreso = Mathf.Clamp01(async.progress / 0.9f);
            _sliderBar.value = progreso;

            yield return null;
        }
    }
    #endregion
}