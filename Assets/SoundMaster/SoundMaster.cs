using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
    const float BEAT_DURATION = 2;
    const float MAIN_DURATION = 24;
	int enemiesOf8;
	int enemiesOf4;
	int enemiesOf2;

	private float nextActionTimer = 0;
    private float nextMainTimer = 0;
    private AudioSource sourceMain;
	private AudioSource source8;
	private AudioSource source4;
	private AudioSource source2;
	public AudioClip[] vl;
	public AudioClip pa;
	public AudioClip vp;
    public AudioClip mainTheme;
	private GameController controller;

	public event BeatListener beatListeners;
	public delegate void BeatListener (float beatDuration);

	// Use this for initialization
	void Start () {
        sourceMain = GetComponent<AudioSource> ();
		source8 = gameObject.AddComponent < AudioSource > ();
		source8.mute = true;
		source4 = gameObject.AddComponent < AudioSource > ();
		source4.mute = true;
		source2 = gameObject.AddComponent < AudioSource > ();
		source2.mute = true;
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent < GameController > ();
	}

	void Update()
	{
		if (Time.time >= nextMainTimer) //MAIN THEME
		{
			//Debug.Log ("StartingMain");
			sourceMain.PlayOneShot(mainTheme);
			nextMainTimer = nextMainTimer + MAIN_DURATION;
		}

		if (Time.time >= nextActionTimer) // 1BAR
		{
			//parseStart.measureStarted (); <- QUE???
			nextActionTimer = nextActionTimer + BEAT_DURATION;
			//Debug.Log ("nextAction =" + nextActionTimer);
			//Debug.Log ("CurrentTime = " + Time.time);

			enemiesOf8 = controller.GetNrEnemiesForFrequency (8);
			enemiesOf4 = controller.GetNrEnemiesForFrequency (4);
			enemiesOf2 = controller.GetNrEnemiesForFrequency (2);
			//print (enemiesOf2 + "-" + enemiesOf8);

			//Debug.Log ("enemiesOf8 = " + enemiesOf8);

			int selectViolin = Random.Range (0, vl.Length - 1);
			source8.PlayOneShot (vl [selectViolin]);
			source2.PlayOneShot (pa);
			source4.PlayOneShot (vp);

			if (enemiesOf8 > 0) {
				source8.mute = false;
			} else
				source8.mute = true;

			if (enemiesOf2 > 0) {
				source2.mute = false;
			} else
				source2.mute = true;

			if (enemiesOf4 > 0) {
				source4.mute = false;
			} else
				source4.mute = true;

			if (beatListeners != null) {
				beatListeners (BEAT_DURATION);
			}

		}

	}
}

		