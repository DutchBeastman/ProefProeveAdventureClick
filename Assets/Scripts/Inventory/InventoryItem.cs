﻿using UnityEngine;
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
		[SerializeField]private string uiUsableObject;
		[SerializeField]private bool clickableInventoryItem;
		[SerializeField]private Sprite showableImage;
		private Sprite itemImage;
		private bool isActive;

		private Vector3 startPos;

		public bool ClickableInventoryItem
		{
			get
			{
				return clickableInventoryItem;
			}
			set
			{
				clickableInventoryItem = value;
			}
		}

		public Sprite ShowableImage
		{
			get
			{
				return showableImage;
			}
			set
			{
				showableImage = value;
			}
		}

		public string UiUsableObject
		{
			get
			{
				return uiUsableObject;
			}
			set
			{
				uiUsableObject = value;
			}
		}

		public Transform TargetPoint
		{
			get
			{
				return targetPoint;
			}
			set
			{
				targetPoint = value;
			}
		}
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

		protected override void Awake()
		{
			if(inventory == null)
			{
					inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
			}
		}
		protected override void Update()
		{
			base.Update();
			if(ClickableInventoryItem)
			{
				isDragging = false;
			}
			if (IsOnPoint())
			{
				if (uiUsableObject != "" )
				{
					GameObject.Find(uiUsableObject).GetComponent<InteractableObject>().DoOnItemUsed();
					OnClickRelease();
				}
                inventory.RemoveInventoryItem(ItemId);
			}
		}

		protected override void OnClick()
		{
			base.OnClick();
			if(clickableInventoryItem && showableImage != null)
			{
				GlobalEvents.Invoke(new ShowImageEvent(showableImage));
			}
		}
		public void OnItemsSet()
		{
			GetComponent<Image>().sprite = ItemImage;
			IsActive = true;
			Invoke("SetNewPosition", 0.5f);
		}
		private void SetNewPosition()
		{
			gameObject.SetActive(true);
			originalPos = transform.position;
		}
		public void OnItemsRemove()
		{
			GetComponent<Image>().sprite = null;
			IsActive = false;
			gameObject.SetActive(false);
			gameObject.transform.position = originalPos;
		}
		private bool IsOnPoint()
		{
			if (targetPoint != null)
			{
				Vector3 point = Camera.main.ScreenToWorldPoint(transform.position);
				point.z += 10;
				Vector3 offset = targetPoint.position - point;
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
