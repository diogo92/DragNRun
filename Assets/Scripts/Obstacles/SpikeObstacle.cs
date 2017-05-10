using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstacle : MonoBehaviour {
	List<string> animations = new List<string>();
	Animation anim;
	// Use this for initialization
	void Start () {
		foreach(AnimationState state in GetComponent<Animation>())
		{
			state.speed = 0.25f;
			animations.Add(state.name);
		}
	}

	void OnEnable(){
		transform.localScale *= 0.9f;

	}


}
