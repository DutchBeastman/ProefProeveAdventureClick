using UnityEngine;
using System.Collections;
using Utils;

public class StartBehaviour : MonoBehaviour {


	[SerializeField]private string[] StartDialogueTexts;
	private int textNumber;

	private void OnEnable()
	{
		
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
	}

	/// <summary>
	/// fires a dialogue event with all the start dialogue texts till its finished
	/// </summary>
	void Sendtext()
	{
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
