using UnityEngine;
using System.Collections;

public class ArcadeMenu : MonoBehaviour {

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
		string HSLabel = "High Score: "+ highScore;
		HSStyle.fontSize = (int)sHeight/30;
		GUI.Label (new Rect (2, 0, sWidth, sHeight), HSLabel, HSStyle);

		//Main title
		titleStyle.fontSize = (int)sHeight/12;
		title2Style.fontSize = (int)sHeight/12;
		titleStyle.fontStyle = FontStyle.Italic;
		title2Style.fontStyle = FontStyle.Italic;
		GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Avalanche Adventures", titleStyle);
		GUI.Label (new Rect (0, sHeight / 6, sWidth, sHeight), "Avalanche Adventures", title2Style);
		//Sub-title
		titleStyle.fontSize = (int)sHeight/18;
		title2Style.fontSize = (int)sHeight/18;
		titleStyle.fontStyle = FontStyle.Normal;
		title2Style.fontStyle = FontStyle.Normal;
		GUI.Label (new Rect (0, sHeight / 6 + sHeight/12, sWidth, sHeight), "Arcade Mode", titleStyle);
		GUI.Label (new Rect (0, sHeight / 6 + sHeight/12, sWidth, sHeight), "Arcade Mode", title2Style);

		//Menu buttons
		btnStyle.fontSize = (int)sHeight/25;
		if (GUI.Button (new Rect (sWidth / 5, sHeight / 2 , sWidth / 5, sHeight / 10), "Start", btnStyle)) {
			//Start the game
			this.gameObject.GetComponent<AudioSource> ().enabled = true;
			this.gameObject.GetComponent<Score> ().enabled = true;
			GameObject.Find("Climber_v2.1").gameObject.GetComponent<CharacterMovement>().enabled = true;
			GameObject.Find("Spawner").gameObject.GetComponent<IcicleSpawner>().enabled = true;
			GameObject.Find("IceMenu").gameObject.GetComponent<AudioSource>().enabled = false;
			transform.position = new Vector3(0,0,-10);
			this.gameObject.GetComponent<ArcadeMenu> ().enabled = false;
		}

		if (GUI.Button (new Rect (sWidth *3/5, sHeight / 2, sWidth / 5, sHeight / 10), "Shop", btnStyle)) {

		}
		btnStyle.fontSize = (int)sHeight/30;
		if (GUI.Button (new Rect (sWidth / 2 - sWidth / 10, sHeight - sHeight/15, sWidth / 5, sHeight / 20), "Return", btnStyle)) {
			Application.LoadLevel(0);
		}


	}

}
