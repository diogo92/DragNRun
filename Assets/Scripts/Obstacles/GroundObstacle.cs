using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		transform.localScale = new Vector3 (0.20648f, 0.20648f, 0.20648f);
	}
}
