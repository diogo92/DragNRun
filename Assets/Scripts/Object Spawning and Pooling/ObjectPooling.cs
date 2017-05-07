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
	public int numPickables = 10;
	public int numCoins = 20;

	//Shared prefabs to pool
	public GameObject[] PickablesPrefabs;
	List<GameObject> PickablesList;
	public GameObject[] CoinPrefabs;
	List<GameObject> CoinList;

	//Prefabs to pool
	//Green Zone specifics
	public GameObject[] GreenZoneGroundPrefabs; 
	public GameObject[] GreenZoneObstaclePrefabs;
	List<GameObject> GreenZoneGroundList;
	List<GameObject> GreenZoneObstacleList;


	public void Awake(){
		PoolPickables ();
	}

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
	 * Zone shared pooling list
	 */
	void PoolPickables(){
		PickablesList = new List<GameObject> ();
		CoinList = new List<GameObject> ();
		int currIndex = 0;
		//Straight grounds
		for (int i = 0; i < numPickables; i++) {
			if (PickablesPrefabs.Length <= 0)
				break;
			if (currIndex >= PickablesPrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (PickablesPrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("PickablesParent").transform);
			obj.gameObject.SetActive (false);
			PickablesList.Add (obj);
			currIndex++;
		}
		for (int i = 0; i < numCoins; i++) {
			GameObject obj = Instantiate (CoinPrefabs [0]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("PickablesParent").transform);
			obj.gameObject.SetActive (false);
			CoinList.Add (obj);
		}
	}

	/*
	 * Green Zone Pooling list
	 */
	void PoolGreenZone(){
		GreenZoneGroundList = new List<GameObject> ();
		GreenZoneObstacleList = new List<GameObject> ();
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

	//Get Pickable
	public GameObject GetPickable(){
		int index = Random.Range (0, PickablesList.Count - 1);
		while (PickablesList [index].gameObject.activeInHierarchy) {
			index = Random.Range (0, PickablesList.Count - 1);
		}
		return PickablesList [index];
	}

	//Get Coin
	public GameObject GetCoin(){
		int index = Random.Range (0, CoinList.Count - 1);
		while (CoinList [index].gameObject.activeInHierarchy) {
			index = Random.Range (0, CoinList.Count - 1);
		}
		return CoinList [index];
	}
}
