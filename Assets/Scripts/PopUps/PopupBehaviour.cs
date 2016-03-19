using UnityEngine;
using System.Collections;
using Utils;

[RequireComponent(typeof(SpriteRenderer))]
public class PopupBehaviour : MonoBehaviour {

	[SerializeField]private SpriteRenderer spriteRenderer;

	void OnEnable () 
	{
		if(spriteRenderer == null)
		{
			spriteRenderer.GetComponent<SpriteRenderer>();
		}
		GlobalEvents.AddListener<ShowImageEvent>(ShowNewImage);
	}

	void OnDisable()
	{
		GlobalEvents.RemoveListener<ShowImageEvent>(ShowNewImage);
	}

	private void ShowNewImage(ShowImageEvent evt)
	{
		spriteRenderer.sprite = evt.showingImage;
	}
}
