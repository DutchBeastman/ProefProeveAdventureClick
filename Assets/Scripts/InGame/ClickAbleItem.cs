using UnityEngine;
using System.Collections;
using Utils;

public class ClickableItem : Click
{

	[SerializeField]InventoryManager inventory;

	[SerializeField]private string itemName;
	[SerializeField]private int itemId;
	[SerializeField]private int numberOfUsages;
	[SerializeField]private Transform target;
	private Sprite itemImage;

	public Transform Target
	{
		get
		{
			return target;
		}
		set
		{
			target = value;
		}
	}
	public Sprite ItemImage
	{
		get
		{
			return itemImage;
		}
	}
	public int NumberOfUsages 
	{
		get 
		{
			return numberOfUsages;
		}
	}
	public int ItemId
	{
		get
		{
			return itemId;
		}
	}
	public string ItemName
	{
		get
		{
			return itemName;
		}
	}


	
	protected void Awake() 
	{
		if(null == itemImage) 
		{
			itemImage = GetComponent<SpriteRenderer>().sprite;
		}
		if(null == inventory)
		{
			inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
		}

	}

	protected override void OnClick()
	{
		base.OnClick();
		inventory.AddInventoryItem(this);

	}

	protected override void OnClickRelease()
	{
		base.OnClickRelease();

	}

	public void OnAddedToInventory()
	{
		gameObject.SetActive(false);
	}

}
