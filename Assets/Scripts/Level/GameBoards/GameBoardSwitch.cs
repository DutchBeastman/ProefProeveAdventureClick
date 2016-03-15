using UnityEngine;
using System.Collections;
using Utils;

public class GameBoardSwitch : Click {
	[SerializeField] private GameBoardManager manager;
	[SerializeField] private int id;
	[SerializeField] private OverlayFade fade;

	protected override void Awake()
	{
		manager = FindObjectOfType<GameBoardManager>();
		fade = FindObjectOfType<OverlayFade>();
	}
	protected override void OnEnable()
	{
		base.OnEnable();
		fade = FindObjectOfType<OverlayFade>();
	}
	protected override void OnClick()
	{
		base.OnClick();
		if (!fade.fadeIn && !fade.fadeOut)
		{
			fade.FadeIn();
			Invoke("SwitchGameBoard" , 0.8f);
		}
	}
	private void SwitchGameBoard()
	{
		if (!fade.fadeOut)
		{
			manager.GotoGameboard(id);
			fade.FadeOut();
		}
	}
}
