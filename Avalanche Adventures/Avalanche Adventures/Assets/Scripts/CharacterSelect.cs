using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	//Private variables
	private float sHeight;
	private float sWidth;
	
	private int highScore = 0;
	private string highScoreKey = "HighScore";
	
	//Public variables
	public GUIStyle titleStyle;
	public GUIStyle title2Style;
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
	
	}

	void OnGUI () {
				//High Score
				string HSLabel = "High Score: " + highScore;
				HSStyle.fontSize = (int)sHeight / 30;
				GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

				//Main title
				titleStyle.fontSize = (int)sHeight/12;
				title2Style.fontSize = (int)sHeight/12;
				GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Character Select", titleStyle);
				GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Character Select", title2Style);


			btnStyle.fontSize = (int)sHeight/30;
			if (GUI.Button (new Rect (sWidth / 2 - sWidth / 10, sHeight - sHeight/15, sWidth / 5, sHeight / 20), "Return", btnStyle)) {
				//Load last scene
			}
		}
}
