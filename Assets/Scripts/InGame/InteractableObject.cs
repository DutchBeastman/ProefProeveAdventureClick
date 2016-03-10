using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;

public class InteractableObject : Click {

	[SerializeField]
	private Text dialogueText;
	[SerializeField]
	string objectText;

	protected void Start()
	{
	
	}
	protected override void OnClick()
	{
		base.OnClick();
		dialogueText = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<Text>();
		dialogueText.text = objectText;
	}
	protected virtual void OnItemUsed()
	{

	}
	public void DoOnItemUsed()
	{
		OnItemUsed();
	}
}
