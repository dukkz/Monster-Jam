using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSetter : MonoBehaviour {


	public CharController character;
	public float scaleX, scaleY;

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		rend.material.mainTextureScale = new Vector2 (scaleX, scaleY);
		if (character.GetComponent<Scale> ().scale < 12f) {
			scaleX = 74f;
			scaleY = 100f;
		} else if (character.GetComponent<Scale> ().scale >= 20f && character.GetComponent<Scale> ().scale < 103f) {
			scaleX = 2.5f;
			scaleY = 5f;
		}
	}
}
