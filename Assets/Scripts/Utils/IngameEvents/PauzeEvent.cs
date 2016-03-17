using UnityEngine;
using System.Collections;

namespace Utils
{
	public class PauzeEvent : IEvent
	{
		public STATES state;
		public enum STATES
		{
			pauze, resume
		}

		public PauzeEvent(string pauzeState)
		{
			switch (pauzeState)
			{
				case "pauze":
					state = STATES.pauze;
					break;

				case "resume":
					state = STATES.resume;
					break;

				default:
					break;
			}
		}
	}
}
