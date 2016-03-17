using UnityEngine;
using System.Collections;
using Utils;
public class PauzeBehaviour : MonoBehaviour
{

	private Collider2D[] colliders;

	protected void OnEnable()
	{
		GlobalEvents.AddListener<PauzeEvent>(OnPauzeEvent);
	}

	protected void OnDisable()
	{
		GlobalEvents.RemoveListener<PauzeEvent>(OnPauzeEvent);
	}

	/// <summary>
	/// checks the event state and resumes or pauzes accordingly.
	/// </summary>
	/// <param name="evt">event sent</param>
	public void OnPauzeEvent(PauzeEvent evt)
	{
		if(evt.state == PauzeEvent.STATES.pauze)
		{
			colliders = FindObjectsOfType<Collider2D>() as Collider2D[];
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].enabled = false;
			}
		}
		else if(evt.state == PauzeEvent.STATES.resume)
		{
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].enabled = true;
			}
		}
	}
}
