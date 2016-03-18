using UnityEngine;
using System.Collections;
using Utils;
public class SendDialogueOnClick : Click {

	// Use this for initialization
	[SerializeField]private string textToSend;
	// Update is called once per frame
	protected override void OnClick() 
	{
		base.OnClick();
		GlobalEvents.Invoke(new DialogueEvent(textToSend));
	}
}
