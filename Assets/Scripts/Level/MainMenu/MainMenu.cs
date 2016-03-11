using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	[SerializeField]private GameObject[] objectsToActivate;
	[SerializeField]private GameObject optionsMenu;
	[SerializeField]private GameObject extrasMenu;
	[SerializeField]private GameObject mainMenu;

	public void StartGame()
	{
		
		for (int i = 0; i < objectsToActivate.Length; i++)
		{
			objectsToActivate[i].SetActive(true);
		}
		gameObject.SetActive(false);
	}
	public void Options()
	{
		mainMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}
	public void Extras()
	{
		mainMenu.SetActive(false);
		extrasMenu.SetActive(true);
	}
	public void BackToMainMenu()
	{
		mainMenu.SetActive(true);
		optionsMenu.SetActive(false);
		extrasMenu.SetActive(false);
    }
	public void Quit()
	{
		Application.Quit();
	}
}
