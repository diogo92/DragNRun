using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour {

	public SceneManagement.LevelName LevelToLoad;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine ("ChangeScene");
		}
	}

	IEnumerator ChangeScene(){
		SceneManagement.Instance.Fade (true, 1f);
		yield return new WaitForSeconds (1f);
		SceneManagement.Instance.Unload (SceneManagement.Instance.CurrentLevel.ToString());
		SceneManagement.Instance.CurrentLevel = LevelToLoad;
		SceneManagement.Instance.Load (LevelToLoad);
		PlayerManager.CurrentActivePlayer.transform.position = Vector3.zero;
		SceneManagement.Instance.Fade (false, 1f);
	}
}
