using UnityEngine;
using System.Collections;
using Utils;

public class PepperPlant : InteractableObject {

	[SerializeField] ClickableItem pepperItem;
	InventoryManager inventory;
	protected override void OnEnable()
	{
		base.OnEnable();
		GlobalEvents.AddListener<CutPlantEvent>(plantIsCut);
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		GlobalEvents.RemoveListener<CutPlantEvent>(plantIsCut);
	}
	private void plantIsCut(CutPlantEvent evt)
	{
		
		inventory.AddInventoryItem(pepperItem);
		Debug.Log("lmooei");
	}
}
