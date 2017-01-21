using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, EventNot {

    public GameObject blastPrefab;
    public Collider2D ground;
	public SoundMaster sm;
    public float jumpForce = 15f;
    private Rigidbody2D thisRigid;
    private HashSet<float> timeStamps;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
        timeStamps = new HashSet<float>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //add a new timeStamp
            timeStamps.Add(Time.time);
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
	}

    //remove all timeStamps older than last second
    private void updateSlidingWindow()
    {

    }

    public int getNrBeats()
    {
        return timeStamps.Count;
    }

	public void measureStarted()
    {
        Debug.Log("last # beats: " + getNrBeats());
        timeStamps.Clear();
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
