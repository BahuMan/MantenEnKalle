using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
    const float BEAT_DURATION = 2;
    const float MAIN_DURATION = 24;

	private float nextActionTimer = 0;
    private float nextMainTimer = 0;
    private AudioSource source;
	public AudioClip[] vl;
	public AudioClip bd;
    public AudioClip mainTheme;
	private GameController controller;
	//public AudioClip pa;
	//public AudioClip[] vp;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource> ();
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent < GameController > ();
	}

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextActionTimer)
        {
            //parseStart.measureStarted ();
			Debug.Log ("nextAction =" + nextActionTimer);

			if (controller.GetNrEnemiesForFrequency(8) > 0)
            {
				Debug.Log ("startInstrument8");
                int soundSelector = Random.Range(0, vl.Length - 1);
                source.PlayOneShot(vl[soundSelector]);
            }

			if (controller.GetNrEnemiesForFrequency(2) > 0)
			{
				Debug.Log ("startInstrument2");
				source.PlayOneShot (bd);
			}
				
			nextActionTimer = nextActionTimer + BEAT_DURATION;
        }

        if (Time.time >= nextMainTimer)
        {
			Debug.Log ("StartingMain");
            source.PlayOneShot(mainTheme);
			nextMainTimer = nextMainTimer + MAIN_DURATION;
        }
    }

}
