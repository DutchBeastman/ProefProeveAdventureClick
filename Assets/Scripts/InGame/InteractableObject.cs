﻿using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;

public class InteractableObject : Click {

	private Text dialogueText;
	[SerializeField]
	string objectText;
	// Use this for initialization
	protected override void Awake() 
	{
		dialogueText = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<Text>();
	}

	protected override void OnClick()
	{
		base.OnClick();
        dialogueText.text = objectText;
	}
	protected override void OnClickRelease()
	{
		base.OnClickRelease();
	}
	protected override void Update()
	{
		
		base.Update();
	}
	protected virtual void OnItemUsed()
	{

	}
	public void DoOnItemUsed()
	{
		OnItemUsed();
	}
}
