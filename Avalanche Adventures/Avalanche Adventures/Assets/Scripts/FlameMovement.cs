using UnityEngine;
using System.Collections;

public class FlameMovement : MonoBehaviour {

	private float x, y;

	private int timer = 180;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		y = GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y;
		x = GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x;

		transform.position = new Vector3 (x, y , -1);

		timer--;
		if (timer <= 0)
						Destroy (gameObject);
	}
}
