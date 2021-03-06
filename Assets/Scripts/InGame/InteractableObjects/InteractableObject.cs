﻿using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;

public class InteractableObject : Click {

	[SerializeField]
	string objectText;
	public bool shouldNotShowDialogue;

	protected override void OnClick()
	{
		base.OnClick();
		if (!shouldNotShowDialogue)
		{ 
		GlobalEvents.Invoke(new DialogueEvent(objectText));
		}
	}
	protected virtual void OnItemUsed()
	{

	}
	public void DoOnItemUsed()
	{
		OnItemUsed();
	}
}
