using UnityEngine;
using System.Collections;
using Utils;

public class ClosePopup : Click {

	private bool shouldImageClose;
	protected override void OnEnable()
	{
		base.OnEnable();
		GlobalEvents.AddListener<ShowImageEvent>(CloseImage);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GlobalEvents.RemoveListener<ShowImageEvent>(CloseImage);
	}

	private void CloseImage(ShowImageEvent evt)
	{
		shouldImageClose = evt.shouldClose;
	}
	protected override void OnClick()
	{
		base.OnClick();
		if(shouldImageClose)
		{ 
		GlobalEvents.Invoke(new ShowImageEvent(null));
		}
	}
}
