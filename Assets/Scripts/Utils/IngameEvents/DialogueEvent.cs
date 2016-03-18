using UnityEngine;
using System.Collections;

namespace Utils
{
	public class DialogueEvent : IEvent {

		public string dialoguetext;
		public DialogueEvent(string text)
		{
			dialoguetext = text;
		}
	}
}
