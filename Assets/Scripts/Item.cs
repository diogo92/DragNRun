using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
