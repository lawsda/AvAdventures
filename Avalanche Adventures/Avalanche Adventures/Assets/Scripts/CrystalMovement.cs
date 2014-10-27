using UnityEngine;
using System.Collections;

public class CrystalMovement : MonoBehaviour {

	int timer = 640;

	// Use this for initialization
	void Start () {
		float num = Random.Range (50, 150);
		int rand = Random.Range (-1, 2);
		gameObject.rigidbody2D.AddForce(new Vector2(num*rand, 100f));
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
		if (timer == 0)
						Destroy (gameObject);
	}
}
