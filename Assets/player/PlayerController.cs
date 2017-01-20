using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, EventNot {

	public SoundMaster sm;
    public float jumpForce = 15f;
    private Rigidbody2D thisRigid;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            thisRigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("jump!");
        }
	}

	public void measureStarted(){}
}
