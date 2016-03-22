using UnityEngine;
using System.Collections;
using Utils;

public class StartBehaviour : MonoBehaviour {


	[SerializeField]private string[] StartDialogueTexts;
	[SerializeField]private Sprite letterImage;
	private bool imageIsActive;
	private bool continueText;
	private int textNumber;

	private void OnEnable()
	{
		GlobalEvents.AddListener<ShowImageEvent>(OnImageEvent);
	}
	private void OnDisable()
	{
		GlobalEvents.RemoveListener<ShowImageEvent>(OnImageEvent);
	}
	private void OnImageEvent(ShowImageEvent evt)
	{
		if(evt.shouldClose)
		{
			imageIsActive = false;
		}
	}
	private void Start()
	{
		if (PlayerPrefs.HasKey("FirstTime") == false)
		{
			Debug.Log("shouldPauze");
			GlobalEvents.Invoke(new PauzeEvent("pauze"));
			Sendtext();
		}
	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			PlayerPrefs.DeleteAll();
		}
		//Debug.Log(textNumber);
	}

	/// <summary>
	/// fires a dialogue event with all the start dialogue texts till its finished
	/// </summary>
	void Sendtext()
	{
		if(textNumber == 3)
		{
			GlobalEvents.Invoke(new PauzeEvent("resume"));
			GlobalEvents.Invoke(new ShowImageEvent(letterImage));
			imageIsActive = true;
			continueText = true;
		}
		if(continueText)
		{
			Invoke("Sendtext", 2f);
			textNumber++;
			continueText = false;
			Debug.Log(textNumber);
			return;
		}
		GlobalEvents.Invoke(new DialogueEvent(StartDialogueTexts[textNumber]));
		if(textNumber != StartDialogueTexts.Length -1)
		{
			textNumber++;
		}
		else
		{
			PlayerPrefs.SetFloat("FirstTime", 1f);
			GlobalEvents.Invoke(new PauzeEvent("resume"));
			return;
		}
		Invoke("Sendtext", 4f);
	}
}
