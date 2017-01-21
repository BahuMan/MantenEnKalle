using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int frequency;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + transform.right * -speed * Time.deltaTime;
	}

    public int getFrequency()
    {
        return frequency;
    }

}
