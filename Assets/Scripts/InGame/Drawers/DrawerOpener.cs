using UnityEngine;
using System.Collections;
using Utils;

public class DrawerOpener : Click {
	[SerializeField]
	private Sprite closedDrawer;
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
			spriteRend.sprite = closedDrawer;;
		}
		else if(!isClosed)
		{
			spriteRend.sprite = openDrawer;
		}
	}

	protected override void Awake()
    {
        base.Awake();
        isClosed = true;
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        spriteRend.sprite = closedDrawer;
    }
    protected override void OnClick()
	{
		base.OnClick();
        if (isClosed)
        {
            spriteRend.sprite = openDrawer;
            isClosed = false;
        }else if (!isClosed)
        {
            spriteRend.sprite = closedDrawer;
            isClosed = true;
        }
	}

}
