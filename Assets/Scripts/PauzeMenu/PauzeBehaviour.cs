using UnityEngine;
using System.Collections;
using Utils;
public class PauzeBehaviour : MonoBehaviour {

	private Collider2D[] colliders;


	protected void OnEnable()
	{
		GlobalEvents.AddListener<PauzeEvent>(OnPauzeEvent);
		Debug.Log("added listener pauze");
	}
	protected void OnDisable()
	{
		GlobalEvents.RemoveListener<PauzeEvent>(OnPauzeEvent);
	}
	/// <summary>
	/// Finds all colliders active in the scene and disables them.
	/// </summary>
	public void OnPauzeEvent(PauzeEvent evt)
	{
		Debug.Log("Pauze Event Fired");
		colliders = FindObjectsOfType<Collider2D>() as Collider2D[];
		for (int i = 0; i < colliders.Length; i++)
		{
			colliders[i].enabled = false;
		}
	}

	/// <summary>
	/// enables the found colliders in the scene.
	/// </summary>
	public void OnResume()
	{
		for (int i = 0; i < colliders.Length; i++)
		{
			colliders[i].enabled = true;
		}
	}

}
