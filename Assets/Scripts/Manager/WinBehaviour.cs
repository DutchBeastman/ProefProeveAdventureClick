using UnityEngine;
using System.Collections;
using Utils;

public class WinBehaviour : MonoBehaviour {

	[SerializeField] GameObject winObject;
	void OnEnable()
	{
		GlobalEvents.AddListener<WinEvent>(OnWinEvent);
	}
	
	void OnDisable()
	{
		GlobalEvents.RemoveListener<WinEvent>(OnWinEvent);
	}

	private void OnWinEvent(WinEvent evt)
	{
		winObject.SetActive(true);
		GlobalEvents.Invoke(new PauzeEvent("pauze"));
	}
}
