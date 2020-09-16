using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public float turnSpeed = 10f;

	void Update() {
		transform.Rotate(new Vector3(0, Time.deltaTime*turnSpeed, 0));
	}
}
