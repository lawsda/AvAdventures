using UnityEngine;
using System.Collections;

public class IcicleMovement : MonoBehaviour {

	public float fallSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, fallSpeed * Time.deltaTime, 0);
		if (transform.position.y < -4.5)
						Destroy (gameObject);
	}

/*	void OnTriggerEnter2D(Collider2D target){
			if (target.gameObject.tag == "Player")
						Destroy (gameObject);
		}*/
}
