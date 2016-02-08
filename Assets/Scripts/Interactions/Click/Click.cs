using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	// Use this for initialization
	[SerializeField]private Collider2D clickArea;
	[SerializeField]private bool isClicked;
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		if(Input.GetMouseButton(0)) 
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (clickArea != null)
			{
				if (ClickUtils.AreaContainsClick(clickArea.bounds, mousePosition))
				{
					OnClick();
				}
			}
			else
			{
				Debug.Log("No area was selected");
			}
		}
	}

	protected virtual void OnClick() 
	{
		Debug.Log("clicking");
	}
}
