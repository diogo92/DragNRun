using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 	Player Manager Script
 */
public class PlayerManager : MonoBehaviour {


	/*
	 *	HUD manager reference 
	 */
	PlayerHUDManager HUD;

	/*
	 *	Active player controller
	 */ 
	GameObject CurrentActivePlayer;


	/*
	 * 	Player hit points
	 */
	//Current HP
	public int HP = 3;
	//Can take damage
	bool IsInvincible = false;
	//Invincibility timer
	public float InvincibleTimeLeft = 0f;


	/*
	 * 	Currently held Powerup
	 */
	public float PowerupTimeLeft = 0f;
	public Item.ItemType CurrentHeldPowerup;

	/*
	 * 	Distance score calculation variables
	 */
	//Total distance run
	public float DistanceRun = 0f;
	//Last calculated Z player position
	float lastZPosition = 0f;
	/*
	 * 	Collected coins
	 */
	public int NumCoins = 0;

	void Awake(){
		Item.PM = this;
	}
	// Use this for initialization
	void Start () {
		DistanceRun = 0f;
		HUD = FindObjectOfType<PlayerHUDManager> ();
		//Set the first active child as active player
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "Player") {
				if (child.gameObject.activeInHierarchy) {
					CurrentActivePlayer = child.gameObject;
					break;
				}
			}
		}
		lastZPosition = CurrentActivePlayer.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsInvincible) {
			if (InvincibleTimeLeft > 0)
				InvincibleTimeLeft -= Time.deltaTime;
			else
				IsInvincible = false;
		}
		if (PowerupTimeLeft > 0) {
			PowerupTimeLeft -= Time.deltaTime;
		} else {
			if (CurrentHeldPowerup == Item.ItemType.Powerup_Magnet) {
				CurrentHeldPowerup = Item.ItemType.Empty;
			}
		}
		//Calculate distance run
		DistanceRun += Mathf.Abs(CurrentActivePlayer.transform.position.z - lastZPosition);
		lastZPosition = CurrentActivePlayer.transform.position.z;
	}

	// Function called by child collider when hitting an obstacle
	public void HitByObstacle(){
		if (IsInvincible)
			return;
		else if (CurrentHeldPowerup == Item.ItemType.Powerup_Shield) {
			SetPowerup (Item.ItemType.Empty);
			IsInvincible = true;
			InvincibleTimeLeft = 2f;
		}
		else {
			DecreaseHP ();
			IsInvincible = true;
			InvincibleTimeLeft = 10f;
		}
	}
	// Sets new powerup or object effect, if collecting or timer/effect running out
	public void SetPowerup(Item.ItemType iType){
		switch (iType) {
		case Item.ItemType.Powerup_Shield:
			CurrentHeldPowerup = iType;
			HUD.SetSprite (iType);
			break;
		case Item.ItemType.Powerup_Magnet:
			PowerupTimeLeft = Item.MagnetTimer;
			CurrentHeldPowerup = iType;
			HUD.SetSprite (iType);
			break;
		case Item.ItemType.Powerup_Lightning:
			PowerupTimeLeft = Item.LightningboltTimer;
			CurrentHeldPowerup = iType;
			HUD.SetSprite (iType);
			break;
		case Item.ItemType.Coin:
			NumCoins++;
			break;
		case Item.ItemType.Health:
			IncreaseHP ();
			break;
		case Item.ItemType.Empty:
			CurrentHeldPowerup = iType;
			HUD.SetSprite (iType);
			break;
		default:
			CurrentHeldPowerup = iType;
			HUD.SetSprite (iType);
			break;
		}
	}

	/*
	 *	HP functions 
	 */
	public void DecreaseHP(){
		if (HP > 0) {
			HP--;
			HUD.DecreaseHP ();
		}
	}
	public void IncreaseHP(){
		if (HP < 3) {
			HP++;
			HUD.IncreaseHP ();
		}
	}


}
