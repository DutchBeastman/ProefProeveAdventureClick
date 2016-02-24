using UnityEngine;
using System.Collections;

public class AudioClipObject : ClickableItem {
	[SerializeField]
	private AudioClip audioClip;
	private AudioManager audioManager;

	public enum audioMix
	{
		Music,
		SFX
	}

	protected override void OnClick()
	{
		base.OnClick();
		
	}
}
