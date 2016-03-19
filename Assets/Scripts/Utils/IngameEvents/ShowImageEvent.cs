using UnityEngine;
using System.Collections;

namespace Utils
{ 
	public class ShowImageEvent : IEvent {

		public Sprite showingImage;
		public bool shouldClose;
		// Use this for initialization
		public ShowImageEvent(Sprite image)
		{
			showingImage = image;
			if(image != null)
			{
				shouldClose = true;
			}
			else
			{
				shouldClose = false;
			}
		}
	}
}