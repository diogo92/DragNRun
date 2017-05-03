using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 	Player Manager Script
 */
public class PlayerManager : MonoBehaviour {

	/*
	 *	Active player controller
	 */ 
	GameObject CurrentActivePlayer;

	/*
	 * 	Distance score calculation variables
	 */

	//Total distance run
	public float DistanceRun = 0f;
	//Last calculated Z player position
	float lastZPosition = 0f;



	// Use this for initialization
	void Start () {
		DistanceRun = 0f;
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "Player") {
				if (child.gameObject.activeInHierarchy) {
					CurrentActivePlayer = child.gameObject;
					break;
				}
			}
		}
		lastZPosition = CurrentActivePlayer.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		DistanceRun += Mathf.Abs(CurrentActivePlayer.transform.position.z - lastZPosition);
		lastZPosition = CurrentActivePlayer.transform.position.z;
	}

}
