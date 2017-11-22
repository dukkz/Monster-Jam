using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {

	public float scale, massEaten;

	private float speed, jumpVel, downAccel, fallMulti;
	public Transform camera;

	CharController controller;
	Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharController> ();
		massEaten = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		speed = scale * 3.75f;
		jumpVel = scale * 8.75f;
		downAccel = scale / 2f;
		fallMulti = scale * 5f;
		cameraOffset = new Vector3 (0, scale * 1.5f, scale * -3f);


		transform.localScale = new Vector3(scale, scale, scale);
		camera.GetComponent<Follow> ().cameraOffset = cameraOffset;
		controller.jumpVelocity = jumpVel;
		controller.forwardVelocity = speed;
		controller.distToGround = scale / 2;
		controller.downAccel = downAccel;
		controller.fallMultiplier = fallMulti;
	}
}
