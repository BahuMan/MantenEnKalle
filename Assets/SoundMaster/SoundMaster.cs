using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
	private float nextActionTimer;
	public bool enemy1_ready;

	// Use this for initialization
	void Start () {
		nextActionTimer = Time.time	+ 4;
		enemy1_ready = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextActionTimer) {
			Debug.Log ("Displayistest");
			nextActionTimer = Time.time + 4;
	}
}
}
