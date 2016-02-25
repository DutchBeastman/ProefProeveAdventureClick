using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMix;
	[SerializeField]
	private AudioMixerGroup[] audioMixerGroups;
    private AudioSource aSource;

	protected void Awake()
	{
        if (aSource == null)
        {
            aSource = gameObject.GetComponent<AudioSource>();
        }
	}

    public void PlayClip(AudioClip clip, AudioMix mix)
    {
		aSource.outputAudioMixerGroup = CheckMix(mix);
		if (aSource.outputAudioMixerGroup != null)
		{
			Debug.Log(aSource.outputAudioMixerGroup);
			aSource.PlayOneShot(clip);
		}
    }
    private AudioMixerGroup CheckMix(AudioMix mix)
    {
        switch (mix)
        {
            case AudioMix.Music:
				return audioMixerGroups[1];
			case AudioMix.SFX:
				return audioMixerGroups[2];
            default:
				return audioMixerGroups[0];          
        }
    }
}
