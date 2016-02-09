using UnityEngine;
using System.Collections;
namespace Utils
{
	public class Drag : Click
	{
		private bool isDragging;

		private Vector3 moveToPos;

		private float speed; 

		private void Awake()
		{
			speed = 0.4f;
		}
		protected override void Update()
		{
			base.Update();
			if (isDragging)
			{
				moveToPos = new Vector3(MousePosition.x , MousePosition.y , 0);
				float distance = Vector3.Distance(gameObject.transform.position , moveToPos);
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position , moveToPos, distance * speed);
			}
		}
		protected override void OnClick()
		{
			base.OnClick();
			if (IsClicked)
			{
				isDragging = true;
			}
		}
		protected override void OnClickRelease()
		{
			base.OnClickRelease();
			if (!IsClicked)
			{
				isDragging = false;
			}
		}
	}
}