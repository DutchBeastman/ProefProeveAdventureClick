using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
	public class InventoryManager : MonoBehaviour
	{

		// Use this for initialization
		public List<ClickableItem> items;
		public List<ClickableItem> neededItems;
		[SerializeField]private InventoryUI inventoryUI;
		[SerializeField]private List<InventoryItem> inventoryItems;

		protected void Awake()
		{
			items = new List<ClickableItem>();
		}
		public void AddInventoryItem(ClickableItem item)
		{
			items.Add(item);
			item.OnAddedToInventory();
			inventoryUI.UpdateInventory();
			//if (items.Contains(neededItems[0]))
			//{
			//	GlobalEvents.Invoke(new WinEvent());
			//}
		}

		public void RemoveInventoryItem(int itemID)
		{
			items.RemoveAt(itemID);
			inventoryUI.UpdateInventory();
		}

		public bool ContainsItem(ClickableItem item)
		{
			return items.Contains(item);
		}

		//developing purposes(can be deleted)
		public void ShowItemNames() 
		{
			for (int i = 0; i < items.Count; i++)
			{
			}
		}

	}
}