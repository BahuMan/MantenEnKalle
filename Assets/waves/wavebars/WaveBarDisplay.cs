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
	private Material[] materials;
	public Color[] colors;
	public Color defaultColor = Color.white;

	public RythmCheck rythm;

	// Use this for initialization
	void Start () {
		waves = new GameObject[waveFreq.Count];
		waverenderers = new WaveFormRender[waveFreq.Count];
		materials = new Material[waveFreq.Count];
		for (int i = 0; i < waveFreq.Count; i++) {
			waves[i] = GameObject.Instantiate <GameObject> (wavePrefab, transform);
			waverenderers [i] = waves [i].GetComponent<WaveFormRender> ();
			materials[waveFreq.Count - i-1] = waves [i].GetComponent<Renderer> ().material;

			waverenderers [i].waveheight = heightOfBars * percentUsed / 2f / waveFreq.Count;
			waverenderers [i].frequency = waveFreq [i];
			//waverenderers [i].speed = waverenderers [i].width/maatWidth * 
			Transform waveTransform = waves [i].transform;
			waveTransform.localPosition = new Vector3(0, (i+0.5f) * heightOfBars / waveFreq.Count-heightOfBars, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		RythmCheck.RythmData rythmData = rythm.rythmCheckFull ();
		for (int i = 0; i < materials.Length; i++) {
			materials [i].color = Color.Lerp (defaultColor, colors [i], rythmData.rythmscores [i]*rythmData.phasescores [i]);
		}
	}
}
