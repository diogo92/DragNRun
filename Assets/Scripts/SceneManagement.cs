using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Based on N3K EN's tutorials
 */
public class SceneManagement : MonoBehaviour {

	public static SceneManagement Instance{ set; get; }

	public Image fadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;

	private void Awake(){
		Instance = this;
		Load ("WaterFrontCliff");
	}

	public void Fade(bool showing, float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
	}

	private void Update(){

		if(!isInTransition)
			return;
		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		fadeImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white,transition);

		if (transition > 1 || transition < 0) {
			isInTransition = false;
		}
	}

	public void Load (string sceneName){
		if (!SceneManager.GetSceneByName (sceneName).isLoaded) {
			SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
		}
	}

	public void Unload (string sceneName){
		if (SceneManager.GetSceneByName (sceneName).isLoaded) {
			SceneManager.UnloadSceneAsync(sceneName);
		}
	}
}
