using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	//Private variables
	private float sHeight;
	private float sWidth;
	private bool moveLeft = false;
	private float speed = .6f;

	private int highScore = 0;
	private string highScoreKey = "HighScore";

	private int tutorialStep;

	//Public variables
	public GUIStyle titleStyle;
	public GUIStyle title2Style;
	public GUIStyle btnStyle;
	public GUIStyle HSStyle;
	public GUIStyle tutorialStyle;

	public Texture Moving1;
	public Texture Moving2;
	public Texture Ability1;
	public Texture Ability2;
	public Texture Ability3;


	//Tutorial Text
	private string tutorialText1 = "To move your character...";
	private string tutorialText2 = "To move your character...press the arrow keys";
	private string tutorialText3 = "Check the cooldown timer to know when \nyou will get your special power";
	private string tutorialText4 = "When the timer reaches 0, tap anywhere...";
	private string tutorialText5 = "When the timer reaches 0, tap anywhere...\n...to activate your power and destroy the icicles";


	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;
		
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);

		tutorialStep = 1;

		tutorialStyle.fontSize = (int) sHeight / 20;
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
				string HSLabel = "High Score: " + highScore;
				HSStyle.fontSize = (int)sHeight / 30;
				GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

				GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Tutorial", titleStyle);
				GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Tutorial", title2Style);
				titleStyle.fontSize = (int)sHeight/12;
				title2Style.fontSize = (int)sHeight/12;


		if (tutorialStep < 3) {
						GUI.Label (new Rect (sWidth * 1 / 6, sHeight * 1 / 3, sWidth / 3, sHeight / 3), new GUIContent (Moving1));
						GUI.Label (new Rect (sWidth * 1 / 6, sHeight * 5 / 7, sWidth * 4 / 6, sHeight / 6), tutorialText1, tutorialStyle);
				}
			
		if (tutorialStep == 2) {
						GUI.Label (new Rect (sWidth * 3 / 5, sHeight * 1 / 3, sWidth / 3, sHeight / 3), new GUIContent (Moving2));
						GUI.Label (new Rect (sWidth * 1 / 6, sHeight * 5 / 7, sWidth * 4 / 6, sHeight / 6), tutorialText2, tutorialStyle);
				}

		if (tutorialStep == 3) {
			GUI.Label (new Rect (sWidth * 1 / 3, sHeight * 1 / 3, sWidth / 3, sHeight / 3), new GUIContent (Ability1));
			GUI.Label (new Rect (sWidth * 1 / 6, sHeight * 5 / 7, sWidth * 4 / 6, sHeight / 6), tutorialText3, tutorialStyle);
				}

		if (tutorialStep > 3) {
			GUI.Label (new Rect (sWidth * 1 / 7, sHeight * 1 / 4, sWidth / 2, sHeight * 7 / 15), new GUIContent (Ability2));
			GUI.Label (new Rect (sWidth * 1 / 6, sHeight * 5 / 7, sWidth * 4 / 6, sHeight / 6), tutorialText4, tutorialStyle);
				}

		if (tutorialStep == 5) {
			GUI.Label (new Rect (sWidth * 3 / 5, sHeight * 1 / 4, sWidth / 2, sHeight * 7 / 15), new GUIContent (Ability3));
			GUI.Label (new Rect (sWidth * 1 / 6, sHeight * 5 / 7, sWidth * 4 / 6, sHeight / 6), tutorialText5, tutorialStyle);
				}
				
		if (tutorialStep < 5) {
						if (GUI.Button (new Rect (sWidth / 2 - sWidth / 16, sHeight - sHeight / 16, sWidth / 8, sHeight / 15), "Next", btnStyle)) {
								tutorialStep++;
						}
				}

		if (tutorialStep == 5) {
						if (GUI.Button (new Rect (sWidth / 2 - sWidth / 16, sHeight - sHeight / 16, sWidth / 8, sHeight / 15), "Return", btnStyle)) {
								this.gameObject.GetComponent<MainMenu> ().enabled = true;
								this.gameObject.GetComponent<Tutorial> ().enabled = false;
								tutorialStep = 1;
						}
				}
				btnStyle.fontSize = (int)sHeight/30;
		}
}
