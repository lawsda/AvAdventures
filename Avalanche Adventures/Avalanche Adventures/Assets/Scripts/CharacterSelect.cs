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
	
	//Public variables
	public GUIStyle titleStyle;
	public GUIStyle title2Style;
	public GUIStyle btnStyle;
	public GUIStyle HSStyle;
	public GUIStyle charBoxStyle;

	//Character Styles
	public GUIStyle EdmundStyle;
	public GUIStyle CinderStyle;

	public GUIStyle SelectStyle;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;
		
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		charSelected = PlayerPrefs.GetInt (charSelectKey, 0);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt(charSelectKey, charSelected);
		PlayerPrefs.Save();
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

			
			
			if (GUI.Button (new Rect (sWidth / 5, sHeight /4, sWidth / 5, sHeight *2/5 ), "Edmund", charBoxStyle)) {
					charSelected = 0;
				}
			GUI.Label (new Rect (sWidth / 5 + sWidth / 18, sHeight /4 + sHeight / 10, 60, 60), "", EdmundStyle);

			if (GUI.Button (new Rect (sWidth *3/ 5, sHeight /4, sWidth / 5, sHeight *2/5 ), "Cinder", charBoxStyle)) {
				charSelected = 1;
			}
			GUI.Label (new Rect (sWidth*3 / 5 + sWidth / 18, sHeight /4 + sHeight / 10, 60, 60), "", CinderStyle);

			GUI.Label (new Rect (sWidth / 4, sHeight - sHeight / 10, sWidth / 2, sHeight / 16), "Selected Character", SelectStyle);
		
			btnStyle.fontSize = (int)sHeight/30;
			if (GUI.Button (new Rect (sWidth  - sWidth / 8, 0, sWidth / 8, sHeight / 15), "Return", btnStyle)) {
				//Load last scene
			Application.LoadLevel(1);
			}
		}
}
