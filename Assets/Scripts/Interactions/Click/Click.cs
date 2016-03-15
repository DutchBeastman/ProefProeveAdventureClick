using UnityEngine;
using System.Collections;

namespace Utils
{
	public class Click : MonoBehaviour
	{
		[SerializeField]public Collider2D clickArea;
		[SerializeField]private bool isUIElement;
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
		protected virtual void Awake()
		{
			
		}
		protected virtual void Update()
		{
			if(!isUIElement) 
			{ 
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
			else
			{
				mousePosition = Input.mousePosition;
            }

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
			isClicked = isClicked ? false : true;
		}

		protected virtual void OnClick()
		{
			isClicked = isClicked ? false : true;
		}
		protected virtual void OnEnable()
		{
			if (clickArea == null)
			{
				clickArea = gameObject.GetComponent<Collider2D>();
			}
		}
	}
}