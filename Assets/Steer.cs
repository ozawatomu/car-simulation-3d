using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour{

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
	void Update() {
		if(Input.GetKey(KeyCode.D)) {
			rb.transform.rotation = Quaternion.Euler(0, 45, 0);
		}
	}
}
