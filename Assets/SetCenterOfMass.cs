using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfMass : MonoBehaviour {
	public Transform centerOfMass;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = centerOfMass.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
