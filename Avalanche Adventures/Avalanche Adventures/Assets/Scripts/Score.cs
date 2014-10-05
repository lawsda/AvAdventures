using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//Priavte variables
	private float sHeight;
	private float sWidth;
	private int deathTimer = 180;

	private int highScore = 0;
	private string highScoreKey = "HighScore";

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
	}
	
	// Update is called once per frame
	void Update () {
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
	}
	
	void OnGUI () {
		//High Score
		string HSLabel = "High Score: "+ highScore;
		HSStyle.fontSize = (int)sHeight/30;
		GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

		//UI
		GUI.Box (new Rect (sWidth / 4, 0, sWidth / 2, sHeight / 15), "");
		string scoreLabel = "Score: " + score;
		scoreStyle.fontSize = (int) sHeight / 16;
		GUI.Label (new Rect (sWidth / 4, 0, sWidth / 2, sHeight / 15), scoreLabel, scoreStyle); 


		if (isDead) {
			GOStyle.fontSize = (int)sHeight/10;
			GUI.Label (new Rect (0, sHeight / 2, sWidth, sHeight), "Game Over", GOStyle);

		}
	}

}
