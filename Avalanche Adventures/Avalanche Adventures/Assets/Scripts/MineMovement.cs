using UnityEngine;
using System.Collections;

public class MineMovement : MonoBehaviour {

	public float fallSpeed;
	
	private float sHeight;
	public int explodeTimer = 90;

	private BoxCollider2D bCol;
	
	private Animator anim;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		anim = GetComponent<Animator> ();
		
		fallSpeed = sHeight / 120.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(fallSpeed > 0.0f)
						fallSpeed -= 0.06f;
		if (fallSpeed < 0.0f)
						fallSpeed = 0.0f;
		if (fallSpeed == 0.0f)
						explodeTimer--;

		if (explodeTimer <= 0) {
						anim.SetBool ("mineExplode", true);
						bCol = gameObject.GetComponent<BoxCollider2D> ();
						bCol.size = new Vector2(2,2);
				}
		
		transform.Translate (0, fallSpeed * Time.deltaTime, 0);

		if (explodeTimer <= -60)
						Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D target){
				if (target.gameObject.tag == "Icicle") {
					explodeTimer = 0;
				}
		}
}
