using UnityEngine;
using System.Collections;
using Utils;

public class ClickableItem : Click
{

	[SerializeField]InventoryManager inventory;

	[SerializeField]private string itemName;
	[SerializeField]private int itemId;
	[SerializeField]private int numberOfUsages;
	private Sprite itemImage;

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
