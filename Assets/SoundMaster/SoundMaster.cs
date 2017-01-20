using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
<<<<<<< HEAD
	private float nextActionTimer;
	public bool enemy1_ready;
	public bool enemy2_ready;
	//public bool enemy3_ready;
	//public bool enemy4_ready;
	private AudioSource source;
	public AudioClip[] vl;
	public AudioClip bd;
	//public AudioClip pa;
	//public AudioClip[] vp;

	public EventNot parseStart;
=======
>>>>>>> 6ed384d55d6ee839c42cad01ef25dd110e8c1460

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if (Time.time >= nextActionTimer) {
			//parseStart.measureStarted ();
			if (enemy1_ready) {
				int soundSelector = Random.Range(0, vl.Length - 1); 
				source.PlayOneShot (vl[soundSelector]);
			}
			nextActionTimer = Time.time + 4;
			int soundSelectorS = Random.Range(0, vl.Length); 
			source.PlayOneShot (vl[soundSelectorS]);
			Debug.Log (soundSelectorS);
	    }


}

}
=======
		
	}
}
>>>>>>> 6ed384d55d6ee839c42cad01ef25dd110e8c1460
