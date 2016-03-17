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
	[SerializeField]private string usableObject;
	[SerializeField]private GameObject finishedGameObject;
	private Sprite itemImage;

	public string UsableObject
	{
		get
		{
			return usableObject;
		}
		set
		{
			usableObject = value;
		}
	}

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


	
	protected override void Awake() 
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
		if(gameObject.name == "RecipePieceOne" && finishedGameObject != null)
		{
			EndGame();
		}
	}

	private void EndGame()
	{
		finishedGameObject.SetActive(true);
		GameObject gamecanvas = GameObject.Find("GameCanvas");
		gamecanvas.SetActive(false);
		GameObject dialogueCanvas = GameObject.Find("DialogueCanvas");
		dialogueCanvas.SetActive(false);


		//fire pauze event
		GlobalEvents.Invoke(new PauzeEvent("pauze"));
	}
}
