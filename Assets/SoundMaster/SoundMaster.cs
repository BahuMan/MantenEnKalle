using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
	private float nextActionTimer;
	public bool enemy1_ready;
	public bool enemy2_ready;
	//public bool enemy3_ready;
	//public bool enemy4_ready;
	private AudioSource source;
	public AudioClip[] vl;
	public AudioClip bd;
	//public AudioClip pa;
	//public AudioClip[] vp;

	public EventNot parseStart;

	// Use this for initialization
	void Start () {
		enemy1_ready = false;
		enemy2_ready = false;
		nextActionTimer = Time.time + 4;
		source = GetComponent<AudioSource> ();
		if (source == null) {
			Debug.Log("NIETGEVONDEN");
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextActionTimer)
        {
            //parseStart.measureStarted ();
            if (enemy1_ready)
            {
                int soundSelector = Random.Range(0, vl.Length - 1);
                source.PlayOneShot(vl[soundSelector]);
				enemy1_ready = false;
            }
            nextActionTimer = Time.time + 4;
            int soundSelectorS = Random.Range(0, vl.Length);
            source.PlayOneShot(vl[soundSelectorS]);
            Debug.Log(soundSelectorS);
        }
    }

}
