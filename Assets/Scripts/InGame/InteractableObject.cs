﻿using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;

public class InteractableObject : Click {


	private Text dialogueText;
	[SerializeField]
	string objectText;
	// Use this for initialization
	void Awake() 
	{
		dialogueText = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<Text>();
		Debug.Log(dialogueText);
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
}
