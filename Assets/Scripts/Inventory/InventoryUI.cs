using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Utils
{
	public class InventoryUI : MonoBehaviour {

		// Use this for initialization
		[SerializeField]private List<InventoryItem> uiItems;
		[SerializeField]private InventoryManager inventory;

		public void UpdateInventory()
		{
			for (int i = 0; i < inventory.items.Count; i++)
			{
				Debug.Log(uiItems[i].name);
				uiItems[i].ItemId = i;
				uiItems[i].ItemName = inventory.items[i].ItemName;
				uiItems[i].NumberOfUsages = inventory.items[i].NumberOfUsages;
				uiItems[i].ItemImage = inventory.items[i].ItemImage;
				uiItems[i].OnItemsSet();
			}
		}
	}
}
