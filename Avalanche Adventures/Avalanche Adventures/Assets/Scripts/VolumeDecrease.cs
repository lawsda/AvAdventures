using UnityEngine;
using System.Collections;

public class VolumeDecrease : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		float vol = gameObject.audio.volume;
		if(vol > 0f)
		gameObject.audio.volume = vol - 0.01f;
	}
}
