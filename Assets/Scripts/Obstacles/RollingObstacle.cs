using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingObstacle : MonoBehaviour {

	public float rotationSpeed = 5f;
	public float movementSpeed = 2f;
	public float heightError = 0.02f;
	private Rigidbody rb;
	// Update is called once per frame
	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void OnEnable(){
		transform.localScale = new Vector3 (0.20648f, 0.20648f, 0.20648f);
	}
	void Update () {
		if (GetComponentInChildren<Renderer> ().isVisible) {
			rb.velocity = new Vector3(0,-2f, movementSpeed);
		} else {
			rb.velocity = Vector3.zero;
		}	
			
	}
}
