using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * 	Player HUD manager script
 */ 
public class PlayerHUDManager : MonoBehaviour {

	public static PlayerHUDManager Instance { get; set; }

	//Array containing the panel background images references in the scene
	//0 - Waterfront Cliff; 1 - Sector 9 Slums
	public GameObject[] LevelPanelImages;

	//Name of the level shown in the UI
	public Text LevelName;

	//The UI Text element that represents the current run distance
	public Text DistanceRunText;
	public Text DistanceStaticText;

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
	public Text HPText;

	void Awake(){
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		//Update UI texts
		DistanceRunText.text = Mathf.RoundToInt(PlayerManager.Instance.DistanceRun).ToString() + " m";
		NumCoinsText.text = "x"+PlayerManager.Instance.NumCoins.ToString();
		NumBolts.text = "x"+PlayerManager.Instance.NumBolts.ToString();
		NumShields.text = "x"+PlayerManager.Instance.NumShields.ToString();
		MagnetTimeLeft.text = Mathf.RoundToInt (PlayerManager.Instance.MagnetTimeLeft).ToString () + "s";
	}

	//Update the HUD HP image fill amount
	public void IncreaseHP(){
		HPImage.fillAmount += (1f / 3f);
	}
	public void DecreaseHP(){
		HPImage.fillAmount -= (1f / 3f);
	}

	//When changing level, update the HUD images and text color
	public void ChangeLevel(SceneManagement.LevelName level){
		for (int i = 0; i < LevelPanelImages.Length; i++) {
			LevelPanelImages [i].SetActive (false);
		}
		switch (level) {
		case SceneManagement.LevelName.WaterfrontCliff:
			LevelName.color = Color.gray;
			DistanceRunText.color = Color.gray;
			NumCoinsText.color = Color.gray;
			MagnetTimeLeft.color = Color.gray;
			NumShields.color = Color.gray;
			NumBolts.color = Color.gray;
			HPText.color = Color.gray;
			DistanceStaticText.color = Color.gray;
			LevelName.text = "Waterfront Cliff";
			LevelPanelImages [0].SetActive (true);
			break;
		case SceneManagement.LevelName.Sector9Slums:
			LevelName.color = Color.white;
			DistanceRunText.color = Color.white;
			NumCoinsText.color = Color.white;
			MagnetTimeLeft.color = Color.white;
			NumShields.color = Color.white;
			NumBolts.color = Color.white;
			HPText.color = Color.white;
			DistanceStaticText.color = Color.white;
			LevelName.text = "Sector 9 Slums";
			LevelPanelImages [1].SetActive (true);
			break;
		case SceneManagement.LevelName.StardustRuins:
			LevelName.color = Color.white;
			DistanceRunText.color = Color.white;
			NumCoinsText.color = Color.white;
			MagnetTimeLeft.color = Color.white;
			NumShields.color = Color.white;
			NumBolts.color = Color.white;
			HPText.color = Color.white;
			DistanceStaticText.color = Color.white;
			LevelName.text = "Stardust Ruins";
			LevelPanelImages [2].SetActive (true);
			break;
		}
	}
}
