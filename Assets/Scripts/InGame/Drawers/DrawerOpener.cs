using UnityEngine;
using System.Collections;
using Utils;

public class DrawerOpener : Click {
	[SerializeField]
	private Sprite closedDrawer;
	[SerializeField]
	private Sprite openDrawer;

	protected override void OnClick()
	{
		base.OnClick();
		//if(gameObject.sprite)
	}

}
