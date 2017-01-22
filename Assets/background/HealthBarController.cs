using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour {

    public GameObject FilledHeart;
    public GameObject EmptyHeart;
    public float displacement = 5;
    public int lives = 10;
    private int currentLives;
    public GameObject[] hearts;

	// Use this for initialization
	void Start () {
        hearts = new GameObject[lives];
        for (int i=0; i<hearts.Length; ++i)
        {
            hearts[i] = Instantiate(FilledHeart);
            hearts[i].transform.position = transform.position + transform.right * displacement * i;
        }
        currentLives = lives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LostALive()
    {
        currentLives--;
        if (currentLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Destroy(hearts[currentLives]);
            hearts[currentLives] = Instantiate(EmptyHeart);
            hearts[currentLives].transform.position = transform.position + transform.right * displacement * currentLives;

        }

    }
}
