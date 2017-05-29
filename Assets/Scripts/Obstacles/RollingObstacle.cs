using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingObstacle : MonoBehaviour {

	public float rotationSpeed = 5f;
	public float movementSpeed = 2f;
	public float heightError = 0.02f;
	private Rigidbody rb;
	// Update is called once per frame
	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void OnEnable(){
		transform.localPosition = new Vector3 (2.5f, transform.localPosition.y, transform.localPosition.z);
		transform.localScale = new Vector3 (0.20648f, 0.20648f, 0.20648f);
	}
	void Update () {
		if (GetComponentInChildren<Renderer> ().isVisible) {
			rb.velocity = new Vector3(0,-2f, movementSpeed);
		} else {
			rb.velocity = Vector3.zero;
		}	
			
	}

	void OnDisable(){
		rb.velocity = Vector3.zero;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			//Destroy the obstacle
			GetComponentInChildren<SplitMeshIntoTriangles>().SplitMesh();
			PlayerManager.Instance.HitByObstacle();
		}
	}

}
