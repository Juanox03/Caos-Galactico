using TMPro;
using UnityEngine;

public class TextToTranslate : MonoBehaviour
{
    public string ID;
    public TextMeshProUGUI textUI;

    private void Awake()
    {
        LocalizationManager.OnChangeLanguage += Translate;
    }

    void Start()
    {
        textUI.text = LocalizationManager.Instance.GetTranslate(ID);
    }

    public void Translate()
    {
        textUI.text = LocalizationManager.Instance.GetTranslate(ID);
    }
}