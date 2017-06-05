using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Magnet player effect to pull pickable objects towards the player 
 */ 
public class MagnetEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SphereCollider> ().radius = Item.MagnetRadius;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Pickable") {
			col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, transform.position, Time.deltaTime*5f);
		}
	}
}
