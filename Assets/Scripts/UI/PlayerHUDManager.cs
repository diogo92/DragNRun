using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * 	Player HUD manager script
 */ 
public class PlayerHUDManager : MonoBehaviour {


	//Reference to the player manager of the level
	PlayerManager PM;

	//Array for the powerup sprites
	//0 - Shield, 1 - Magnet, 2 - Lightning bolt, 3 - null
	public Sprite[] powerupSprites;



	//The UI Text element that represents the current run distance
	public Text DistanceRunText;

	//The UI Text element that represents the current number of coins
	public Text NumCoinsText;

	//The UI Text element that represents the current time left of the powerup effect
	public Text MagnetTimeLeft;

	//The UI Text element that represents the current number of shields
	public Text NumShields;

	//The UI Text element that represents the current number of bolts
	public Text NumBolts;

	//The UI Image element that represents the current player hit points
	public Image HPImage;


	// Use this for initialization
	void Start () {
		PM = FindObjectOfType<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		DistanceRunText.text = Mathf.RoundToInt(PM.DistanceRun).ToString() + " m";
		NumCoinsText.text = "x"+PM.NumCoins.ToString();
		NumBolts.text = "x"+PM.NumBolts.ToString();
		NumShields.text = "x"+PM.NumShields.ToString();
		MagnetTimeLeft.text = Mathf.RoundToInt (PM.MagnetTimeLeft).ToString () + "s";
	}


	public void IncreaseHP(){
		HPImage.fillAmount += (1f / 3f);
	}
	public void DecreaseHP(){
		HPImage.fillAmount -= (1f / 3f);
	}
}
