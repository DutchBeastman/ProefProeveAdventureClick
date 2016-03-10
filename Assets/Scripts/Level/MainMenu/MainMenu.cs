using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	[SerializeField]private GameObject[] objectsToActivate;
	// Use this for initialization
	void Start () {
	
	}

	public void StartGame()
	{
		
		for (int i = 0; i < objectsToActivate.Length; i++)
		{
			objectsToActivate[i].SetActive(true);
		}
		gameObject.SetActive(false);
	}
}
