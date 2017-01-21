using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class GroundWaveRenderer : BaseWaveFormRenderer {
	
	public float xrepeat = 10;
	public float yrepeat = 10;

	public float groundlineheight = 10;

	public float wavefrequency = 1f;
	public float wavealterspeed = -2f;
	public float waveheight = 0.3f;

	public float starttime = 0f;
	public float movespeed = 1;
	public float xwidth = 0.1f;

	// Use this for initialization
	void Start () {
		InitMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			starttime = Time.timeSinceLevelLoad;
		}

		UpdateWave (delegate(float x) {
			float timerunning = Time.timeSinceLevelLoad-starttime;

			float wavepos = timerunning*movespeed;
			float y = 0;
			if(x > wavepos - xwidth && x < wavepos) {
				float wavex = (x-wavepos)/xwidth;

				float multiplier = Mathf.Sin (wavex * Mathf.PI);
				y = Mathf.Sin ((wavex+wavealterspeed*Time.timeSinceLevelLoad)*Mathf.PI*2*wavefrequency)*multiplier*waveheight;
			}

			float ytop = 0f;
			float ybottom = -groundlineheight;

			return new Vector2(y+ybottom, y+ytop);
		});
	}
}
