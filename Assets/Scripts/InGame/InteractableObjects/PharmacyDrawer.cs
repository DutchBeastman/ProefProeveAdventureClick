using UnityEngine;
using System.Collections;

public class PharmacyDrawer : InteractableObject {

	[SerializeField]private GameObject itemToActivate;
	[SerializeField]private Sprite imageAfterActivation;
    protected override void Awake()
	{
		base.Awake();
		//ActivateItem = false;
		Debug.Log(itemToActivate);
		//itemToActivate.SetActive(false);
		Debug.Log(ActivateItem);
	}

	protected override void OnClick()
	{
		base.OnClick();
	}
	protected override void OnClickRelease()
	{
		base.OnClickRelease();
	}
	protected override void Update()
	{
		base.Update();
		if(ActivateItem)
		{
			Debug.Log("usingItem");
			OnItemUsedYes();
		}
	}
	private void OnItemUsedYes()
	{
		Debug.Log("itemIsUsed");
		itemToActivate.SetActive(true);
		GetComponent<SpriteRenderer>().sprite = imageAfterActivation;
		ActivateItem = false;
	}
}
