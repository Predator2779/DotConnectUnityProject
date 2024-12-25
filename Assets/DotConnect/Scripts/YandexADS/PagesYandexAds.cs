using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DotConnect.Scripts.YandexADS
{
    [RequireComponent(typeof(Button))]
    public class PagesYandexAds : MonoBehaviour
    {
        [SerializeField][Range(0, 100)] private int _adsChance;

        private Button Button => gameObject.GetComponent<Button>();
        private void OnEnable() => Button.onClick.AddListener(OnClick);
        private void OnDisable() => Button.onClick.RemoveListener(OnClick);
        
        private void OnClick()
        {
            if (_adsChance >= Random.Range(0, 101)) 
                YandexGame.FullscreenShow();
        }
    }
}