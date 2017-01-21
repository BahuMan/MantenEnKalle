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

		// Calculate feedback
		check.rythmCheck ();
	}

	public List<float> getTimeStamp()
    {
        return timeStamp;
    }

	public void measureStarted()
    {
		// Do finale rythmCheck
		check.rythmCheck ();
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
