using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	private RythmCheck check;

    public GameObject blastPrefab;
    public Collider2D ground;
	public SoundMaster sm;
    public float jumpForce = 15f;
    private Rigidbody2D thisRigid;

	private List<float> timeStamp = new List<float>();

	private GroundWaveRenderer groundWave;

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

            if (thisRigid.IsTouching(ground))
            {
                thisRigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("not grounded");
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
			blast ();
		} else {
			groundWave.stampSmall ();
		}
    }

    private void blast()
    {
        Instantiate(blastPrefab);

    }
}
