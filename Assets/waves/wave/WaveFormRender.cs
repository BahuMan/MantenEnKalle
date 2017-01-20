using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class WaveFormRender : BaseWaveFormRenderer {
	
	public float lineheight = .15f;

	public float frequency = 1f;
	public float speed = -2f;

	// Use this for initialization
	void Start () {
		InitMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWave (delegate(float t) {
			float multiplier = Mathf.Sin (t * Mathf.PI);

			float y = Mathf.Sin ((t+speed*Time.timeSinceLevelLoad)*Mathf.PI*2*frequency)*multiplier;

			float ytop = lineheight/2f;
			float ybottom = -lineheight/2f;

			return new Vector2(y+ybottom, y+ytop);
		});
	}
}
