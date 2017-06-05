using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * WIP class for the scene's background objects behaviour
 */ 
public class BackgroundScenery : MonoBehaviour {

	Vector3 StartingPos;

	void Start(){
		StartingPos = transform.localPosition;
	}

	void Update () {
		transform.localPosition += new Vector3 (0, 0, 0.05f * Time.deltaTime);
		Debug.Log (transform.localPosition.z - StartingPos.z);
		if (transform.localPosition.z - StartingPos.z >= 10f) {
			transform.localPosition -= new Vector3 (0, 0, transform.localPosition.z+10f);
			StartingPos = transform.localPosition;
		}
	}
}
