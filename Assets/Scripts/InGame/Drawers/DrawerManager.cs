using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private DrawerOpener[] markedDrawers;

	[SerializeField]
	private DrawerOpener[] allDrawers;
    private bool keyActivated;

	protected virtual void Awake()
	{
		
	}
    private void Update()
    {
        CheckDrawers();
    }
    private void CheckDrawers()
    {
		int j = new int();
		int i = new int();
        foreach (DrawerOpener markedOnes in markedDrawers)
        {
            if (markedOnes.IsClosed == false)
            {
                i++;
                Debug.Log(i);
            }
        }
        if (i == markedDrawers.Length)
        {
            KeyAppear();
        }
        else
        {
            i = 0;
        }
		foreach (DrawerOpener openDrawer in allDrawers)
		{
			if (!openDrawer.IsClosed)
			{
				Debug.Log("J =   " +   j);
				j++;
				if (j > 4)
				{
					i = 0;
					j = 0;
					for (int k = 0; k < allDrawers.Length; k++)
					{
						allDrawers[k].IsClosed = true;
					}		
				}
			}
		}
		
    }
    private void KeyAppear()
    {
        if (!keyActivated)
        {
            key.SetActive(true);
            keyActivated = true;
        }
    }
}

