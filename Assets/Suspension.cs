using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour {
	public Rigidbody vehicleBody;
	public Vector3 connectionPoint;
	public float springConstant;
	public float restLength;
	public float dampingCoefficient = 1.0f;
	public float forceEfficiency = 0.9f;

	bool isStarted = false;
	Vector3 bodyRelativePoint;
	float lastSpringLength;

	void Start () {
		isStarted = true;
		bodyRelativePoint = (transform.position + connectionPoint) - vehicleBody.transform.position;
		if(restLength == 0) {
			restLength = ((transform.position + connectionPoint) - transform.position).magnitude;
		}
		Vector3 bodyPoint = vehicleBody.transform.position
				+ vehicleBody.transform.right*bodyRelativePoint.x
				+ vehicleBody.transform.forward*bodyRelativePoint.y
				- vehicleBody.transform.up*bodyRelativePoint.z;
		lastSpringLength = (bodyPoint - transform.position).magnitude;
	}

	void FixedUpdate () {
		Rigidbody thisBody = GetComponent<Rigidbody>();
		Vector3 bodyPoint = vehicleBody.transform.position
				+ vehicleBody.transform.right*bodyRelativePoint.x
				+ vehicleBody.transform.forward*bodyRelativePoint.y
				- vehicleBody.transform.up*bodyRelativePoint.z;
		Vector3 thisPoint = transform.position;

		float springLength = (bodyPoint - transform.position).magnitude;
		float springDisplacement = restLength - springLength;
		float springForce = springConstant*springDisplacement*Time.fixedDeltaTime;
		float springVelocity = (lastSpringLength - springLength)/Time.fixedDeltaTime;
		float dampingForce = dampingCoefficient*springVelocity*Time.fixedDeltaTime;

		Vector3 suspensionForce = (springForce + dampingForce)*vehicleBody.transform.forward*forceEfficiency;

		vehicleBody.AddForceAtPosition(suspensionForce, bodyPoint);
		thisBody.AddForceAtPosition(-suspensionForce, transform.position);

		//vehicleBody.AddForceAtPosition(-vehicleBody.transform.forward*dampingForce, bodyPoint);
		//thisBody.AddForceAtPosition(vehicleBody.transform.forward*dampingForce, transform.position);
		lastSpringLength = springLength;
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, 0.025f);
		if(!isStarted) {
			Vector3 bodyPoint = transform.position + connectionPoint;
			Gizmos.DrawWireSphere(bodyPoint, 0.025f);

			Gizmos.color = Color.green;
			Gizmos.DrawLine(bodyPoint, bodyPoint + vehicleBody.transform.forward*(-restLength));
		} else {
			Vector3 bodyPoint = vehicleBody.transform.position
				+ vehicleBody.transform.right*bodyRelativePoint.x
				+ vehicleBody.transform.forward*bodyRelativePoint.y
				- vehicleBody.transform.up*bodyRelativePoint.z;
			Gizmos.DrawWireSphere(bodyPoint, 0.025f);

			Gizmos.color = Color.green;
			Gizmos.DrawLine(bodyPoint, bodyPoint + vehicleBody.transform.forward*(-restLength));
		}
	}
}
