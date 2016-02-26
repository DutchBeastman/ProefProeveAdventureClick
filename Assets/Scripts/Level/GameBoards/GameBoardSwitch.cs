using UnityEngine;
using System.Collections;
using Utils;

public class GameBoardSwitch : Click {
	[SerializeField] private GameBoardManager manager;
	[SerializeField] private int id;

	protected override void Awake()
	{
		manager = FindObjectOfType<GameBoardManager>();
	}
	protected override void OnClick()
	{
		base.OnClick();
		manager.GotoGameboard(id);
	}
}
