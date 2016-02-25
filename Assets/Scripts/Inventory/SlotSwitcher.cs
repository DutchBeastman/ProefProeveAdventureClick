using UnityEngine;
using System.Collections;

public class SlotSwitcher : MonoBehaviour {

	[SerializeField] GameObject[] slots;
	private int activeSlotNumber;

	protected void Awake() 
	{
		slots[activeSlotNumber].SetActive(true);
	}
	public void SwitchForward()
	{
		activeSlotNumber++;
		if (activeSlotNumber >= 5)
		{
			slots[4].SetActive(false);
			activeSlotNumber = 0;
			slots[activeSlotNumber].SetActive(true);
		}
		else
		{ 
		slots[activeSlotNumber - 1].SetActive(false);
		slots[activeSlotNumber].SetActive(true);
		}
	}
	
	public void SwitchBackward()
	{
	
		activeSlotNumber--;
		if (activeSlotNumber <= -1)
		{
			activeSlotNumber = 4;
			slots[0].SetActive(false);
			slots[activeSlotNumber].SetActive(true);
		}
		else
		{ 
		slots[activeSlotNumber + 1].SetActive(false);
		slots[activeSlotNumber].SetActive(true);
		}
	}
}
