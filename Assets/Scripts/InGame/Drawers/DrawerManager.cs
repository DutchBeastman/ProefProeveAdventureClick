using UnityEngine;
using System.Collections;

public class DrawerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private DrawerOpener[] markedDrawers;

    private bool keyActivated;
    private void Update()
    {
        CheckDrawers();
    }
    private void CheckDrawers()
    {
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

