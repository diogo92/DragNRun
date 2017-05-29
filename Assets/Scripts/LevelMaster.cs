using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour {
	//Platform dragging speed
	public float PlatformDragSpeed = 1f;
	public GameObject CurrentPlatform = null;

	public Transform Limits;
	public Material SceneSkybox;
	// Use this for initialization
	void Start () {
		SmoothCamera.Instance.LimitsTransform = Limits;
		RenderSettings.skybox = SceneSkybox;
	}

}
