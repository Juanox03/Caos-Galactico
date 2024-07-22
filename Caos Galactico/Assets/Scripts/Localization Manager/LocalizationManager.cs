using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;
    public SystemLanguage language;

    public DataLocalization[] data;

    public Dictionary<SystemLanguage, Dictionary<string, string>> _translate = new Dictionary<SystemLanguage, Dictionary<string, string>>();

    public static event Action OnChangeLanguage;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        _translate = LanguageU.LoadTranslate(data);
    }

    public string GetTranslate(string ID)
    {
        if (!_translate.ContainsKey(language))
            return "No lang";

        if (!_translate[language].ContainsKey(ID))
            return "No ID";

        return _translate[language][ID];
    }

    public void Translate(int value)
    {
        switch (value)
        {
            case 0:
                language = SystemLanguage.Slovenian;
                _translate = LanguageU.LoadTranslate(data);
                OnChangeLanguage?.Invoke();
                break;
            case 1:
                language = SystemLanguage.English;
                _translate = LanguageU.LoadTranslate(data);
                OnChangeLanguage?.Invoke();
                break;
            default:
                break;
        }

    }
}