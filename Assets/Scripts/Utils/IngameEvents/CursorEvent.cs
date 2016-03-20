using UnityEngine;
using System.Collections;

namespace Utils
{
	public class CursorEvent : IEvent
	{
		public CursorState currentcursorstate;
		public CursorEvent(CursorState state)
		{
			currentcursorstate = state;
		}
	}
}
