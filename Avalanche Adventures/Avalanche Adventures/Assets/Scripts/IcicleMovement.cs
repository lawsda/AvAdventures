using UnityEngine;
using System.Collections;

public class IcicleMovement : MonoBehaviour {

	public float fallSpeed;

	public GameObject currency;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, fallSpeed * Time.deltaTime, 0);

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Power") {
			int num = Random.Range(0,5);
			if(num == 1)
				DropCurrency();
			Destroy (gameObject);
		}
		if (target.gameObject.tag == "Floor") {
			Destroy (gameObject);		
		}
	}

	void DropCurrency(){
		Instantiate (currency, transform.position, transform.rotation);
	}

}
