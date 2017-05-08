using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

	public float rotationDegree = 90f;
	public bool RotateAroundPlayer = false;
	public Transform target;
	// Update is called once per frame

	void Update () {
		if (RotateAroundPlayer && target) {
			transform.RotateAround (target.position, Vector3.up, rotationDegree*Time.deltaTime);
		} else {
			transform.Rotate (0, rotationDegree * Time.deltaTime, 0);
		}
	}
}
