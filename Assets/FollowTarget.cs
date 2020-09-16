using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
	public Transform target;
	public Transform desiredPosition;
	public float smoothSpeed = 0.125f;
	public Vector3 lookOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition.position, smoothSpeed);
		transform.position = smoothedPosition;
		transform.LookAt(target.position + lookOffset);
	}
}
