using UnityEngine;
using System.Collections;

public class ScaleObjectToScreen : MonoBehaviour {

	// Use this for initialization
	protected virtual void Awake () {
		double height = Camera.main.orthographicSize * 1.1;
		double width =  Camera.main.orthographicSize * 1.2;
		transform.localScale = new Vector3((float)width , (float)height , 0.1f);
	}
}
