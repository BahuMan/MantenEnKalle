using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour {

    public float blastSpeed;
    public float maxX = 250;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * blastSpeed * Time.deltaTime;

        if (transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
	}
}
