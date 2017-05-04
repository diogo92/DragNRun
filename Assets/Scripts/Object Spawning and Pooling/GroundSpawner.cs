using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

	bool starting = true;
	ObjectPooling pool;
	public int AreaIndex = 0;
	Transform NextTransform;
	// Use this for initialization
	void Start () {
		NextTransform = transform;
		NextTransform.position = Vector3.zero;
		NextTransform.rotation = Quaternion.identity;
		pool = GetComponent<ObjectPooling> ();
		pool.PoolObjectsForArea (AreaIndex);
		//Spawn 10 grounds at the start
		for (int i = 0; i < 10; i++) {
			SpawnGround ();
		}
		starting = false;
	}

	public void SpawnGround(){
		GameObject NextGround = pool.GetGround (AreaIndex);
		float randY = 0;
		NextGround.transform.localScale = Vector3.one;
		if(!starting)
			randY = Random.Range (-3f, 3f);
		NextGround.transform.position = NextTransform.position + new Vector3 (0, randY, 0);
		Vector3 ClampedPos = new Vector3 (NextGround.transform.position.x, Mathf.Clamp (NextGround.transform.position.y, -10, 10), NextGround.transform.position.z);
		NextGround.transform.position = ClampedPos;
		NextGround.transform.rotation = NextTransform.rotation;
		float randScale = Random.Range (1f, 1.5f);
		NextGround.transform.localScale *= randScale;
		NextGround.SetActive (true);
		if (NextGround.GetComponent<ObjectSpawn> ()) {
			NextGround.GetComponent<ObjectSpawn> ().SpawnObject ();
		}
		NextTransform = Helper.FindComponentInChildWithTag<Transform> (NextGround, "AttachPoint");
	}

}
