using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCheck : MonoBehaviour {

	private PlayerController player;
	public int period = 4;
	public int top = 1/2;
	private int counter = 0;
	private List<float> timeStamp2 = new List<float>();
	public float acceptedDifference = 0.1f;
	public int rythm = 0;

	//boolean to check wich rythm
	private bool[] measureBool = new bool[100];

	void Start() {
		player = GetComponent<PlayerController> ();
	}



	//rythmcheck method
	public void rythmCheck()
	{
		//copying timestamps from playercontroller
		timeStamp2 = player.getTimeStamp ();

		for (int i = 0; i < timeStamp2.Count; i++) {
			if ((timeStamp2 [i] % period) - i*top <= acceptedDifference && (timeStamp2 [i] % period) - i*top  >= -acceptedDifference) {
				measureBool [i] = true;
			} else {
				measureBool [i] = false;
			}
		}

		for (int i = 0; i < timeStamp2.Count; i++) {
			if (measureBool [i] == true)
				counter++;	
		}

		if (measureBool [1] == true && measureBool [5] == true)
			rythm = 1;

		if (measureBool [1] == true && measureBool [3] == true && measureBool [5] == true && measureBool [7] == true)
			rythm = 2;

		if (counter == 8)
			rythm = 3;	
	}

	public void reset()
	{
		counter = 0;
	}
}
