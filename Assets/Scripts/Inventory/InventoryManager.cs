using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

	// Use this for initialization
	private List<InventoryItem> items;
	protected void Awake () 
	{
		items = new List<InventoryItem>();
	}

	public void AddInventoryItem(InventoryItem item) 
	{
		items.Add(item);
	}

	public void RemoveInventoryItem(InventoryItem item)
	{
		items.Remove(item);
	}

	public bool ContainsItem(InventoryItem item)
	{
		return items.Contains(item);
	}
}
