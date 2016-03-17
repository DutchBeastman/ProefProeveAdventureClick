using UnityEngine;
using System.Collections;
using Utils;

public class PlayAudioUI : MonoBehaviour {

	private AudioAsset audioAsset;

	private AudioManager audioManager;

	protected virtual void Awake()
	{
		audioManager = GameDependencies.Get<AudioManager>();
	}

	public void PlayAudio(AudioAsset audio)
	{
		audioManager.Play(audio);
		Debug.Log(audioAsset);
	}
}
