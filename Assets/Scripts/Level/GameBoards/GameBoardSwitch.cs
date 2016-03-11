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
	protected override void OnClick()
	{
		base.OnClick();
		fade.FadeIn();
		Invoke("SwitchGameBoard" , 0.8f);
	}
	private void SwitchGameBoard()
	{
		manager.GotoGameboard(id);
		fade.FadeOut();
	}
}
