using UnityEngine;
using System.Collections;

public class ItemMixer : InteractableObject
{
	private ItemMixerBehaviour itemMixerbehaviour;
	protected override void Awake()
	{
		base.Awake();

	}
	protected override void OnEnable()
	{
		base.OnEnable();
		if(itemMixerbehaviour == null)
		{ 
		itemMixerbehaviour = GetComponent<ItemMixerBehaviour>();
		}
	}
	protected override void OnClick()
	{
			base.OnClick();
			itemMixerbehaviour.AttemptMix();
	}
	protected override void OnClickRelease()
	{
		base.OnClickRelease();
	}
	protected override void OnItemUsed()
	{
		base.OnItemUsed();
	
	}
}
