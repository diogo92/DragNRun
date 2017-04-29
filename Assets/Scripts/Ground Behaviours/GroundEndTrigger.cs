using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEndTrigger : MonoBehaviour {

	GroundSpawner spawner;

	void Start(){
		if (spawner == null)
			spawner = FindObjectOfType<GroundSpawner> ();
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			StartCoroutine (Deactivate ());		
	}

	IEnumerator Deactivate(){
		yield return new WaitForSeconds (2f);
		spawner.SpawnGround ();
		if (GetComponentInParent<ObjectSpawn> ()) {
			GetComponentInParent<ObjectSpawn> ().DestroyObject ();
		}
		transform.parent.gameObject.SetActive(false);
	}
}
