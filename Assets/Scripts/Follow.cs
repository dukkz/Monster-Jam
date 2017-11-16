using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform followObject;
	public float lookSmooth = .09f;
	public Vector3 cameraOffset;
	public float xTilt = 10;

	Vector3 destination = Vector3.zero;
	CharController controller;
	float rotateVelocity = 0;
	bool menuOn;

	void Start(){
		SetCameraTarget (followObject);
		menuOn = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update(){
		if (menuOn == false) {
			Cursor.lockState = CursorLockMode.Locked;
		}
		if (Input.GetKeyDown (KeyCode.Escape) && menuOn == false) {
			menuOn = true;
		} else if (Input.GetKeyDown (KeyCode.Escape) && menuOn == true) {
			menuOn = false;
		}
	}

	void SetCameraTarget(Transform t){
		followObject = t;

		if (followObject != null) {
			if (followObject.GetComponent<CharController> ()) {
				controller = followObject.GetComponent<CharController> ();
			} else {
				Debug.LogError ("Object needs a character controller.");
			}
		} else {
			Debug.LogError ("The camera needs a target.");
		}
	}

	void LateUpdate(){
		MoveToTarget ();
		LookAtTarget ();
	}

	void MoveToTarget(){
		destination = controller.TargetRot * cameraOffset;
		destination += followObject.position;
		transform.position = destination;
	}

	void LookAtTarget(){
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, followObject.eulerAngles.y, ref rotateVelocity, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0);
	}
}
