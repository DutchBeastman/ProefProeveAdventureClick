using UnityEngine;
using System.Collections;
using Utils;

public class DrawerOpener : Click {
	//[SerializeField]
	//private Sprite closedDrawer;
	[SerializeField]
	private Sprite openDrawer;

    private SpriteRenderer spriteRend; 
    private bool isClosed;

    public bool IsClosed
    {
        get
        {
            return isClosed;
        }
		set
		{
			isClosed = value;
		}
    }

	protected override void Update()
	{
		base.Update();
		if (isClosed)
		{
			//spriteRend.sprite = closedDrawer;;
			spriteRend.enabled = false;
		}
		else if(!isClosed)
		{
			spriteRend.sprite = openDrawer;
			spriteRend.enabled = true;
		}
	}

	protected override void Awake()
    {
        base.Awake();
        isClosed = true;
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
		spriteRend.enabled = false;
    }
    protected override void OnClick()
	{
		base.OnClick();
        if (isClosed)
        {
            spriteRend.sprite = openDrawer;
			spriteRend.enabled = true;
            isClosed = false;
        }else if (!isClosed)
        {
			spriteRend.enabled = false;
            isClosed = true;
        }
	}

}
