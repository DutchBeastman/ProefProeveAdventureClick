using UnityEngine;
using System.Collections;
using Utils;
namespace Utils
{
	public class InventoryItem : Click
	{

		private bool isPickedUp;
		[SerializeField]
		private InventoryManager inventory;

		protected override void Update()
		{
			base.Update();
		}

		protected override void OnClick()
		{
			base.OnClick();
		}

		public void OnAddedToInventory()
		{
			Debug.Log("added");
			inventory.AddInventoryItem(this);
		}
	}
}
