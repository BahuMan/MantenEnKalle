using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBarDisplay : MonoBehaviour {

	public List<float> waveFreq;

	public float heightOfBars = 3f;
	public float percentUsed = 0.8f;
	public float maatWidth = 2f;

	public GameObject wavePrefab;

	private GameObject[] waves;
	private WaveFormRender[] waverenderers;

	// Use this for initialization
	void Start () {
		waves = new GameObject[waveFreq.Count];
		waverenderers = new WaveFormRender[waveFreq.Count];
		for (int i = 0; i < waveFreq.Count; i++) {
			waves[i] = GameObject.Instantiate <GameObject> (wavePrefab, transform);
			waverenderers [i] = waves [i].GetComponent<WaveFormRender> ();

			waverenderers [i].waveheight = heightOfBars * percentUsed / 2f / waveFreq.Count;
			waverenderers [i].frequency = waveFreq [i];
			//waverenderers [i].speed = waverenderers [i].width/maatWidth * 
			Transform waveTransform = waves [i].transform;
			waveTransform.localPosition = new Vector3(0, (i+0.5f) * heightOfBars / waveFreq.Count-heightOfBars, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
