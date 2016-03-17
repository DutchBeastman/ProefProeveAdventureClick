using UnityEngine;
using System.Collections;
using Utils;

public class MenuButtonBehaviour : MonoBehaviour {

	/// <summary>
	/// fires a pauze event to the manager.
	/// </summary>
	public void ActivatePause()
	{
		GlobalEvents.Invoke(new PauzeEvent("pauze"));
	}
}
