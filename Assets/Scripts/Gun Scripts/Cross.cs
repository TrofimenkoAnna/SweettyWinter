using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour {

	public Texture2D crossTexture;
	Rect position;

	// Use this for initialization
	void Start () {
		position = new Rect((Screen.width - crossTexture.width) / 2, (Screen.height - crossTexture.height) / 2, crossTexture.width, crossTexture.height);
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.DrawTexture(position, crossTexture);
	}
}
