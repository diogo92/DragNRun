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
	public Text PowerupTimeLeft;

	//The UI Image element that represents the current player hit points
	public Image HPImage;

	//The UI Image element that represents the current active powerup
	public Image PowerupImage;


	// Use this for initialization
	void Start () {
		PM = FindObjectOfType<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		DistanceRunText.text = Mathf.RoundToInt(PM.DistanceRun).ToString() + " m";
		NumCoinsText.text = "x"+PM.NumCoins.ToString();
		if (PM.CurrentHeldPowerup != Item.ItemType.Empty) {
			PowerupTimeLeft.text = Mathf.RoundToInt (PM.PowerupTimeLeft).ToString () + "s";
		} else
			PowerupTimeLeft.text = "";
	}

	public void SetSprite(Item.ItemType type){
		Color n = PowerupImage.color;
		n.a =255f;
		PowerupImage.color=n;
		switch (type) {
		case Item.ItemType.Powerup_Shield:
			PowerupImage.sprite = powerupSprites [0];
			break;
		case Item.ItemType.Powerup_Magnet:
			PowerupImage.sprite = powerupSprites [1];
			break;
		case Item.ItemType.Powerup_Lightning:
			PowerupImage.sprite = powerupSprites [2];
			break;
		default:
			n = PowerupImage.color;
			n.a = 0f;
			PowerupImage.color=n;
			break;
		}
	}

	public void IncreaseHP(){
		HPImage.fillAmount += (1 / 3);
	}
	public void DecreaseHP(){
		HPImage.fillAmount -= (1 / 3);
	}
}
