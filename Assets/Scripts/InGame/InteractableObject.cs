using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;

public class InteractableObject : Click {

	public bool ActivateItem;
	private Text dialogueText;
	[SerializeField]
	string objectText;
	// Use this for initialization
	protected override void Awake() 
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
	protected virtual void OnItemUsed()
	{

	}
	public void DoOnItemUsed()
	{
		OnItemUsed();
	}
}
