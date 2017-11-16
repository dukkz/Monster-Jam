using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opaque : MonoBehaviour {

	public Transform cam;
	public Transform player;
	public LayerMask mask;

	Ray ray;
	RaycastHit hit;
	Vector3 direction;
	float distance;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		direction = player.position - cam.position;
		distance = direction.magnitude;
		Debug.DrawRay (cam.transform.position, direction, Color.red);
		if (Physics.Raycast (cam.position, direction, out hit, distance, mask)) {
			if (hit.transform.tag == "Opaque") {
				hit.transform.GetComponent<Renderer> ().enabled = false;
				//rend.enabled = false;
			}
		} else {
			rend.enabled = true;
		}
	}
}
