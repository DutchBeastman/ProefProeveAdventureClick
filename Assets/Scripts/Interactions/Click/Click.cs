﻿using UnityEngine;
using System.Collections;

namespace Utils
{
	public class Click : MonoBehaviour
	{

		// Use this for initialization
		[SerializeField]
		private Collider2D clickArea;

		private bool isClicked;

		private Vector2 mousePosition;

		public Vector2 MousePosition
		{
			get
			{
				return mousePosition;
			}
		}
		public bool IsClicked
		{
			get
			{
				return isClicked;
			}
		}

		protected void OnDisable()
		{
			OnClickRelease();
		}

		protected virtual void Update()
		{

			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonDown(0))
			{
				if (clickArea != null)
				{
					if (ClickUtils.AreaContainsClick(clickArea.bounds , mousePosition))
					{
						OnClick();
					}
				}
				else
				{
					Debug.Log("No area was selected");
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				OnClickRelease();
			}
		}

		protected virtual void OnClickRelease()
		{
			if (isClicked)
			{
				isClicked = false;
			}
		}

		protected virtual void OnClick()
		{
			if (isClicked)
			{
				isClicked = false;
			}
			else
			{
				isClicked = true;
			}
			
		}
	}
}