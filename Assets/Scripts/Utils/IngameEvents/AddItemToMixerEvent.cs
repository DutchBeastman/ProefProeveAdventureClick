using UnityEngine;
using System.Collections;

namespace Utils
{ 
	public class AddItemToMixerEvent : IEvent {

		public ClickableItem itemToAdd;

		public AddItemToMixerEvent(ClickableItem item)
		{
			itemToAdd = item;
		}

	}
}
