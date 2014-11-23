using UnityEngine;
using System.Collections;

public class IcicleSpawner : MonoBehaviour {

	//Private variables
	private float sWidth;
	private float sHeight;
	private int spawnTimer = 0;

	private int score;

	private Vector3[] SpawnPoints = new Vector3[17];


	//Public variables
	public GameObject icicle;

	// Use this for initialization
	void Start () {
		sHeight = Screen.height;
		sWidth = Screen.width;

		for(int i = 1; i < 18; i++){
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(sWidth *i/18, sHeight, 10));
			SpawnPoints[i-1] = pos;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		score = Camera.main.gameObject.GetComponent<Score>().score;
		int dif = (int) (score / 1000)+5;
		if (dif > 12)
						dif = 12;
		spawnTimer++;
		if (spawnTimer == 60) {
			spawnTimer = 0;
			int num = Random.Range (0,dif);
			while(num < dif){
				int point = Random.Range(0, 17);
				spawnIcicle(point);
				num++;
			}
		}
	}

	void spawnIcicle(int point){
		Instantiate(icicle, SpawnPoints[point], icicle.transform.rotation);
	}
}
