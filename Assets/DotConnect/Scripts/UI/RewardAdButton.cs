using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BizzyBeeGames.DotConnect
{
	[RequireComponent(typeof(Button))]
	public class RewardAdButton : MonoBehaviour
	{
		#region Inspector Variables

		[SerializeField] private int hintsToReward;

		#endregion

		#region Properties

		public Button Button { get { return gameObject.GetComponent<Button>(); } }

		#endregion

		#region Unity Methods

		private void Awake()
		{
			Button.onClick.AddListener(OnClick);

			gameObject.SetActive(MobileAdsManager.Instance.RewardAdState == AdNetworkHandler.AdState.Loaded);

			MobileAdsManager.Instance.OnRewardAdLoaded	+= OnRewardAdLoaded;
			MobileAdsManager.Instance.OnAdsRemoved		+= OnAdsRemoved;
		}

		#endregion

		#region Private Methods

		private void OnClick()
		{
			if (MobileAdsManager.Instance.RewardAdState != AdNetworkHandler.AdState.Loaded)
			{
				gameObject.SetActive(false);

				Debug.LogError("[RewardAdButton] The reward button was clicked but there is no ad loaded to show.");

				return;
			}

			MobileAdsManager.Instance.ShowRewardAd(OnRewardAdClosed, OnRewardAdGranted);
		}

		private void OnRewardAdLoaded()
		{
			gameObject.SetActive(true);
		}

		private void OnRewardAdClosed()
		{
			gameObject.SetActive(false);
		}

		private void OnRewardAdGranted(string rewardId, double rewardAmount)
		{
			// Give the hints
			GameManager.Instance.GiveHints(hintsToReward);

			// Show the popup to the user so they know they got the hint
			PopupManager.Instance.Show("reward_ad_granted");
		}

		private void OnAdsRemoved()
		{
			MobileAdsManager.Instance.OnRewardAdLoaded -= OnRewardAdLoaded;
			gameObject.SetActive(false);
		}

		#endregion
	}
}
