using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Utils;

[RequireComponent(typeof(Text))]
public class DialogueHandler : MonoBehaviour {

	private Text dialogueText;
	private Color originalColor;
	[SerializeField]private bool isPlaying;
	[SerializeField]private Animator animationController;
	private int timer;
	// Use this for initialization
	void Awake () {
		if(dialogueText == null)
		{ 
			dialogueText = GetComponent<Text>();
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
		
		if (!isPlaying) {
			dialogueText.color = originalColor;
			StartFade();
			animationController.Play("DialogueBox");
			isPlaying = true;
		}
	}

	private void StartFade()
	{
	
		Color color = dialogueText.color;
		if (timer >= 4)
		{
			
			color.a -= 0.05f;
			dialogueText.color = color;
			if (color.a <= 0) {
				dialogueText.color = originalColor;
				isPlaying = false;
				dialogueText.text = "";
				timer = 0;
				return;
			}
		}
		if (color.a != 0)
		{
			isPlaying = true;
			Invoke("StartFade", 0.1f);
			timer++;
		}
	}
}
