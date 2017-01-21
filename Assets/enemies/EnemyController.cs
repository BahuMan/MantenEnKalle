using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int frequency;
	public float speed;
    public GameObject particleEffect;
    public GameController theController;
    private Rigidbody2D thisRigid;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
        theController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = transform.position + transform.right * -speed * Time.deltaTime;
        thisRigid.velocity = transform.right * -speed;
	}

    public int getFrequency()
    {
        return frequency;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "HurtsEnemies")
        {
            theController.enemyDied(this); //inform the controller about my death
            GameObject go = Instantiate(this.particleEffect);
            go.transform.position = transform.position;
            Destroy(go, 4);
            Destroy(gameObject);
        }
    }
}
