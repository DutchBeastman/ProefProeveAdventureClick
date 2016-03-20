using UnityEngine;
using System.Collections;
using Utils;
public class ClickableRecipePiece : ClickableItem {
    
    protected override void OnClick()
    {
        base.OnClick();
        GlobalEvents.Invoke<RecipeEvent>();
    }
}
