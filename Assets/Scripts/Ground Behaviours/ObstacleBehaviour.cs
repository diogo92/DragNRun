using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 
 * Behavior for obstacle objects
 *
 */
public class ObstacleBehaviour : MonoBehaviour {

	void OnCollisionEnter(Collision Other){
		if (Other.gameObject.tag == "Player") {
			//TODO: set behavior for player hitting

		}
	}
}
