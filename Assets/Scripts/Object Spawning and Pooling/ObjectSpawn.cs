using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * Script for spawning objects when ground objects are created.
 * These include Obstacles, collectables or powerups.
 * 
 */
public class ObjectSpawn : MonoBehaviour {

	public enum GroundType{
		Straight, 	//Ground is a straight line
		Heighted	//Ground has height difference
	}

	public GroundType type;
	//Array for obstacle prefabs
	public GameObject[] obstacles;
	//Array for collectable prefabs
	public GameObject[] collectable;
	//Array for powerup prefabs
	public GameObject[] powerups;

	//Reference to object points;
	public Transform[] objectSpawnTransforms;
	List<GameObject> SpawnedObjects;
	ObjectPooling pool;

	bool initialDisable=true;

	void Awake(){
		pool = FindObjectOfType<ObjectPooling> ();
	}

	// Use this for initialization
	public void SpawnObject() {
		SpawnedObjects = new List<GameObject> ();
		//Randomly decide what to spawn
		//35% chance of not spawning obstacles or powerups
		if (Random.value > 0.35f) {
			//40% chance of spawning a powerup and 60% chance of spawning an obstacle
			if (Random.value > 0.4f) {
				SpawnObstacle ();
			} else {
				SpawnPowerup ();
			}
		}
		//50% chance of spawning coins
		if (Random.value > 0.5f) {
			SpawnCollectable ();
		}
	}

	//Spawn an obstacle
	void SpawnObstacle(){
		GameObject NewObstacle = pool.GetObstacle ();
		int randPos = Random.Range (0, objectSpawnTransforms.Length-1);
		NewObstacle.transform.position = objectSpawnTransforms[randPos].position;
		if (NewObstacle.GetComponent<SpikeObstacle> ())
			NewObstacle.transform.parent = transform;
		else if (NewObstacle.GetComponent<FallingObstacle> ())
			NewObstacle.GetComponent<FallingObstacle> ().SpawnTransform = objectSpawnTransforms[randPos];
		NewObstacle.transform.rotation = objectSpawnTransforms[randPos].rotation;
		NewObstacle.SetActive (true);
		SpawnedObjects.Add (NewObstacle);

	}
	//Spawn a collectable (coins, etc)
	void SpawnCollectable(){
		GameObject NewCoin = pool.GetCoin ();
		foreach(Transform coinChild in NewCoin.transform){
			coinChild.gameObject.SetActive (true);
		}
		int randPos = Random.Range (0, objectSpawnTransforms.Length-1);
		NewCoin.transform.position = objectSpawnTransforms[randPos].position;
		NewCoin.transform.position += new Vector3 (0, 0.5f, 0);
		NewCoin.transform.eulerAngles = objectSpawnTransforms [randPos].eulerAngles;
		NewCoin.SetActive (true);
		SpawnedObjects.Add (NewCoin);
	}
	//Spawn a powerup
	void SpawnPowerup(){
		GameObject NewPowerup = pool.GetPickable ();
		int randPos = Random.Range (0, objectSpawnTransforms.Length-1);
		NewPowerup.transform.position = objectSpawnTransforms[randPos].position;
		NewPowerup.transform.position += new Vector3 (0, 0.5f, 0);
		NewPowerup.SetActive (true);
		SpawnedObjects.Add (NewPowerup);
	}

	void OnDisable(){
		if (!initialDisable)
			DestroyObject ();
		else
			initialDisable = false;
	}

	public void DestroyObject(){
		for (int i = 0; i < SpawnedObjects.Count; i++) {
			if(SpawnedObjects[i] != null)
				SpawnedObjects [i].SetActive (false);
		}
		SpawnedObjects.Clear ();
	}
}
