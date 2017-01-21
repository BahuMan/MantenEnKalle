﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
    const float BEAT_DURATION = 4;
    const float MAIN_DURATION = 3*BEAT_DURATION;

	private float nextActionTimer = 0;
    private float nextMainTimer = 0;
    private AudioSource source;
	public AudioClip[] vl;
	public AudioClip bd;
    public AudioClip mainTheme;
	private GameController controller;
	//public AudioClip pa;
	//public AudioClip[] vp;

	public EventNot parseStart;

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


			if (controller.GetNrEnemiesForFrequency(8) > 0)
            {
                int soundSelector = Random.Range(0, vl.Length - 1);
                source.PlayOneShot(vl[soundSelector]);
            }

			if (controller.GetNrEnemiesForFrequency(2) > 0)
			{
				source.PlayOneShot (bd);
			}
				
            nextActionTimer = Time.time + BEAT_DURATION;
        }

        if (Time.time >= nextMainTimer)
        {
            source.PlayOneShot(mainTheme);
            nextMainTimer = Time.time + MAIN_DURATION;
        }
    }

}
