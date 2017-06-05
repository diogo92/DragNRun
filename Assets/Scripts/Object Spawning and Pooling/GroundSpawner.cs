using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Ground objects spawner class
 */ 
public class GroundSpawner : MonoBehaviour {

	bool starting = true;
	ObjectPooling pool;
	Transform NextTransform;

	void Start () {
		//Initialize the position and get object from pool
		NextTransform = transform;
		NextTransform.position = Vector3.zero;
		NextTransform.rotation = Quaternion.identity;
		pool = GetComponent<ObjectPooling> ();
		pool.PoolObjects ();
		//Spawn 10 grounds at the start
		for (int i = 0; i < 10; i++) {
			SpawnGround ();
		}
		starting = false;
	}

	//Spawn function to find next position and get an object from the ground object pool
	public void SpawnGround(){
		//Get object from pool
		GameObject NextGround = pool.GetGround ();
		float randY = 0;
		//Reset the object scale
		NextGround.transform.localScale = Vector3.one;
		//Check if it's not spawning the first 10 grounds, and randomize the height position of the ground
		if(!starting)
			randY = Random.Range (-3f, 3f);
		NextGround.transform.position = NextTransform.position + new Vector3 (0, randY, 0);
		//Clamp the position to make sure it stays within bounds
		Vector3 ClampedPos = new Vector3 (NextGround.transform.position.x, Mathf.Clamp (NextGround.transform.position.y, -10, 10), NextGround.transform.position.z);
		NextGround.transform.position = ClampedPos;
		NextGround.transform.rotation = NextTransform.rotation;
		//Randomize the scale
		float randScale = Random.Range (1f, 1.5f);
		NextGround.transform.localScale *= randScale;
		NextGround.SetActive (true);
		//Spawn powerups and traps in the ground object
		if (NextGround.GetComponent<ObjectSpawn> ()) {
			NextGround.GetComponent<ObjectSpawn> ().SpawnObject ();
		}
		//Find the transform where the next ground should be spawned
		NextTransform = Helper.FindComponentInChildWithTag<Transform> (NextGround, "AttachPoint");
	}

}
