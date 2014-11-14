using UnityEngine;
using System.Collections;

public class PickMovement : MonoBehaviour {

	public float fallSpeed;

	private float sHeight;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;

		fallSpeed = sHeight / 60.0f;
	}
	
	// Update is called once per frame
	void Update () {
		fallSpeed -= .06f;

		transform.Translate (0, fallSpeed * Time.deltaTime, 0);

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Icicle") {
		//	Destroy (target.gameObject);
		}
		if (target.gameObject.tag == "Floor") {
			Destroy (gameObject);		
		}
	}
}
