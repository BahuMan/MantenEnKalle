using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class WaveFormRender : BaseWaveFormRenderer {
	
	public float lineheight = .15f;

	public float frequency = 1f;
	public float speed = -2f;

	public float waveheight = 1f;

	public float power = 4f;

	public AnimationCurve wavemultiplier = new AnimationCurve();

	// Use this for initialization
	void Start () {
		InitMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWave (delegate(float t) {
			float multiplier = wavemultiplier.Evaluate(t);
			if(multiplier<0) {
				multiplier = 0;
			}

			float y = Mathf.Sin ((t+speed*Time.timeSinceLevelLoad)*Mathf.PI*2*frequency+Mathf.PI/2);
			if(y<0) {
				y = 0f;
			} else {
				y=Mathf.Pow(y, power);
			}
			y = y*multiplier*waveheight;

			float ytop = lineheight/2f;
			float ybottom = -lineheight/2f;

			return new Vector2(y+ybottom, y+ytop);
		});
	}
}
