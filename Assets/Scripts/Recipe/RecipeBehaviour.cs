using UnityEngine;
using System.Collections;
using Utils;

public class RecipeBehaviour : MonoBehaviour {
	[SerializeField]
	private ClickableItem clickableitem;

	private InventoryManager inventory;

	private int recipies;
	void OnEnable()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
		GlobalEvents.AddListener<RecipeEvent>(RecipeCounter);
	}

	void OnDisable()
	{
		GlobalEvents.RemoveListener<RecipeEvent>(RecipeCounter);
	}

	private void RecipeCounter(RecipeEvent evt)
	{
		recipies++;
		Debug.Log(recipies + "Amount of");
		if (recipies == 4)
		{
			inventory.AddInventoryItem(clickableitem);
		}
	}
}

