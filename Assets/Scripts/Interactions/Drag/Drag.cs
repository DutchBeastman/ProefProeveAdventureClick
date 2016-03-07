using UnityEngine;
using System.Collections;
namespace Utils
{
	public class Drag : Click
	{
		private bool isDragging;

		private Vector3 moveToPos;
		[HideInInspector]
		public Vector3 originalPos;

		protected override void Awake()
		{
			base.Awake();
			originalPos = gameObject.transform.position;
		}
		protected override void Update()
		{
			base.Update();
			if (isDragging)
			{
				moveToPos = new Vector3(MousePosition.x , MousePosition.y , 0);
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position , moveToPos , 0.45f);
			}
			else if (!isDragging)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position , originalPos , 0.15f);
			}
		}
		protected override void OnClick()
		{
			base.OnClick();
			isDragging = true;
		}
		protected override void OnClickRelease()
		{
			base.OnClickRelease();
			isDragging = false;
		}
	}
}