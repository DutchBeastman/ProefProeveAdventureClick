using UnityEngine;
using System.Collections;

public class DrawerManager : MonoBehaviour
{
    [SerializeField]
    private DrawerOpener[] markedDrawers;

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
        Debug.Log("DoneKEYAPPEAR");
    }
}

