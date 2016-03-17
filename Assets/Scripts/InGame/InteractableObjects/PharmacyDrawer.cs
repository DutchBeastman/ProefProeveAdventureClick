﻿using UnityEngine;
using System.Collections;

public class PharmacyDrawer : InteractableObject {

	[SerializeField]private GameObject itemToActivate;
	[SerializeField]private Sprite imageAfterActivation;
	private bool activated;
    protected override void Awake()
	{
		base.Awake();

	}
	protected override void OnClick()
	{
		if (!activated)
		{
			base.OnClick();
		}
	}
	protected override void OnClickRelease()
	{
		base.OnClickRelease();
	}
	protected override void OnItemUsed()
	{
		base.OnItemUsed();
		Debug.Log("itemIsUsed");
		itemToActivate.SetActive(true);
		GetComponent<SpriteRenderer>().sprite = imageAfterActivation;
		activated = true;
	}
}
