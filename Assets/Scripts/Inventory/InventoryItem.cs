using UnityEngine;
using System.Collections;
using Utils;

public class InventoryItem : Click {

	private bool isPickedUp;
	[SerializeField]private InventoryManager inventory;

	protected override void Update () 
	{
		base.Update();
	}

	protected override void OnClick()
	{
		base.OnClick();
		inventory.AddInventoryItem(this);
	}

	public void OnAddedToInventory() 
	{
		Debug.Log("added");
		gameObject.SetActive(false);
	}
}
