using UnityEngine;
using System.Collections;
using Utils;
public class PauzeMenu : MonoBehaviour {
	
	/// <summary>
	/// fires a resume event to the manager.
	/// </summary>
	public void ActivateResume()
	{
		GlobalEvents.Invoke(new PauzeEvent("resume"));
	}
}
