using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;
namespace Utils
{
	public class InventoryItem : Click
	{

		private bool isPickedUp;
		[SerializeField]private InventoryManager inventory;

		[SerializeField]private string itemName;
		[SerializeField]private int itemId;
		[SerializeField]private int numberOfUsages;
		private Sprite itemImage;
		private bool isActive;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				isActive = value;
			}
		}
		public Sprite ItemImage
		{
			get
			{
				return itemImage;
			}
			set
			{
				itemImage = value;
			}
		}
		public int NumberOfUsages
		{
			get
			{
				return numberOfUsages;
			}
			set
			{
				numberOfUsages = value;
			}
		}

		public int ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				 itemId = value;
			}
		}

		public string ItemName
		{
			get
			{
				return itemName;
			}
			set
			{
				  itemName = value;
			}
		}

		protected void Awake()
		{
			if(inventory == null)
			{
					inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
			}
		}
		protected override void Update()
		{
			base.Update();
		}

		protected override void OnClick()
		{
			base.OnClick();
			inventory.RemoveInventoryItem(ItemId);
		}

		public void OnItemsSet()
		{
			GetComponent<Image>().sprite = ItemImage;
			IsActive = true;
			gameObject.SetActive(true);
		}
		public void OnItemsRemove()
		{
			GetComponent<Image>().sprite = null;
			IsActive = false;
			gameObject.SetActive(false);
		}
	}
}
