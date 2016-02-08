using UnityEngine;
using System.Collections;
namespace Utils
{
	public class Drag : Click
	{
		private bool isDragging;
		// Update is called once per frame
		protected override void Update()
		{
			base.Update();
			if (isDragging)
			{
				gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
		}
	}
}