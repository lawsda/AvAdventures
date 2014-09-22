using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	private float sHeight;
	private float sWidth;
	public float speed;
	private int dir = 0;
	private bool dead = false;
	private int death = 0;


	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;
	}

	// Update is called once per frame
	void Update () {
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
		if (GUI.RepeatButton (new Rect (0, sHeight - sHeight / 18, sWidth / 16, sHeight / 18), "<")) {
			dir = -1;
			transform.localScale = new Vector3(1, 1, 1);
		}if (GUI.RepeatButton (new Rect (sWidth - sWidth / 16, sHeight - sHeight / 18, sWidth / 16, sHeight / 18), ">")) {
			dir = 1;
			transform.localScale = new Vector3(-1, 1, 1);
		}

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
	}
}
