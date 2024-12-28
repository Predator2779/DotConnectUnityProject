using System;
using BizzyBeeGames;
using BizzyBeeGames.DotConnect;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace DotConnect.Scripts.YandexADS
{
	[RequireComponent(typeof(Button))]
	public class RewardYandexButton : MonoBehaviour
	{
		[SerializeField] private int hintsToReward;

		public Button Button => gameObject.GetComponent<Button>();

		private void Awake()
		{
			Button.onClick.AddListener(OnClick);
			YandexGame.RewardVideoEvent += OnRewardAdGranted;
		}

		private void OnDestroy()
		{
			YandexGame.RewardVideoEvent -= OnRewardAdGranted;
		}

		private void OnClick()
		{
			YandexGame.RewVideoShow(hintsToReward);
		}
		
		private void OnRewardAdGranted(int reward)
		{
			GameManager.Instance.GiveHints(reward);
			PopupManager.Instance.Show("reward_ad_granted");
		}
	}
}
