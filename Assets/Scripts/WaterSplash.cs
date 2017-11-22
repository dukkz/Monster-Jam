using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour {

	public GameObject splash;

	void OnTriggerStay(Collider col){
		Splash (col);
	}

	void Splash(Collider col){
		GameObject splish = Instantiate (splash, col.transform.position + new Vector3(0, -col.transform.localScale.y / 2, 0), Quaternion.identity) as GameObject;
	}
}
