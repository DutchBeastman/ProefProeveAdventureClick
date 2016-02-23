using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

namespace Utils
{
	/// <summary>
	///
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public class AudioChannels : MonoBehaviour
	{
		public AudioAsset AudioAsset
		{
			private set; get;
		}

		public float Volume
		{
			set
			{
				audioSource.volume = Mathf.Clamp01(value);
			}
			get
			{
				return audioSource.volume;
			}
		}

		public float Pitch
		{
			set
			{
				audioSource.pitch = Mathf.Clamp01(value);
			}
			get
			{
				return audioSource.pitch;
			}
		}

		public float PanStereo
		{
			set
			{
				audioSource.panStereo = Mathf.Clamp01(value);
			}
			get
			{
				return audioSource.panStereo;
			}
		}

		public float SpatialBlend
		{
			set
			{
				audioSource.spatialBlend = Mathf.Clamp01(value);
			}
			get
			{
				return audioSource.spatialBlend;
			}
		}

		public float ReverbZoneMix
		{
			set
			{
				audioSource.reverbZoneMix = Mathf.Clamp(value , 0 , 1.1f);
			}
			get
			{
				return audioSource.reverbZoneMix;
			}
		}

		public bool Mute
		{
			set
			{
				audioSource.mute = value;
			}
			get
			{
				return audioSource.mute;
			}
		}

		public bool Loop
		{
			set
			{
				audioSource.loop = value;
			}
			get
			{
				return audioSource.loop;
			}
		}

		public bool IsPlaying
		{
			get
			{
				return audioSource.isPlaying;
			}
		}

		private AudioSource audioSource;

		protected void Awake()
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.playOnAwake = false;
		}

		public bool Play(AudioAsset audioAsset , bool loop = false , AudioMixerGroup audioMixerGroup = null)
		{
			if (IsPlaying)
			{
				return false;
			}

			if (audioAsset.AudioClip == null)
			{
				Debug.LogError("[AudioChannel] " + audioAsset + " has no AudioClip." , audioAsset);
				return false;
			}

			audioSource.clip = audioAsset.AudioClip;
			audioSource.outputAudioMixerGroup = audioMixerGroup ?? audioAsset.AudioMixerGroup;

			Volume = audioAsset.Volume;
			Pitch = audioAsset.Pitch;
			PanStereo = audioAsset.StereoPan;
			SpatialBlend = audioAsset.SpatialBlend;
			ReverbZoneMix = audioAsset.ReverbZoneMix;
			Loop = loop;

			AudioAsset = audioAsset;

			audioSource.Play();
			return true;
		}

		public bool Play(AudioAssetGroup audioAssetGroup , AudioAsset audioAsset , bool loop = false)
		{
			return Play(audioAsset , loop , audioAssetGroup.AudioMixerGroup ?? audioAsset.AudioMixerGroup);
		}

		public bool PlayRandom(AudioAssetGroup audioAssetGroup , bool loop = false)
		{
			List<AudioAsset> audioAssets = new List<AudioAsset>(audioAssetGroup.AudioAssets);
			AudioAsset target = audioAssets[Random.Range(0 , audioAssets.Count)];

			return Play(audioAssetGroup , target , loop);
		}

		public bool Stop()
		{
			if (!IsPlaying)
			{
				return false;
			}

			audioSource.Stop();
			return true;
		}
	}
}

}
