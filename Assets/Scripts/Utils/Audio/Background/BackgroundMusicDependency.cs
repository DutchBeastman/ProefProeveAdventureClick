using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	/// <summary>
	///
	/// </summary>
	public class BackgroundMusicDependency : IGameDependency
	{
		private AudioManager audioManager;

		private AudioChannel channel;
		private AudioAssetGroup activeAudioAssetGroup;

		public BackgroundMusicDependency()
		{
			audioManager = GameDependencies.Get<AudioManager>();

			channel = audioManager.GetAvailableChannel();
			audioManager.ClaimChannel(channel);
		}

		public void Dispose()
		{
			audioManager.ReleaseChannel(channel);
		}

		public void Play(AudioAssetGroup audioAssetGroup , bool loop = false)
		{
			if (activeAudioAssetGroup != audioAssetGroup)
			{
				activeAudioAssetGroup = audioAssetGroup;

				if (activeAudioAssetGroup != null)
				{
					channel.Stop();
					channel.PlayRandom(activeAudioAssetGroup , loop);
				}
			}
		}

		public void FadeOut(float steps)
		{
			if (activeAudioAssetGroup != null && channel != null)
			{
				audioManager.FadeOut(channel , steps);
				activeAudioAssetGroup = null;
			}
		}
	}
}
