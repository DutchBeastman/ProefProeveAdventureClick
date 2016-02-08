using UnityEngine;
using System.Collections;
namespace Utils
{
	public static class ClickUtils
	{

		public static bool AreaContainsClick(Bounds area , Vector2 mousePosition)
		{
			if (Input.GetMouseButton(0))
			{
				if (area.Contains(mousePosition))
				{
					return true;
				}
			}
			return false;
		}
	}
}
