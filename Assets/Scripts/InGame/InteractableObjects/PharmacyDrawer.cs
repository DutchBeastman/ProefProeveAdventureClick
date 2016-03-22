using UnityEngine;
using System.Collections;

public class PharmacyDrawer : InteractableObject {

	[SerializeField]private GameObject itemToActivate;
	[SerializeField]private Sprite imageAfterActivation;
	[SerializeField]private SpriteRenderer Background;
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
		itemToActivate.SetActive(true);
		Background.sprite = imageAfterActivation;
		activated = true;
	}
}
