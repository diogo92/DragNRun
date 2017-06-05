using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Pickup item class
 */

public class Item : MonoBehaviour {

	//Effect variables for magnet items
	public static float MagnetTimer = 10f;
	public static float MagnetRadius = 5f;

	//Item type enumerator 
	public enum ItemType{
		Powerup_Shield,
		Powerup_Lightning,
		Powerup_Magnet,
		Health,
		Coin,
		Empty
	}

	public ItemType type;

	//Check collision with player
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			switch (type) {
			case ItemType.Coin:
				PlayerManager.Instance.NumCoins++;
				break;
			case ItemType.Health:
				PlayerManager.Instance.IncreaseHP ();
				break;
			case ItemType.Powerup_Lightning:
				PlayerManager.Instance.AddPowerUp (type);
				break;
			case ItemType.Powerup_Magnet:
				PlayerManager.Instance.AddPowerUp (type);
				break;
			case ItemType.Powerup_Shield:
				PlayerManager.Instance.AddPowerUp (type);
				break;
			default:
				break;
			}
			gameObject.SetActive (false);
		}
	}
}
