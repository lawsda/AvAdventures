using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//Priavte variables
	private float sHeight;
	private float sWidth;
	private int deathTimer = 180;
	private int powerCD;

	//PlayerPrefs Storage
	private int highScore = 0;
	private string highScoreKey = "HighScore";
	private int currency = 0;
	private string currencyKey = "Crystals";
	private int currentPlayerExp = 0;
	private string playerExpKey = "PlayerExp";
	private int charSelected = 0;
	private string charSelectKey = "CharacterSelected";

	//Public variables
	public bool isDead = false;
	public int score = 0;
	public GUIStyle scoreStyle;
	public GUIStyle GOStyle;
	public GUIStyle btnStyle;
	public GUIStyle HSStyle;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;

		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		currency = PlayerPrefs.GetInt (currencyKey, 0);
		charSelected = PlayerPrefs.GetInt (charSelectKey, 0);
		playerExpKey += charSelected;
		currentPlayerExp = PlayerPrefs.GetInt (playerExpKey, 0);
	}
	
	// Update is called once per frame
	void Update () {
		currency = PlayerPrefs.GetInt (currencyKey, 0);
		if(GameObject.FindGameObjectWithTag ("Player") != null)
		powerCD = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterMovement> ().powerCD;

		if (!isDead) {
			score++;
		}

		if (isDead) {
			deathTimer--;
		}

		if (deathTimer <= 0) {
			Application.LoadLevel(1);
		}
	}

	void OnDisable(){
		
		//If our scoree is greter than highscore, set new higscore and save.
		if(score>highScore){
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}

		//Update Exp total
		currentPlayerExp += (int) (score / 60);
		PlayerPrefs.SetInt (playerExpKey, currentPlayerExp);
		PlayerPrefs.Save ();
	}
	
	void OnGUI () {
		//High Score
		string HSLabel = "High Score: "+ highScore;
		HSStyle.fontSize = (int)sHeight/30;
		GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

		//UI
		int UIpowerCD = (powerCD > 0) ? ((powerCD / 60)+1) : 0;
	//	GUI.Box (new Rect (sWidth / 6, 0, sWidth *2/ 3, sHeight / 15), "");
		string scoreLabel = "Crystals: " + currency + "  Score: " + score + "  Power - "+UIpowerCD+"s";
		scoreStyle.fontSize = (int) sHeight / 20;
		GUI.Label (new Rect (sWidth / 6, 0, sWidth *2/ 3, sHeight / 14), scoreLabel, scoreStyle); 


		if (isDead) {
			GOStyle.fontSize = (int)sHeight/10;
			GUI.Label (new Rect (0, sHeight / 2, sWidth, sHeight), "Game Over", GOStyle);

		}
	}

}
