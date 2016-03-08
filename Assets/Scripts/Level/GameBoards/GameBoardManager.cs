using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameBoardManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> gameBoards;
	private List<GameObject> boards;

	private int currentID;

	protected void Awake()
	{
		boards = new List<GameObject>();
		for (int i = 0; i < gameBoards.Count; i++)
		{
			boards.Add(Instantiate(gameBoards[i] , transform.position , Quaternion.identity) as GameObject);
			boards[i].SetActive(false);
		}
	}
	protected void Start()
	{
		currentID = 0;
		GotoGameboard(currentID);
	}
	public void GotoGameboard(int id)
	{
		if (currentID != id)
		{
			boards[currentID].SetActive(false);
		}
		boards[id].SetActive(true);
		currentID = id;
	}
}
