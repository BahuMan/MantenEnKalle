using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	private RythmCheck check;

    public GameObject blastPrefab;
    public Collider2D ground;
	public SoundMaster sm;
    private Rigidbody2D thisRigid;
    public HealthBarController healthBart;

	private List<float> timeStamp = new List<float>();

	private GroundWaveRenderer groundWave;

	public List<Color> colors;

	public float period = 2;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
		check = GetComponent<RythmCheck> ();
		groundWave = GameObject.FindWithTag ("ground_foreground").GetComponent<GroundWaveRenderer>();
		SoundMaster sm = GameObject.FindWithTag ("SoundMaster").GetComponent<SoundMaster>();
		sm.beatListeners += delegate(float beatDuration) {
			doEndOfMaat ();
		};
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //add a new timeStamp
			timeStamp.Add(Time.time);

			// only keep the last 20 taps
			if (timeStamp.Count > 20) {
				timeStamp.RemoveAt (0);
			}
        }
	}

	public List<float> getTimeStamp()
    {
        return timeStamp;
    }


	public void doEndOfMaat()
    {
		// Do finale rythmCheck
		int lastRythm = check.rythmCheck ();

		if (lastRythm > 0) {
			groundWave.stampBig ();
			blast (lastRythm);
		} else {
			groundWave.stampSmall ();
		}
    }

    private void blast(int frq)
    {
		GameObject go = Instantiate (blastPrefab);
		go.GetComponent<BlastController>().setFrequency(frq);
		Color color;
		if (frq == 2) {
			color = colors[0];
		} else if (frq == 4) {
			color = colors[1];
		} else if (frq == 8) {
			color = colors[2];
		} else {
			color = Color.cyan;
		}


		go.GetComponent<SpriteRenderer> ().color = color;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Ground Collider")
        {
            Debug.Log("giant was hit by " + collision.gameObject);
            this.healthBart.LostALive();
        }
    }
}
