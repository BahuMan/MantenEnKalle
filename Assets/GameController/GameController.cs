﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    public Dictionary<int, List<EnemyController>> enemiesPerFrequency;
    public float enemyInterval = 1000;
    private float nextEnemyTime;

	// Use this for initialization
	void Start () {
        //for each frequency, we keep a list of enemies on the field:
        enemiesPerFrequency = new Dictionary<int, List<EnemyController>>();
        nextEnemyTime = Time.time + enemyInterval;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextEnemyTime)
        {
            Debug.Log("spawning");
            nextEnemyTime = Time.time + enemyInterval;
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        int randomChoice = Random.Range(0, enemyPrefabs.Length);
        GameObject go = Instantiate(enemyPrefabs[randomChoice]);
        EnemyController ectrl = go.GetComponent<EnemyController>();

        //now add it to our lists, and create a new list if we don't have a list yet:
        if (!enemiesPerFrequency.ContainsKey(ectrl.getFrequency()))
        {
            enemiesPerFrequency.Add(ectrl.getFrequency(), new List<EnemyController>());
        }
        List<EnemyController> flist = enemiesPerFrequency[ectrl.getFrequency()];
        flist.Add(ectrl);

    }

    public void enemyDied(EnemyController enemy)
    {
        int frq = enemy.getFrequency();
        List<EnemyController> flist = enemiesPerFrequency[frq];
        if (!enemiesPerFrequency.ContainsKey(frq))
        {
            Debug.LogError("Could not find list for frequency " + frq);
        }
    }

	public int GetArrayTypeIndex(int type) {
		int temp = Random.Range (0, 1);
		return temp;
	}
}

	
