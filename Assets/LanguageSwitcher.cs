using System.Collections.Generic;
using DotConnect.Plugins.SimpleLocalization.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _langDropdown;

    private void Start()
    {
        var listLang = new List<TMP_Dropdown.OptionData>
        {
            new TMP_Dropdown.OptionData("Russian"),
            new TMP_Dropdown.OptionData("English")
        };

        _langDropdown.options = listLang;
        Switch(listLang[0].text);
    }

    public void Switch(string language)
    {
        LocalizationManager.Language = language;
    }

    public void Switch(TMP_Text language)
    {
        LocalizationManager.Language = language.text;
    }

    public void Switch(Text language)
    {
        LocalizationManager.Language = language.text;
    }
}