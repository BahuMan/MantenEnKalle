using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
	private float nextActionTimer;
	private AudioSource source;
	public AudioClip[] vl;
	public AudioClip bd;
	private GameController controller;
	//public AudioClip pa;
	//public AudioClip[] vp;

	public EventNot parseStart;

	// Use this for initialization
	void Start () {
		nextActionTimer = Time.time + 4;
		source = GetComponent<AudioSource> ();
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent < GameController > ();
	}

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextActionTimer)
        {
            //parseStart.measureStarted ();


			if (controller.GetArrayTypeIndex(0) > 0)
            {
                int soundSelector = Random.Range(0, vl.Length - 1);
                source.PlayOneShot(vl[soundSelector]);
            }

			if (controller.GetArrayTypeIndex (0) > 0)
			{
				source.PlayOneShot (bd);
			}
				
            nextActionTimer = Time.time + 4;
            int soundSelectorS = Random.Range(0, vl.Length);
            source.PlayOneShot(vl[soundSelectorS]);
            Debug.Log(soundSelectorS);
        }
    }

}
