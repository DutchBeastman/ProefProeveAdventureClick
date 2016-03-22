using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;

public class ItemMixerBehaviour : MonoBehaviour {

	public List<ClickableItem> itemsInMixer;
	public List<ClickableItem> itemsNeededForMix;
	private bool shouldMix = true;
	[SerializeField]private ItemMixer interactableScript;
	private InventoryManager inventory;
	
	void OnEnable()
	{
		GlobalEvents.AddListener<AddItemToMixerEvent>(AddItemToMix);
		if (interactableScript == null)
		{
			interactableScript = GetComponent<ItemMixer>();
		}
		if (null == inventory)
		{
			inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
		}
	}
	void OnDisable()
	{
		GlobalEvents.RemoveListener<AddItemToMixerEvent>(AddItemToMix);
	}
	
	private void AddItemToMix(AddItemToMixerEvent evt)
	{
		interactableScript.shouldNotShowDialogue = true;
		itemsInMixer.Add(evt.itemToAdd);
		Debug.Log(itemsInMixer[0].ItemName);
	}
	public void AttemptMix()
	{
		for (int i = 0; i < itemsNeededForMix.Count; i++)
		{
			bool found = false;
			if (i + 1 > itemsInMixer.Count)
			{
				foreach (ClickableItem item in itemsInMixer)
				{
					inventory.AddInventoryItem(item);
				}
				for (int j = itemsInMixer.Count - 1; 0 < itemsInMixer.Count; --j)
				{
					itemsInMixer[j] = null;
					itemsInMixer.RemoveAt(j);
				}
				shouldMix = true;
				return;
			}

			if (itemsInMixer[i].ItemName == itemsNeededForMix[i].ItemName)
			{
				Debug.Log("shouldbefound" + itemsInMixer[i].ItemName);
				found = true;
			}
			Debug.Log(found);
			if (!found) shouldMix = false;
			Debug.Log(shouldMix);
		}
		if (shouldMix)
		{
			GlobalEvents.Invoke(new WinEvent());
		}
		else
		{

			foreach (ClickableItem item in itemsInMixer)
			{
				inventory.AddInventoryItem(item);
			}
			for (int i = itemsInMixer.Count - 1; 0 < itemsInMixer.Count; --i)
			{
				Debug.Log("remove item = " + i);
				itemsInMixer[i] = null;
				itemsInMixer.RemoveAt(i);
			}
		}
		shouldMix = true;
	}
}
