using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour {

	public float mass;

	GameObject player;
	float scaleToEat;

	void Start(){
		scaleToEat = transform.localScale.y;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player" && player.GetComponent<Scale> ().scale >= scaleToEat * 1.5f) {
			player.GetComponent<Scale> ().massEaten += mass;
			player.GetComponent<Scale> ().scale += mass / 2;
			Destroy (gameObject);
		}
	}


}
