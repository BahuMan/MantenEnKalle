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
	private float waveheight = 0.3f;
	public float waveheightsmall = 0.3f;
	public float waveheightbig = 0.3f;

	public float starttime = -1000f;
	public float movespeed = 1;
	public float xwidth = 0.1f;

	public float stampShift = 0;

	// Use this for initialization
	void Start () {
		InitMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWave (delegate(float x) {
			float timerunning = Time.time-starttime;

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

	private void makeWave() {
		starttime = Time.time + stampShift;
	}

	public void stampSmall() {
		waveheight = waveheightsmall;
		makeWave ();
	}

	public void stampBig() {
		waveheight = waveheightbig;
		makeWave ();
	}
}
