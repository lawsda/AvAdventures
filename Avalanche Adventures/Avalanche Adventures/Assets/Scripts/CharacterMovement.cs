using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	//Private variables
	private float sHeight;
	private float sWidth;
	private int dir = 0;
	private bool dead = false;
	private int death = 0;
	private bool hasPower = false;
	private int castingPower = 0;
	private Animator anim;

	//PlayerPrefs Storage
	private int currency = 0;
	private string currencyKey = "Crystals";
	private int level = 1;
	private string levelKey = "CharLevel";
	private int charSelected = 0;
	private string charSelectKey = "CharacterSelected";
	private int upgradeLevel = 1;
	private string upgradeLevelKey = "UpgradeLevel";

	//Public variables
	public float speed;
	public GUIStyle btnRStyle;
	public GUIStyle btnLStyle;
	public GUIStyle blank;
	public GameObject Power;
	public int cooldown;
	public int powerCD;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;
		anim = GetComponent<Animator> ();


		currency = PlayerPrefs.GetInt (currencyKey, 0);
		charSelected = PlayerPrefs.GetInt (charSelectKey, 0);
		upgradeLevel = PlayerPrefs.GetInt (upgradeLevelKey + charSelected, 1);
		levelKey += charSelected;
		level = PlayerPrefs.GetInt (levelKey, 1);

		//power CD, goes down by 1s each level;
		cooldown = 60 * (19 - level);
		powerCD = cooldown;
	}

	// Update is called once per frame
	void Update () {
		if (powerCD > 0 && !hasPower)
						powerCD--;
				else {
			hasPower = true;
				}

		if (hasPower) {
						anim.SetBool ("playerEquip", true);
				} else {
			anim.SetBool ("playerEquip", false);
				}

		if (castingPower > 0) {
			if((castingPower %60) == 0)
				UsePower();
			castingPower--;
				}

		//move animation
		if(dir != 0)
			anim.SetBool("playerWalking", true);
		else
			anim.SetBool("playerWalking", false);

		//edge check
		if (transform.position.x >= 7.6 && dir == 1)
						dir = 0;
		if (transform.position.x <= -7.6 && dir == -1)
						dir = 0;
		transform.Translate (speed * dir * Time.deltaTime, 0, 0);
		dir = 0;


		if (dead)
						death++;
		if(death == 60)
						Destroy (gameObject);
	}

	void OnGUI(){
		//Key Input Based Control Scheme
		//For web version only
		// /*
		// */

		//UI Based Control Scheme
		//Control buttons
		if (GUI.RepeatButton (new Rect (0, sHeight - sHeight / 17, sWidth / 16, sHeight / 17), "", btnLStyle)) {
			dir = -1;
			transform.localScale = new Vector3(1, 1, 1);
		}if (GUI.RepeatButton (new Rect (sWidth - sWidth / 16, sHeight - sHeight / 18, sWidth / 16, sHeight / 18), "", btnRStyle)) {
			dir = 1;
			transform.localScale = new Vector3(-1, 1, 1);
		}

		//Power activation
		if (GUI.Button (new Rect (0, 0, sWidth, sHeight), "", blank)) {
			if(hasPower){
				powerCD = cooldown;
				hasPower = false;
				castingPower = (60*upgradeLevel);
			}
		}
	}

	void UsePower(){
		Instantiate (Power, transform.position, Power.transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D target){
		//Death
		if (target.gameObject.tag == "Icicle") {
			Camera.main.gameObject.GetComponent<VolumeDecrease>().enabled = true;
			Camera.main.gameObject.GetComponent<Score>().isDead = true;
			GameObject.Find("Spawner").gameObject.GetComponent<IcicleSpawner>().enabled = false;
			gameObject.GetComponent<AudioSource>().Play();
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
						dead = true;
				}
		if (target.gameObject.tag == "Currency") {
			Destroy(target.gameObject);
			currency++;
			PlayerPrefs.SetInt (currencyKey, currency);
			PlayerPrefs.Save();
				}
	}
	
}
