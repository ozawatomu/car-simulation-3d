using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxAngularVelocity:MonoBehaviour
{
	public float maxAngularVelocity;

	Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = maxAngularVelocity;
	}

	// Update is called once per frame
	void Update() {

	}
}
