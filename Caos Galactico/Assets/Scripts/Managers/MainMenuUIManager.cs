using TMPro;
using UnityEditor;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("Contents")]
    [SerializeField] GameObject _playContent;
    [SerializeField] GameObject _opcionsContent;
    [SerializeField] GameObject _creditsContent;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _companyName;
    [SerializeField] TextMeshProUGUI _versionGame;

    [Header("Canvas Group")]
    [SerializeField] CanvasGroup _canvasGroup;

    private void Start()
    {
        _companyName.text = PlayerSettings.companyName;
        _versionGame.text = PlayerSettings.bundleVersion;
    }

    public void PlayContentEnable()
    {
        _playContent.SetActive(true);
        _canvasGroup.interactable = false;
    }

    public void PlayContentDisable()
    {
        _playContent.SetActive(false);
        _canvasGroup.interactable = true;
    }

    public void OpcionsContentEnable()
    {
        _opcionsContent.SetActive(true);
        _canvasGroup.interactable = false;
    }

    public void OpcionsContentDisable()
    {
        _opcionsContent.SetActive(false);
        _canvasGroup.interactable = true;
    }

    public void CreditsContentEnable()
    {
        _creditsContent.SetActive(true);
        _canvasGroup.interactable = false;
    }

    public void CreditsContentDisable()
    {
        _creditsContent.SetActive(false);
        _canvasGroup.interactable = true;
    }
}