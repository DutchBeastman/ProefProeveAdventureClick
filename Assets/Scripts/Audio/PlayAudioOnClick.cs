using UnityEngine;
using System.Collections;
using Utils;

public class PlayAudioOnClick : Click {
	[SerializeField] private AudioAsset audioAsset;

	private AudioManager audioManager;

	protected override void Awake()
	{
		audioManager = GameDependencies.Get<AudioManager>();
	}

	protected override void OnClick()
	{
		base.OnClick();
		audioManager.Play(audioAsset);
	}
}
