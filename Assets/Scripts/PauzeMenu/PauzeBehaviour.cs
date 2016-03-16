using UnityEngine;
using System.Collections;

public class PauzeBehaviour : MonoBehaviour {

	public Collider colliderz;
	public Collider2D[] colliders;

	/// <summary>
	/// Finds all colliders active in the scene and disables them.
	/// </summary>
	public void OnPauze()
	{
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
