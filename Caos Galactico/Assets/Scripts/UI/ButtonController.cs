using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button _button;
    Scenemanager sceneManager;
    [SerializeField] string _levelName;

    void Start()
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }

        _button.onClick.AddListener(() =>
        {
            if (sceneManager == null)
            {
                sceneManager = Scenemanager.Instance;
            }
            sceneManager.ChangeLevel(_levelName);
        });
    }
}