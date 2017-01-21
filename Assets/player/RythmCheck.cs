using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCheck : MonoBehaviour {

	private PlayerController player;
	public int period = 2;
	public float acceptedDifference = 0.1f;
	public List<int> tapsPerMaat;

	public int BESTRYTHM = 0;
	public float SCORE = 0;
	public int TICK = 0;

	void Start() {
		player = GetComponent<PlayerController> ();
	}

	//rythmcheck method
	public int rythmCheck()
	{
		//copying timestamps from playercontroller
		List<float> timeStamp2 = player.getTimeStamp ();

		BESTRYTHM = -1;
		SCORE = 0;

		TICK = (int)((Time.time * 2) % 2);

		for (int i = 0; i < tapsPerMaat.Count; i++) {
			int tapCount = tapsPerMaat [i];
			float expectedDifference = period * 1f / tapCount;
			int startj = timeStamp2.Count-tapCount;
			if (timeStamp2.Count < tapCount) {
				continue;
			}
			// Check ritme
			int correctCount = 0;
			int faseCorrectCount = 0;
			for (int j = 0; j < tapCount - 1; j++) {
				// Bereken tijd tussen twee opeenvolgende taps
				float verschil1 = timeStamp2 [startj+j + 1] - timeStamp2 [startj+j];
				float error = Mathf.Abs (verschil1 - expectedDifference);
				if (error < acceptedDifference) {
					// Tap correct
					correctCount++;
				}
			}

			// Check fase
			for (int j = 0; j < tapCount; j++) {
				var perfectTick = Mathf.Round(timeStamp2 [startj+j] / expectedDifference) * expectedDifference;
				var faseVerschil = Mathf.Abs (perfectTick - timeStamp2 [startj+j]);
				if (faseVerschil < acceptedDifference) {
					// Tap correct
					faseCorrectCount++;
				}
			}

			int expectedCorrect = tapCount + tapCount - 1;

			float percentCorrect = (correctCount) * 1f / (tapCount - 1);
			if (percentCorrect > SCORE) {
				SCORE = percentCorrect;
				BESTRYTHM = tapCount;
			}
		}
		if (SCORE > 0.98f) {
			return BESTRYTHM;
		} else {
			return -1;
		}
	}
}
