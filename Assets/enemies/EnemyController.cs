using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int frequency;
	public float speed;
    private Rigidbody2D thisRigid;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = transform.position + transform.right * -speed * Time.deltaTime;
        thisRigid.AddForce(transform.right * -speed);
	}

    public int getFrequency()
    {
        return frequency;
    }

}
