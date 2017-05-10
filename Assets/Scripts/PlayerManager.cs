using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
	public static GameObject CurrentActivePlayer;
	SkinnedMeshRenderer[] ModelMeshes;

	/*
	 * 	Player hit points
	 */
	//Current HP
	public int HP = 3;
	//Can take damage
	bool IsInvincible = false;
	bool IsBlinking = false;
	//Invincibility timer
	public float InvincibleTimeLeft = 0f;


	/*
	 * 	Powerups
	 */
	GameObject MagnetEffect;
	public bool IsMagnetActive = false;
	public float MagnetTimeLeft = 0f;
	public int NumShields = 0;
	public int NumBolts = 0;
	public GameObject[] shieldEffects;
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
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "Player") {
				if (child.gameObject.activeInHierarchy) {
					CurrentActivePlayer = child.gameObject;
					break;
				}
			}
		}
		MagnetEffect = CurrentActivePlayer.GetComponentInChildren<MagnetEffect> ().gameObject;
		MagnetEffect.SetActive(false);
	}
	// Use this for initialization
	void Start () {
		ModelMeshes = CurrentActivePlayer.GetComponentsInChildren<SkinnedMeshRenderer> ();
		/** Get the child of the player with the shield effect transform **/
		shieldEffects = new GameObject[2];
		GameObject ShieldEffectParent = null;
		foreach (Transform child in CurrentActivePlayer.transform) {
			if (child.gameObject.tag == "ShieldParent") {
				ShieldEffectParent = child.gameObject;
				break;
			}
		}
		if (ShieldEffectParent) {
			int currInd = 0;
			foreach (Transform child in ShieldEffectParent.transform) {
				shieldEffects [currInd] = child.gameObject;
				currInd++;
				if (currInd > 1)
					break;
			}
		}
		DistanceRun = 0f;
		HUD = FindObjectOfType<PlayerHUDManager> ();
		//Set the first active child as active player

		lastZPosition = CurrentActivePlayer.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsInvincible) {
			if (!IsBlinking)
				StartCoroutine (Blink());
			if (InvincibleTimeLeft > 0)
				InvincibleTimeLeft -= Time.deltaTime;
			else
				IsInvincible = false;
		}
		if (MagnetTimeLeft > 0) {
			MagnetTimeLeft -= Time.deltaTime;
		} else {
			IsMagnetActive = false;
			MagnetTimeLeft = 0;
			MagnetEffect.SetActive(false);
		}
		//Calculate distance run

		DistanceRun += Mathf.Abs(CurrentActivePlayer.transform.position.z - lastZPosition);
		lastZPosition = CurrentActivePlayer.transform.position.z;

		//Check if below level limit
		if(CurrentActivePlayer.transform.position.y < -20f || HP <=0)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// Function called by child collider when hitting an obstacle
	public void HitByObstacle(){
		if (IsInvincible)
			return;
		else if (NumShields>0) {
			IsInvincible = true;
			NumShields--;
			if (shieldEffects [0].activeInHierarchy) {
				if (shieldEffects [1].activeInHierarchy)
					shieldEffects [1].SetActive (false);
				else
					shieldEffects [0].SetActive (false);
			}
			InvincibleTimeLeft = 2f;
		}
		else {
			if (CurrentActivePlayer.GetComponentInChildren<Rigidbody> ()) {
				CurrentActivePlayer.GetComponentInChildren<Rigidbody> ().velocity = Vector3.zero;
				CurrentActivePlayer.GetComponentInChildren<Rigidbody> ().AddForce (0, 2f, 30f, ForceMode.VelocityChange);
			}
			DecreaseHP ();
			IsInvincible = true;
			InvincibleTimeLeft = 3f;
		}
	}
	// Sets new powerup or object effect, if collecting or timer/effect running out
	public void AddPowerUp(Item.ItemType iType){
		switch (iType) {
		case Item.ItemType.Powerup_Shield:
			if (NumShields < 2) {
				if (shieldEffects [0].activeInHierarchy) {
					if (!shieldEffects [1].activeInHierarchy)
						shieldEffects [1].SetActive (true);
				}
				else
					shieldEffects [0].SetActive (true);
				NumShields++;
			}
			break;
		case Item.ItemType.Powerup_Magnet:
			MagnetTimeLeft = Item.MagnetTimer;
			MagnetEffect.SetActive(true);
			IsMagnetActive = true;
			break;
		case Item.ItemType.Powerup_Lightning:
			if(NumBolts<3)
			NumBolts++;
			break;
		case Item.ItemType.Coin:
			NumCoins++;
			break;
		case Item.ItemType.Health:
			IncreaseHP ();
			break;
		case Item.ItemType.Empty:
			break;
		default:
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


	IEnumerator Blink(){
		IsBlinking = true;
		for (int i = 0; i < ModelMeshes.Length; i++) {
			ModelMeshes [i].enabled = false;
		}
		yield return new WaitForSeconds (0.3f);
		for (int i = 0; i < ModelMeshes.Length; i++) {
			ModelMeshes [i].enabled = true;
		}
		yield return new WaitForSeconds (0.3f);
		IsBlinking = false;

	}

}
