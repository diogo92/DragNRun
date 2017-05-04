using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * 	Player HUD manager script
 */ 
public class PlayerHUDManager : MonoBehaviour {

	PlayerManager PM;

	public Text DistanceRunText;

	// Use this for initialization
	void Start () {
		PM = FindObjectOfType<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		DistanceRunText.text = Mathf.RoundToInt(PM.DistanceRun).ToString() + " m";
	}
}
