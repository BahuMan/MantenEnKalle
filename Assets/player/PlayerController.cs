using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, EventNot {

	private RythmCheck check;

    public GameObject blastPrefab;
    public Collider2D ground;
	public SoundMaster sm;
    public float jumpForce = 15f;
    private Rigidbody2D thisRigid;

	private List<float> timeStamp = new List<float>();

	private int tempC = 0;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
		check = GetComponent<RythmCheck> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //add a new timeStamp
			timeStamp.Add(Time.time);
            if (thisRigid.IsTouching(ground))
            {
                thisRigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("not grounded");
            }
        }

        updateSlidingWindow();

		//rythmcheck

		if (tempC == 240) {
			check.rythmCheck ();
			tempC = 0;
			Debug.Log("Rythm: " + check.rythm);
		}
		
		tempC++;


	}

    //remove all timeStamps older than last second
    private void updateSlidingWindow()
        {

    }

	public List<float> getTimeStamp()
    {
        return timeStamp;
    }

	public void measureStarted()
    {
        //Debug.Log("last # beats: " + getNrBeats());
		timeStamp.Clear();
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider == ground)
        {
            blast();
        }
    }

    private void blast()
    {
        Instantiate(blastPrefab);
    }
}
