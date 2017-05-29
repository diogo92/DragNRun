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
	public GameObject[] GroundPrefabs; 
	public GameObject[] ObstaclePrefabs;
	List<GameObject> GroundList;
	List<GameObject> ObstacleList;


	public void Awake(){
		PoolPickables ();
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
		currIndex = 0;
		for (int i = 0; i < numCoins; i++) {
			if (CoinPrefabs.Length <= 0)
				break;
			if (currIndex >= CoinPrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (CoinPrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("PickablesParent").transform);
			obj.gameObject.SetActive (false);
			CoinList.Add (obj);
			currIndex++;
		}
	}

	/*
	 * Zone Pooling list
	 */
	public void PoolObjects(){
		GroundList = new List<GameObject> ();
		ObstacleList = new List<GameObject> ();
		int currIndex = 0;
		//Straight grounds
		for (int i = 0; i < numGrounds; i++) {
			if (GroundPrefabs.Length <= 0)
				break;
			if (currIndex >= GroundPrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (GroundPrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("GroundsParent").transform);
			obj.gameObject.SetActive (false);
			GroundList.Add (obj);
			currIndex++;
		}
		currIndex = 0;
		//Obstacles
		for (int i = 0; i < numObstacles; i++) {
			if (ObstaclePrefabs.Length <= 0)
				break;
			if (currIndex >= ObstaclePrefabs.Length)
				currIndex = 0;
			GameObject obj = Instantiate (ObstaclePrefabs [currIndex]) as GameObject;
			obj.transform.SetParent(GameObject.FindGameObjectWithTag("ObstaclesParent").transform);
			obj.gameObject.SetActive (false);
			ObstacleList.Add (obj);
			currIndex++;
		}
		currIndex = 0;
	}


	//Get Straight ground
	public GameObject GetGround(){
		int index = Random.Range (0, GroundList.Count - 1);
		while (GroundList [index].gameObject.activeInHierarchy) {
			index = Random.Range (0, GroundList.Count - 1);
		}
		return GroundList [index];
	}

	//Get Obstacle
	public GameObject GetObstacle(){
		int index = Random.Range (0, ObstacleList.Count - 1);
		while (ObstacleList [index].gameObject.activeInHierarchy) {
			index = Random.Range (0, ObstacleList.Count - 1);
		}
		return ObstacleList [index];
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
