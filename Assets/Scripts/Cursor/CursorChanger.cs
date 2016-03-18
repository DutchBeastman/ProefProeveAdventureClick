using UnityEngine;
using System.Collections;
using Utils;

	public enum CursorState
	{
		Door,
		Normal,
		Grab,
		Magnify
	}

public class CursorChanger : MonoBehaviour {

	[SerializeField]
	private CursorState cursor;

	void OnMouseEnter()
	{
		GlobalEvents.Invoke(new CursorEvent(cursor));
    }
	void OnDisable()
	{
		GlobalEvents.Invoke(new CursorEvent(CursorState.Normal));
	}
	void OnMouseExit()
	{
		GlobalEvents.Invoke(new CursorEvent(CursorState.Normal));
	}
}
