using UnityEngine;
using System.Collections;

public class InventoryItem : Click {

	// Use this for initialization
	private bool isPickedUp;
	[SerializeField]private InventoryManager inventory;
	
	// Update is called once per frame
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
