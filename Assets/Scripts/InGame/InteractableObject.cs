using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;

public class InteractableObject : Click {

	[SerializeField]
	string objectText;

	protected void Start()
	{
	
	}
	protected override void OnClick()
	{
		base.OnClick();
		GlobalEvents.Invoke(new DialogueEvent(objectText));
	}
	protected virtual void OnItemUsed()
	{

	}
	public void DoOnItemUsed()
	{
		OnItemUsed();
	}
}
