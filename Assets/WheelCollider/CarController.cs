using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController:MonoBehaviour {
	public WheelCollider fLWheel, fRWheel, rLWheel, rRWheel;
	public Transform fLTransform, fRTransform, rLTransform, rRTransform;
	public float maxSteerAngle = 30;
	public float motorForce = 50;

	float horizontalInput;
	float verticalInput;
	float steeringAngle;

	public void GetInput() {
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
	}

	public void Steer() {
		steeringAngle = maxSteerAngle*horizontalInput;
		fLWheel.steerAngle = steeringAngle;
		fRWheel.steerAngle = steeringAngle;
	}

	public void Accelerate() {
		rLWheel.motorTorque = verticalInput*motorForce;
		rRWheel.motorTorque = verticalInput*motorForce;
	}

	public void UpdateWheelPoses() {
		UpdateWheelPose(fLWheel, fLTransform);
		UpdateWheelPose(fRWheel, fRTransform);
		UpdateWheelPose(rLWheel, rLTransform);
		UpdateWheelPose(rRWheel, rRTransform);
	}

	public void UpdateWheelPose(WheelCollider wheelCollider, Transform transform) {
		Vector3 pos = transform.position;
		Quaternion quat = transform.rotation;
		wheelCollider.GetWorldPose(out pos, out quat);
		transform.position = pos;
		transform.rotation = quat;
	}

	private void FixedUpdate() {
		GetInput();
		Steer();
		Accelerate();
		UpdateWheelPoses();
	}
}
