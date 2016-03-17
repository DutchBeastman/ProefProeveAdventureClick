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
				uiItems[i].ItemId = i;
				uiItems[i].ItemName = inventory.items[i].ItemName;
				uiItems[i].NumberOfUsages = inventory.items[i].NumberOfUsages;
				uiItems[i].ItemImage = inventory.items[i].ItemImage;
				uiItems[i].TargetPoint = inventory.items[i].Target;
				uiItems[i].UiUsableObject = inventory.items[i].UsableObject;
				uiItems[i].OnItemsSet();
			}
			RemoveItems();
		}

		public void RemoveItems()
		{
			for (int j = uiItems.Count - 1; j >= inventory.items.Count; j--)
			{
				if (uiItems[j].IsActive == true)
				{
					uiItems[j].ItemId = 0;
					uiItems[j].ItemName = null;
					uiItems[j].NumberOfUsages = 0;
					uiItems[j].ItemImage = null;
					uiItems[j].TargetPoint = null;
					uiItems[j].UiUsableObject = null;
					uiItems[j].OnItemsRemove();
				}
			}
		}
	}
}
