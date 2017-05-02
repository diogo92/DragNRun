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
	GroundSpawner GS;
	List<GameObject> SpawnedObjects;
	ObjectPooling pool;

	bool initialDisable=true;

	void Awake(){
		GS = FindObjectOfType<GroundSpawner> ();
		pool = FindObjectOfType<ObjectPooling> ();
	}

	// Use this for initialization
	public void SpawnObject() {
		SpawnedObjects = new List<GameObject> ();
		//Randomly decide what to spawn
		int rand = 0;//Random.Range(0,3);
		switch (rand) {
		case 0:
			SpawnObstacle ();
			break;
		case 1:
			SpawnCollectable ();
			break;
		case 2:
			SpawnPowerup ();
			break;
		default:
			break;
		}
	}

	//Spawn an obstacle
	void SpawnObstacle(){
		GameObject NewObstacle = pool.GetObstacle (GS.AreaIndex);
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
	//Spawn a collectable
	void SpawnCollectable(){

	}
	//Spawn a powerup
	void SpawnPowerup(){

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
