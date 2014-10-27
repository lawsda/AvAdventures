using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//Private variables
	private float sHeight;
	private float sWidth;
	private bool showCredits = false;
	private bool moveLeft = false;
	private float speed = .6f;

	private int highScore = 0;
	private string highScoreKey = "HighScore";

	//Public variables
	public GUIStyle titleStyle;
	public GUIStyle title2Style;
	public GUIStyle creditsStyle;
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

		//Pan camera across background
		if (moveLeft) {
			transform.Translate(-speed * Time.deltaTime, 0, 0);
				} else {
			transform.Translate(speed * Time.deltaTime, 0, 0);
				}

		//Stop background at edge of image
		if (transform.position.x >= 2.5)
						moveLeft = true;
				else if (transform.position.x <= -2)
						moveLeft = false;

	}

	void OnGUI() {
		//High Score
		string HSLabel = "High Score: "+ highScore;
		HSStyle.fontSize = (int)sHeight/30;
		GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

		//Main Menu
		if (showCredits == false) {
						GUI.BeginGroup (new Rect (0, 0, sWidth, sHeight));
						GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Avalanche Adventures", titleStyle);
						GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Avalanche Adventures", title2Style);
						titleStyle.fontSize = (int)sHeight/12;
						title2Style.fontSize = (int)sHeight/12;
						if (GUI.Button (new Rect (sWidth / 2 - sWidth / 10, sHeight / 2 - sHeight / 5, sWidth / 5, sHeight / 10), "Arcade", btnStyle)) {
							Application.LoadLevel(1);
						}

						if (GUI.Button (new Rect (sWidth / 2 - sWidth / 10, sHeight / 2, sWidth / 5, sHeight / 10), "Credits", btnStyle)) {
								showCredits = true;
						}
						btnStyle.fontSize = (int)sHeight/25;
						GUI.EndGroup ();
				} 
		//Credits
		else if (showCredits == true) {

						GUI.BeginGroup (new Rect (0, 0, sWidth, sHeight));
						GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Credits", titleStyle);
						GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Credits", title2Style);
					
						
						string creditsText = "\nProduction: David Laws\nArtwork: Jack Einhorn\nMusic: Nick White" +
							"\n______________________\nMGMS - Full Sail University\nCapstone";
						GUI.Label (new Rect(0, sHeight/4 + sHeight/15, sWidth, sHeight), creditsText, creditsStyle);
						creditsStyle.fontSize = (int)sHeight/20;

						
						if (GUI.Button (new Rect (sWidth - sWidth / 8, 0 , sWidth / 8, sHeight / 15), "Return", btnStyle)) {
							showCredits = false;
						}
						btnStyle.fontSize = (int)sHeight/30;
						GUI.EndGroup ();
				}

	}

}
