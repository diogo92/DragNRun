using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

	public float rotationDegree = 90f;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, rotationDegree * Time.deltaTime, 0);
	}
}
