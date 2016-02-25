using UnityEngine;
using System.Collections;
using Utils;

public enum AudioMix
{
    Music,
    SFX
}

public class AudioClipObject : Click
{
    [SerializeField]
    private AudioClip audioClip;
	[SerializeField]
    private AudioManager audioManager;

    public AudioMix sounds;

    protected override void OnClick()
    {
		Debug.Log(sounds);
        base.OnClick();
        audioManager.PlayClip(audioClip, sounds);
    }
}
