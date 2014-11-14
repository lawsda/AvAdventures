using UnityEngine;
using System.Collections;

public class ArcadeMenu : MonoBehaviour {

	//Private variables
	private float sHeight;
	private float sWidth;
	private int levelExp;

	private int highScore = 0;
	private string highScoreKey = "HighScore";
	private int level = 1;
	private string levelKey = "CharLevel";
	private int currentPlayerExp = 0;
	private string playerExpKey = "PlayerExp";
	private int charSelected = 0;
	private string charSelectKey = "CharacterSelected";

	//Public variables
	public GUIStyle titleStyle;
	public GUIStyle title2Style;
	public GUIStyle btnStyle;
	public GUIStyle HSStyle;
	public GUIStyle expStyle;

	//Characters
	public GameObject Edmund;
	public GameObject Cinder;
	private GameObject Player;


	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;

		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		charSelected = PlayerPrefs.GetInt (charSelectKey, 0);
		playerExpKey += charSelected;
		currentPlayerExp = PlayerPrefs.GetInt (playerExpKey, 0);
		levelKey += charSelected;
		level = PlayerPrefs.GetInt (levelKey, 1);

	}
	
	// Update is called once per frame
	void Update () {
		levelExp = (int) (120 + 120 * (1.5 * (level - 1)));
		if (currentPlayerExp >= levelExp) {
			level++;
		}
	}

	void OnDisable(){
		PlayerPrefs.SetInt(levelKey, level);
		PlayerPrefs.Save();
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
			//Spawn Player
			if(charSelected == 0)
				Player = Edmund;
			else if(charSelected == 1)
				Player = Cinder;

			Instantiate(Player, Player.transform.position, Player.transform.rotation);

			//Load game settings
			this.gameObject.GetComponent<AudioSource> ().enabled = true;
			this.gameObject.GetComponent<Score> ().enabled = true;
			GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CharacterMovement>().enabled = true;
			GameObject.Find("Spawner").gameObject.GetComponent<IcicleSpawner>().enabled = true;
			GameObject.Find("IceMenu").gameObject.GetComponent<AudioSource>().enabled = false;
			transform.position = new Vector3(0,0,-10);
			this.gameObject.GetComponent<ArcadeMenu> ().enabled = false;
		}


		string expLabel = "Level: "+ level +"\nEXP: "+currentPlayerExp+"/"+levelExp;
		GUI.Label (new Rect (sWidth / 2 - sWidth / 10, sHeight/2 + sHeight/12, sWidth / 5, sHeight / 20), expLabel, expStyle);

		if (GUI.Button (new Rect (sWidth *3/5, sHeight / 2, sWidth / 5, sHeight / 10), "Characters", btnStyle)) {
			Application.LoadLevel(2);
		}
		btnStyle.fontSize = (int)sHeight/30;
		if (GUI.Button (new Rect (sWidth - sWidth / 8, 0, sWidth / 8, sHeight / 15), "Return", btnStyle)) {
			Application.LoadLevel(0);
		}


	}

}
