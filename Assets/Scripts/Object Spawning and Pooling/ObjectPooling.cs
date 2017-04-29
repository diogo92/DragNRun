using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * Object pooling
 * 
 */
public class ObjectPooling : MonoBehaviour {

	//Amounts to pool
	public int numGrounds = 15;
	public int numObstacles = 30;
	public int numCollectables = 100;

	//Prefabs to pool
	//Green Zone specifics
	public GameObject[] GreenZoneGroundPrefabs; 
	public GameObject[] GreenZoneObstaclePrefabs;
	public GameObject[] GreenZoneCollectablePrefabs;
	List<GameObject> GreenZoneGroundList;
	List<GameObject> GreenZoneObstacleList;
	List<GameObject> GreenZoneCollectableList;

	public void PoolObjectsForArea(int Area){
		switch (Area) {
		case 0:
			PoolGreenZone ();
			break;
		default:
			break;
		}
	}

	void DeleteObjectsForArea(int Area){

	}

	/*
	 * Green Zone Pooling list
	 */
	void PoolGreenZone(){
		GreenZoneGroundList = new List<GameObject> ();
		GreenZoneObstacleList = new List<GameObject> ();
		GreenZoneCollectableList = new List<GameObject> ();
		int currIndex = 0;
		//Straight grounds
		for (int i = 0; i < numGrounds; i++) {
			if (GreenZoneGroundPrefabs.Length <= 0)
				break;
			if (currIndex >= GreenZoneGroundPrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (GreenZoneGroundPrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("GroundsParent").transform);
			obj.gameObject.SetActive (false);
			GreenZoneGroundList.Add (obj);
			currIndex++;
		}
		currIndex = 0;
		//Obstacles
		for (int i = 0; i < numObstacles; i++) {
			if (GreenZoneObstaclePrefabs.Length <= 0)
				break;
			if (currIndex >= GreenZoneObstaclePrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (GreenZoneObstaclePrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("ObstaclesParent").transform);
			obj.gameObject.SetActive (false);
			GreenZoneObstacleList.Add (obj);
			currIndex++;
		}
		currIndex = 0;
		//Collectables
		for (int i = 0; i < numCollectables; i++) {
			if (GreenZoneCollectablePrefabs.Length <= 0)
				break;
			if (currIndex >= GreenZoneCollectablePrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (GreenZoneCollectablePrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("CollectablesParent").transform);
			obj.gameObject.SetActive (false);
			GreenZoneCollectableList.Add (obj);
			currIndex++;
		}
		currIndex = 0;
	}


	//Get Straight ground
	public GameObject GetGround(int Area){
		switch (Area) {
		case 0:
			int index = Random.Range (0, GreenZoneGroundList.Count - 1);
			while (GreenZoneGroundList [index].gameObject.activeInHierarchy) {
				index = Random.Range (0, GreenZoneGroundList.Count - 1);
			}
			return GreenZoneGroundList [index];
		default:
			break;
		}
		return null;
	}

	//Get Obstacle
	public GameObject GetObstacle(int Area){
		switch (Area) {
		case 0:
			int index = Random.Range (0, GreenZoneObstacleList.Count - 1);
			while (GreenZoneObstacleList [index].gameObject.activeInHierarchy) {
				index = Random.Range (0, GreenZoneObstacleList.Count - 1);
			}
			return GreenZoneObstacleList [index];
		default:
			break;
		}

		return null;
	}

	//Get Collectable
	public GameObject GetCollectable(int Area){
		switch (Area) {
		case 0:
			int index = Random.Range (0, GreenZoneCollectableList.Count - 1);
			while (GreenZoneCollectableList [index].gameObject.activeInHierarchy) {
				index = Random.Range (0, GreenZoneCollectableList.Count - 1);
			}
			return GreenZoneCollectableList [index];
		default:
			break;
		}

		return null;
	}
}
