using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Simple rotation behaviour for an object
 */
public class ObjectRotation : MonoBehaviour {

	public float rotationDegree = 90f;
	public bool RotateAroundPlayer = false;
	public Transform target;

	public bool Oscilate;
	float timer = 0f;
	bool Direction = false;
	// Update is called once per frame

	void Update () {
		if (!Oscilate) {
			if (RotateAroundPlayer && target) {
				transform.RotateAround (target.position, Vector3.up, rotationDegree * Time.deltaTime);
			} else {
				transform.Rotate (0, rotationDegree * Time.deltaTime, 0);
			}
		} else {
			if (timer <= 20f) {
				timer += Time.deltaTime;
				//move left
				if (!Direction)
					transform.position += new Vector3 (0, 0, 3 * Time.deltaTime);
				//move right
				else
					transform.position -= new Vector3 (0, 0, 1 * Time.deltaTime);
			} else {
				timer = 0;
				Direction = !Direction;
			}

		}
	}
}
