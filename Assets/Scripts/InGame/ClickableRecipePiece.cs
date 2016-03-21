using UnityEngine;
using System.Collections;
using Utils;
public class ClickableRecipePiece : ClickableItem {

	protected override void Awake()
	{
		base.Awake();
		shouldNotAdd = true;
	}
	protected override void OnClick()
    {
        base.OnClick();
		GlobalEvents.Invoke(new RecipeEvent());
    }
}
