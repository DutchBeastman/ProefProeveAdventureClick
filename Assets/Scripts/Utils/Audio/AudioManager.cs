using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;
using System.Collections;

namespace Utils
{
	public class AudioManager : MonoBehaviour , IGameDependency
	{
		private const int NUM_CHANNELS = 32;

		public delegate void OnFadeComplete(AudioChannel channel);
		public event OnFadeComplete onFadeCompleteEvent = delegate {
		};

		private HashSet<AudioChannel> channels;
		private HashSet<AudioChannel> claimedChannels;

		//private CoroutineRunner coroutineRunner;

		private GameObject baseObject;

		public AudioManager()
		{
			channels = new HashSet<AudioChannel>();
			claimedChannels = new HashSet<AudioChannel>();

			//coroutineRunner = GameDependencies.Get<CoroutineRunner>();

			CreateChannels();
		}

		public void Dispose()
		{
			DestroyChannels();
		}

		public AudioChannel Play(AudioAsset audioAsset , bool loop = false , AudioMixerGroup audioMixerGroup = null)
		{
			if (audioAsset == null)
			{
				return null;
			}

			foreach (AudioChannel channel in channels)
			{
				if (claimedChannels.Contains(channel))
				{
					continue;
				}

				if (channel.Play(audioAsset , loop , audioMixerGroup))
				{
					return channel;
				}
			}

			Debug.LogWarning("[AudioManager] No available audio channels for audio asset: " + audioAsset);
			return null;
		}

		public AudioChannel PlayRandom(AudioAssetGroup audioAssetGroup , bool loop = false)
		{
			if (audioAssetGroup == null)
			{
				return null;
			}

			foreach (AudioChannel channel in channels)
			{
				if (claimedChannels.Contains(channel))
				{
					continue;
				}

				if (channel.PlayRandom(audioAssetGroup , loop))
				{
					return channel;
				}
			}

			Debug.LogWarning("[AudioManager] No available audio channels for audio asset group: " + audioAssetGroup);
			return null;
		}

		public void StopAll(AudioAssetType type , bool includeClaimedChannels = false)
		{
			foreach (AudioChannel channel in channels)
			{
				if (!includeClaimedChannels && claimedChannels.Contains(channel))
				{
					continue;
				}

				if (channel.IsPlaying && channel.AudioAsset.Type == type)
				{
					channel.Stop();
				}
			}
		}

		public void StopAll(bool includeClaimedChannels = false)
		{
			foreach (AudioChannel channel in channels)
			{
				if (!includeClaimedChannels && claimedChannels.Contains(channel))
				{
					continue;
				}

				channel.Stop();
			}
		}

		public void CrossFade(AudioChannel from , AudioChannel to , float steps)
		{
			FadeIn(to , steps);
			FadeOut(from , steps);
		}

		public void FadeIn(AudioChannel channel , float steps)
		{
			if (channel != null && channel.IsPlaying)
			{
				StartCoroutine(DoFade(channel , 0 , 1 , steps));
			}
		}

		public void FadeOut(AudioChannel channel , float steps)
		{
			if (channel != null && channel.IsPlaying)
			{
				StartCoroutine(DoFade(channel , 1 , 0 , steps));
			}
		}

		public void FadeOutAll(float steps)
		{
			foreach (AudioChannel channel in channels)
			{
				FadeOut(channel , steps);
			}
		}

		public void ClaimChannel(AudioChannel channel)
		{
			if (!claimedChannels.Contains(channel))
			{
				claimedChannels.Add(channel);
			}
		}

		public void ReleaseChannel(AudioChannel channel)
		{
			if (claimedChannels.Contains(channel))
			{
				claimedChannels.Remove(channel);
			}
		}

		public AudioChannel GetAvailableChannel()
		{
			foreach (AudioChannel channel in channels)
			{
				if (claimedChannels.Contains(channel))
				{
					continue;
				}

				if (!channel.IsPlaying)
				{
					return channel;
				}
			}

			return null;
		}

		private IEnumerator DoFade(AudioChannel channel , float start , float end , float steps)
		{
			float startTime = Time.time;

			channel.Volume = start;

			while (!channel.Volume.AlmostEquals(end , 0.05f))
			{
				channel.Volume = Easing.EaseInOutQuad(start , end , Time.time - startTime);
				yield return null;
			}

			channel.Volume = end;
			onFadeCompleteEvent(channel);
		}

		private void CreateChannels()
		{
			DestroyChannels();

			baseObject = new GameObject("Audio Channels");

			for (int i = 0; i < NUM_CHANNELS; i++)
			{
				GameObject obj = new GameObject("Audio Channel " + i);
				obj.transform.SetParent(baseObject.transform);
				channels.Add(obj.AddComponent<AudioChannel>());
			}
		}

		private void DestroyChannels()
		{
			if (baseObject != null)
			{
				foreach (AudioChannel channel in channels)
				{
					channel.Stop();
				}

				Object.Destroy(baseObject);
			}
		}
	}
}
