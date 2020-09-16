using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour{

	public float brakeIntensity;

	Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		if(Input.GetKey(KeyCode.S)) {
			rb.AddTorque(-rb.angularVelocity*brakeIntensity*Time.fixedDeltaTime);
		}
	}
}
