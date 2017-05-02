using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour {

	public float rotationSpeed = 180f;
	public float fallingSpeed = 5f;
	public float timeToReset = 4f;

	float currTime = 0f;

	public Transform SpawnTransform;

	public Vector3 OriginalPosition;
	public Vector3 HeightedOriginalPosition;

	private Rigidbody rb;
	void Awake(){

		rb = GetComponent<Rigidbody> ();
	}
	void Start(){
		OriginalPosition = transform.localPosition;
		rb.AddTorque(new Vector3(0,0,rotationSpeed));
	}

	void OnEnable(){
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + 10f, transform.localPosition.z);
		HeightedOriginalPosition = transform.localPosition;
		rb.velocity = Vector3.zero;
		rb.AddTorque(new Vector3(0,0,rotationSpeed));
	}

	void Update () {
		if (transform.position.y <= SpawnTransform.position.y) {
			currTime += Time.deltaTime;
			if (currTime >= timeToReset) {
				transform.localPosition = HeightedOriginalPosition;
				currTime = 0;
				rb.velocity = Vector3.zero;
				rb.AddTorque(new Vector3(0,0,rotationSpeed));
			}
		}

	}

	void OnDisable(){
		transform.localPosition = OriginalPosition;
		currTime = 0;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			//Destroy the obstacle
			GetComponentInChildren<SplitMeshIntoTriangles>().SplitMesh();
		}
	}
}
