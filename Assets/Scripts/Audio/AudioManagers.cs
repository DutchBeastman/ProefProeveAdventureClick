using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;


public class AudioManagers : MonoBehaviour
{
	[SerializeField]
	private List<AudioSource> music;

	protected void Awake()
	{
		for (int i = 0; i < music.Count; i++)
		{
			music[i].Play();
		}
	}
}
