using UnityEngine;
using System.Collections;
using Utils;
public class CursorBehaviour : MonoBehaviour
{
	[SerializeField]
	private Texture2D doorTexture;
	[SerializeField]
	private Texture2D grabTexture;
	[SerializeField]
	private Texture2D magnifyTexture;
	[SerializeField]
	private Texture2D normalTexture;

	protected void OnEnable()
	{
		GlobalEvents.AddListener<CursorEvent>(OnCursorEvent);
	}

	protected void OnDisable()
	{
		GlobalEvents.RemoveListener<CursorEvent>(OnCursorEvent);
	}

	/// <summary>
	/// checks the event state and resumes or pauzes accordingly.
	/// </summary>
	/// <param name="evt">event sent</param>
	public void OnCursorEvent(CursorEvent evt)
	{
		switch (evt.currentcursorstate)
		{
			case CursorState.Door:
				Cursor.SetCursor(doorTexture , Vector2.zero , CursorMode.Auto);
				break;
			case CursorState.Grab:
				Cursor.SetCursor(grabTexture , Vector2.zero , CursorMode.Auto);
				break;
			case CursorState.Magnify:
				Cursor.SetCursor(magnifyTexture , Vector2.zero , CursorMode.Auto);
				break;
			case CursorState.Normal:
				Cursor.SetCursor(normalTexture , Vector2.zero , CursorMode.Auto);
				break;
			default:
				Cursor.SetCursor(normalTexture , Vector2.zero , CursorMode.Auto);
				break;
		}
	}
}