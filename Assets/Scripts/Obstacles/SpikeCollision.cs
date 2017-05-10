using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			GameObject.FindObjectOfType<PlayerManager>().HitByObstacle();
		}
	}
}
