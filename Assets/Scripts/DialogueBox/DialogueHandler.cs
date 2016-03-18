using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Utils;

[RequireComponent(typeof(Text))]
public class DialogueHandler : MonoBehaviour {

	private Text dialogueText;
	private bool textFound;
	private Color originalColor;
	[SerializeField]private Animator animationController;
	// Use this for initialization
	void Awake () {
		if(dialogueText == null)
		{ 
			dialogueText = GetComponent<Text>();
			textFound = true;
			originalColor = dialogueText.color;
		}
	}
	protected void OnEnable()
	{
		GlobalEvents.AddListener<DialogueEvent>(SetText);
	}

	protected void OnDisable()
	{
		GlobalEvents.RemoveListener<DialogueEvent>(SetText);
	}
	// Update is called once per frame
	private void SetText(DialogueEvent evt)
	{
		dialogueText.text = evt.dialoguetext;
		dialogueText.color = originalColor;
		Invoke("StartFade", 2f);
		textFound = false;
		animationController.Play("DialogueBox");
	}
	void Update () {
	//	if (dialogueText.text != "" && textFound == true)
		//{
	//		Invoke("StartFade", 2f);
	//		textFound = false;
	//		animationController.Play("DialogueBox");
	//	}
	}

	private void StartFade()
	{
		Color color = dialogueText.color;
		color.a -= 0.1f;
		dialogueText.color = color;

		if(color.a <= 0) {
			dialogueText.color = originalColor;
			textFound = true;
			dialogueText.text = "";
			animationController.SetBool("GoingDown", true);
			Debug.Log("goingdown");
			return;
		}
		if (color.a != 0)
		{
			Debug.Log("staying");
			animationController.SetBool("Staying", true);
			Invoke("StartFade", 0.1f);
		}
	}
}
