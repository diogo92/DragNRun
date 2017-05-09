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

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			//Destroy the obstacle
			GetComponentInChildren<SplitMeshIntoTriangles>().SplitMesh();
			if (collision.gameObject.GetComponent<Rigidbody> ())
				collision.gameObject.GetComponent<Rigidbody> ().AddForce (0, 0f, 1000f, ForceMode.Impulse);
			GameObject.FindObjectOfType<PlayerManager>().HitByObstacle();
		}
	}
}
