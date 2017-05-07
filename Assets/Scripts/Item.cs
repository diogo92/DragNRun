using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public static PlayerManager PM;
	public static float MagnetTimer = 10f;
	public static float LightningboltTimer = 5f;
	public enum ItemType{
		Powerup_Shield,
		Powerup_Lightning,
		Powerup_Magnet,
		Health,
		Coin,
		Empty
	}

	public ItemType type;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			switch (type) {
			case ItemType.Coin:
				PM.NumCoins++;
				break;
			case ItemType.Health:
				PM.IncreaseHP ();
				break;
			case ItemType.Powerup_Lightning:
				PM.SetPowerup (type);
				break;
			case ItemType.Powerup_Magnet:
				PM.SetPowerup (type);
				break;
			case ItemType.Powerup_Shield:
				PM.SetPowerup (type);
				break;
			default:
				break;
			}
			gameObject.SetActive (false);
		}
	}
}
