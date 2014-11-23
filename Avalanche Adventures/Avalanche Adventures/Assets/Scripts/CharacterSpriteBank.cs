using UnityEngine;
using System.Collections;

public class CharacterSpriteBank : MonoBehaviour {

	private int charSelected = 0;
	private string charSelectKey = "CharacterSelected";

	private Sprite Character;

	//Static Player Sprites
	public Sprite Edmund;
	public Sprite Cinder;
	public Sprite Rob;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		charSelected = PlayerPrefs.GetInt (charSelectKey, 0);

		if (charSelected == 0)
						Character = Edmund;
				else if (charSelected == 1)
						Character = Cinder;
				else if (charSelected == 2)
						Character = Rob;

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = Character;
	}
}
