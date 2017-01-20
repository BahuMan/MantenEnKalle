using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
	private float nextActionTimer;
	public bool enemy1_ready;
	private AudioSource source;
	public AudioClip[] vl;

	public EventNot parseStart;

	// Use this for initialization
	void Start () {
		nextActionTimer = Time.time	+ 4;
		enemy1_ready = false;
		source = GetComponent < AudioSource > ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextActionTimer) {
			parseStart.measureStarted ();
			Debug.Log ("Displayistest");
			if (enemy1_ready) {
				int soundSelector = Random.Range(0, vl.Length - 1); 
				source.PlayOneShot (vl[soundSelector]);
			}
			nextActionTimer = Time.time + 4;
	}
}
}
