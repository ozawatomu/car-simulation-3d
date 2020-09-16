using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour{

	public float maximumTorque;
	public float transitionSpeedUp;
	public float transitionSpeedDown;

	public float currentTorque = 0f;
	Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		if(Input.GetKey(KeyCode.S)) {
			currentTorque = Mathf.Lerp(currentTorque, maximumTorque, transitionSpeedUp*Time.fixedDeltaTime);
			rb.AddTorque(transform.forward*currentTorque*-1);
		} else {
			currentTorque = Mathf.Lerp(currentTorque, 0f, transitionSpeedDown*Time.fixedDeltaTime);
			rb.AddTorque(transform.forward*currentTorque*-1);
		}
	}
}
