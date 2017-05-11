using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour {



	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine ("ChangeScene");
		}
	}

	IEnumerator ChangeScene(){
		SceneManagement.Instance.Fade (true, 1f);
		yield return new WaitForSeconds (1f);
		SceneManagement.Instance.Unload ("WaterFrontCliff");
		SceneManagement.Instance.Load ("TestTransition");
		SceneManagement.Instance.Fade (false, 1f);
	}
}
