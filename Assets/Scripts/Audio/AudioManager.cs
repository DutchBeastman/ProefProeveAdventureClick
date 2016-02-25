using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMix;
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
        aSource.PlayOneShot(clip);
        aSource.outputAudioMixerGroup =  ;
        
    }
    private AudioMixerGroup CheckMix(AudioMix mix)
    {
        switch (mix)
        {
            case AudioMix.Music:
                return audioMix.outputAudioMixerGroup;
                break;
            case AudioMix.SFX:
                return audioMix.outputAudioMixerGroup;
                break;
        }
    }
}
