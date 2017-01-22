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

	public float maatMeasuring = 0;

	public float curveFaseShift = 0;

	public AnimationCurve wavemultiplier = new AnimationCurve();

	// Use this for initialization
	void Start () {
		InitMesh ();

		SoundMaster sm = GameObject.FindWithTag ("SoundMaster").GetComponent<SoundMaster>();
		sm.beatListeners += delegate(float beatDuration) {
			// Do as if the music started > 2 beats ago (easier for calculations)
			maatMeasuring = Time.time-beatDuration*10;
		};

		int iters = 200;
		float max = -1;
		float maxPercent = 0;
		for (int i = 0; i <= iters; i++) {
			float t = i * 1f / iters;
			float multiplier = wavemultiplier.Evaluate(t);
			if(multiplier > max) {
				max = multiplier;
				maxPercent = t;
			}
		}
		curveFaseShift = maxPercent;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWave (delegate(float t) {
			float multiplier = wavemultiplier.Evaluate(t);
			if(multiplier<0) {
				multiplier = 0;
			}

			float y = Mathf.Sin (((t-curveFaseShift)*speed+(Time.time-maatMeasuring+.5f))*Mathf.PI*2*frequency+Mathf.PI/2);
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
