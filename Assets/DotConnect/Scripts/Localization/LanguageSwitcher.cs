using System;
using DotConnect.Plugins.SimpleLocalization.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _langDropdown;

    public Action OnLanguageSwitched;

    private void Start() => AutoDetect();
    public void Switch(TMP_Text language) => Switch(language.text);
    public void Switch(Text language) => Switch(language.text);

    private void Switch(string language)
    {
        int index = _langDropdown.options.FindIndex(option => option.text == language);

        if (index != -1)
        {
            _langDropdown.value = index;
            _langDropdown.RefreshShownValue();
            LocalizationManager.Language = language;
            OnLanguageSwitched?.Invoke();
        }
        else
        {
            Debug.LogWarning($"Язык '{language}' не найден в списке dropdown.");
        }
    }

    private void AutoDetect()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                Switch(SystemLanguage.Russian.ToString());
                break;
            default:
                Switch(SystemLanguage.English.ToString());
                break;
                ;
        }
    }
}