using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DialogueHandler : MonoBehaviour {

	private Text dialogueText;
	private bool textFound;
	private Color originalColor;
	// Use this for initialization
	void Awake () {
		if(dialogueText == null)
		{ 
			dialogueText = GetComponent<Text>();
			textFound = true;
			originalColor = dialogueText.color;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueText.text != "" && textFound == true)
		{
			Invoke("StartFade", 2f);
			textFound = false;
		}
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
			return;
		}
		if (color.a != 0)
		{
			Invoke("StartFade", 0.1f);
		}
	}
}
