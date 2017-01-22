using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int frequency;
	public float speed;
    public GameObject particleEffect;
    public GameController theController;
    private Rigidbody2D thisRigid;
    public float jumpForce;
    public float littleJumpForce;

	// Use this for initialization
	void Start () {
        thisRigid = GetComponent<Rigidbody2D>();
        theController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = transform.position + transform.right * -speed * Time.deltaTime;
		thisRigid.velocity = transform.right * -speed + new Vector3(0, thisRigid.velocity.y, 0);
	}

    public int getFrequency()
    {
        return frequency;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        checkContact(col);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        checkContact(collision.collider);
    }

    private void checkContact(Collider2D col)
    {
        if (col.gameObject.tag == "HurtsEnemies")
        {

            BlastController blast = col.gameObject.GetComponent<BlastController>();
            if (blast != null)
            {
                Debug.Log("getting hurt by frequency " + blast.getFrequency());
                //depending on blast frequency, take different action
                if (blast.getFrequency() < 0)
                {
                    //this is a weenie blast; little jump
                    jump(littleJumpForce);
                }
                else if (blast.getFrequency() == frequency)
                {
                    selfDestruct();
                }
                else
                {
                    jump(jumpForce);
                }
            }
            else
            {
                Debug.Log("getting hurt - by a giant?");
                //a damaging object that is not a blast can only be the giant; here we self-destruct
                selfDestruct();
            }
        }

    }

    public void selfDestruct()
    {
        theController.enemyDied(this); //inform the controller about my death
        GameObject go = Instantiate(this.particleEffect);
        go.transform.position = transform.position;
        Destroy(go, 4);
        Destroy(gameObject);
    }

    public void jump(float force)
    {
        thisRigid.AddForce(this.transform.up * force, ForceMode2D.Impulse);
    }
}
