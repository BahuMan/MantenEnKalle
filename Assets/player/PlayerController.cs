using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public Collider2D ground;
	public SoundMaster sm;
    public float jumpForce = 15f;
    private Rigidbody2D thisRigid;
    private HashSet<float> timeStamps;
	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
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


}
