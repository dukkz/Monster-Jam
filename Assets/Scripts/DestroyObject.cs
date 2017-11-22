using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DeleteThis", .25f);
	}

	void DeleteThis(){
		Destroy (gameObject);
	}

}
