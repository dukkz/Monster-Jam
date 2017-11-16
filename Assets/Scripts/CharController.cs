using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	public float inputDelay = .1f, forwardVelocity = 15, jumpVelocity = 25f, downAccel = .75f, fallMultiplier = 2.5f, rotateVelocity = 150, distToGround = 1f;
	public LayerMask groundMask;
	public bool running = false;

	Quaternion targetRotation;
	Rigidbody rb;
	float forwardInput, turnInput, jumpInput, strafeInput;
	Vector3 velocity;

	public Quaternion TargetRot
	{
		get { return targetRotation; }
	}

	void Start(){
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody>()) {
			rb = GetComponent<Rigidbody> ();
		} else
			Debug.LogError ("No RB, dude.");

		forwardInput = turnInput = strafeInput = jumpInput = 0f;
		velocity = Vector3.zero;
	}

	void GetInput(){
		forwardInput = Input.GetAxis ("Vertical");
		strafeInput = Input.GetAxis ("Horizontal");
		turnInput = Input.GetAxis ("Turn");
		jumpInput = Input.GetAxisRaw ("Jump");
	}

	void Update(){
		Debug.DrawRay (transform.GetChild (0).transform.position, Vector3.down, Color.red);
		Debug.DrawRay (transform.GetChild (1).transform.position, Vector3.down, Color.red);
		Debug.DrawRay (transform.GetChild (2).transform.position, Vector3.down, Color.red);
		Debug.DrawRay (transform.GetChild (3).transform.position, Vector3.down, Color.red);
		GetInput ();
		Turn ();

		if(Input.GetButtonDown("Run")){
			running = true;
		}

		//if (Mathf.Abs (rb.velocity.magnitude) == 0) {
		//	running = false;
		//}
		if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
			running = false;
		}
	}

	void FixedUpdate(){
		Run ();
		Strafe ();
		Jump ();

		rb.velocity = transform.TransformDirection (velocity);
		if (rb.velocity.y < 0) {
			velocity.y += Physics.gravity.y * fallMultiplier * Time.deltaTime;
		} else if (rb.velocity.y > 0 && Input.GetAxisRaw ("Jump") == 0) {
			velocity.y += Physics.gravity.y * (fallMultiplier * 3) * Time.deltaTime;
		}
	}

	void Run(){
		if (Mathf.Abs (forwardInput) > inputDelay && !running) {
			velocity.z = forwardVelocity * forwardInput;
		} else if (Mathf.Abs (forwardInput) > inputDelay && running) {
			velocity.z = forwardVelocity * forwardInput * 2.5f;
		} else {
			velocity.z = 0;
		}
	}

	void Turn(){
		targetRotation *= Quaternion.AngleAxis (rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

	void Jump(){
		if (Input.GetAxisRaw ("Jump") > 0 && Grounded()) {
			velocity.y = jumpVelocity;
		} else if (Input.GetAxisRaw("Jump") == 0 && Grounded()){
			velocity.y = 0;
		} else {
			velocity.y -= downAccel;
		}
	}

	bool Grounded(){
		if (Physics.Raycast (transform.position, Vector3.down, distToGround + (distToGround * .1f), groundMask) || Physics.Raycast (transform.GetChild(0).transform.position, Vector3.down, distToGround, groundMask) || Physics.Raycast (transform.GetChild(1).transform.position, Vector3.down, distToGround, groundMask) || Physics.Raycast (transform.GetChild(2).transform.position, Vector3.down, distToGround, groundMask) || Physics.Raycast (transform.GetChild(3).transform.position, Vector3.down, distToGround, groundMask)) {
			return true;
		} else {
			return false;
		}
	}

	void Strafe(){
		if (Mathf.Abs (strafeInput) > inputDelay) {
			velocity.x = forwardVelocity * strafeInput;
		} else {
			velocity.x = 0;
		}
	}

}
