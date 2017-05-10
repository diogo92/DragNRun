using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			//Destroy the obstacle
			if (collision.gameObject.GetComponent<Rigidbody> ())
				collision.gameObject.GetComponent<Rigidbody> ().AddForce (0, 0f, 1000f, ForceMode.Impulse);
			GameObject.FindObjectOfType<PlayerManager>().HitByObstacle();
		}
	}
}
