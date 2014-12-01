using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	//Private variables
	private float sHeight;
	private float sWidth;
	
	private int highScore = 0;
	private string highScoreKey = "HighScore";
	private int charSelected = 0;
	private string charSelectKey = "CharacterSelected";
	private int playerExp;
	private string playerExpKey = "PlayerExp";
	private int level = 1;
	private string levelKey = "CharLevel";
	private int upgradeLevel = 1;
	private string upgradeLevelKey = "UpgradeLevel";
	private int currency = 0;
	private string currencyKey = "Crystals";

	private string edmundAbility;
	private string cinderAbility;
	private string robAbility;
	private string edmundUpgrade;
	private string cinderUpgrade;
	private string robUpgrade;

	//Public variables
	public GUIStyle titleStyle;
	public GUIStyle title2Style;
	public GUIStyle btnStyle;
	public GUIStyle HSStyle;
	public GUIStyle charBoxStyle;

	//Character Styles
	public GUIStyle EdmundStyle;
	public GUIStyle CinderStyle;
	public GUIStyle RobStyle;
	public GUIStyle StatStyle;

	public GUIStyle SelectStyle;
	public GUIStyle UpgradeStyle;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;
		
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		charSelected = PlayerPrefs.GetInt (charSelectKey, 0);
		currency = PlayerPrefs.GetInt (currencyKey, 0);

		edmundAbility 	= "Pick-toss:\nToss an icepick into the air,\nshattering icicles in its path.\nUpgrade to increase pick number";
		cinderAbility 	= "Flame Shield:\nSurrond yourself with a shield \nof fire to melt incoming icicles.\nUpgrade to increase duration";
		robAbility 		= "Air Mines:\nShoot a mine into the air which\nexplods after a few seconds.\nUpgrade to increase mine number";

		charBoxStyle.fontSize = (int) sHeight / 22;
		StatStyle.fontSize = (int) sHeight / 22;
		SelectStyle.fontSize = (int) sHeight / 28;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt(charSelectKey, charSelected);
		PlayerPrefs.Save();
	}
	
	void OnGUI () {
		//Default GUI setings
				//High Score
				string HSLabel = "High Score: " + highScore;
				HSStyle.fontSize = (int)sHeight / 30;
				GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

				//Main title
				titleStyle.fontSize = (int)sHeight/12;
				title2Style.fontSize = (int)sHeight/12;
				GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Character Select", titleStyle);
				GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Character Select", title2Style);

			
			

			if (GUI.Button (new Rect (sWidth / 5, sHeight /4, sWidth / 5, sHeight *2/5 ), "Edmund", charBoxStyle)) {
					charSelected = 0;
				}
			//Edmund display labels
			GUI.Label (new Rect (sWidth / 5 + sWidth / 18, sHeight /4 + sHeight / 10, sHeight/7, sHeight/7), "", EdmundStyle);
				playerExp = PlayerPrefs.GetInt (playerExpKey +"0", 0);
				level = PlayerPrefs.GetInt (levelKey+"0", 1);
		GUI.Label (new Rect (sWidth / 5 + sWidth / 18, sHeight / 4 + sHeight / 10 + sHeight/6, sHeight/7, sHeight/7), "Level: "+level + "\nExp: "+ playerExp, StatStyle);

			if (GUI.Button (new Rect (sWidth *2/ 5, sHeight /4, sWidth / 5, sHeight *2/5 ), "Cinder", charBoxStyle)) {
				charSelected = 1;
			}
			//Cinder display labels
		GUI.Label (new Rect (sWidth*2 / 5 + sWidth / 18, sHeight /4 + sHeight / 10, sHeight/7, sHeight/7), "", CinderStyle);
				playerExp = PlayerPrefs.GetInt (playerExpKey +"1", 0);
				level = PlayerPrefs.GetInt (levelKey+"1", 1);
		GUI.Label (new Rect (sWidth*2 / 5 + sWidth / 18, sHeight / 4 + sHeight / 10 + sHeight/6, sHeight/7, sHeight/7), "Level: "+level + "\nExp: "+ playerExp, StatStyle);

			if (GUI.Button (new Rect (sWidth *3/ 5, sHeight /4, sWidth / 5, sHeight *2/5 ), "Rob", charBoxStyle)) {
				charSelected = 2;
			}
			//Rob display labels
		GUI.Label (new Rect (sWidth*3 / 5 + sWidth / 18, sHeight /4 + sHeight / 10, sHeight/7, sHeight/7), "", RobStyle);
			playerExp = PlayerPrefs.GetInt (playerExpKey +"2", 0);
			level = PlayerPrefs.GetInt (levelKey+"2", 1);
		GUI.Label (new Rect (sWidth*3 / 5 + sWidth / 18, sHeight / 4 + sHeight / 10 + sHeight/6, sHeight/7, sHeight/7), "Level: "+level + "\nExp: "+ playerExp, StatStyle);
		
		
		//Currently select Character info
			//Set ability text label
			string abilityText = "";
			if (charSelected == 0)
						abilityText = edmundAbility;
				else if (charSelected == 1)
						abilityText = cinderAbility;
				else if (charSelected == 2)
						abilityText = robAbility;
			GUI.Label (new Rect (sWidth / 3, sHeight - sHeight / 5, sWidth / 3, sHeight / 5), abilityText, SelectStyle);

		//Currency
		GUI.Label (new Rect (sWidth/12, sHeight - sHeight / 5, sWidth / 18, sHeight / 10), "x"+currency, SelectStyle);

			
		if (GUI.Button (new Rect (sWidth - sWidth / 8, sHeight*4 / 5, sWidth / 8, sHeight / 15), "Upgrade", btnStyle)) {
				if((upgradeLevel*25) < currency){
						currency -= (upgradeLevel*25);
						upgradeLevel++;
						PlayerPrefs.SetInt (upgradeLevelKey + charSelected, upgradeLevel);
						PlayerPrefs.SetInt (currencyKey, currency);
						PlayerPrefs.Save ();
					}
			}
			upgradeLevel = PlayerPrefs.GetInt (upgradeLevelKey + charSelected, 1);
			GUI.Label (new Rect (sWidth - sWidth / 5, sHeight * 6 / 7, sWidth / 5, sHeight / 8), "Cost: "+(upgradeLevel*25)+"\nLevel: " + upgradeLevel, SelectStyle);
		           
			btnStyle.fontSize = (int)sHeight/30;
			if (GUI.Button (new Rect (sWidth  - sWidth / 8, 0, sWidth / 8, sHeight / 15), "Return", btnStyle)) {
				//Load last scene
			Application.LoadLevel(1);
			}
		}
}
