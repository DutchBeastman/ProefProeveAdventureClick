using UnityEngine;
using System.Collections;

public class PepperPlantClickable : ClickableItem {

	
	protected override void OnClick()
	{
		Debug.Log("i am clicked");
	}
	protected override void OnClickRelease()
	{
	
	}
	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
	}
}
