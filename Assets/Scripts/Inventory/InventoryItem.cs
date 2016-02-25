using UnityEngine;
using System.Collections;
using Utils;
using UnityEngine.UI;
namespace Utils
{
	public class InventoryItem : Drag
	{

		private bool isPickedUp;
		[SerializeField]private InventoryManager inventory;

		[SerializeField]private Transform targetPoint;
		[SerializeField][Range(0.1f, 5f)]private float distanceToPoint = 2.0f;

		[SerializeField]private string itemName;
		[SerializeField]private int itemId;
		[SerializeField]private int numberOfUsages;
		private Sprite itemImage;
		private bool isActive;

		private Vector3 startPos;

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
			if (IsOnPoint())
			{
				inventory.RemoveInventoryItem(ItemId);
			}
		}

		protected override void OnClick()
		{
			base.OnClick();
		}
		public void OnItemsSet()
		{
			GetComponent<Image>().sprite = ItemImage;
			IsActive = true;
			gameObject.SetActive(true);
			originalPos = transform.position;
		}
		public void OnItemsRemove()
		{
			GetComponent<Image>().sprite = null;
			IsActive = false;
			gameObject.SetActive(false);
		}
		private bool IsOnPoint()
		{
			if (targetPoint != null)
			{
				Vector3 offset = targetPoint.position - transform.position;
				float sqrLen = offset.sqrMagnitude;
				if (sqrLen < distanceToPoint * distanceToPoint)
				{
					return true;
				}
			}
			return false;
		}
	}
}
