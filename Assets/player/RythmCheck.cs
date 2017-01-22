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

	public float maatMeasuring = 0;

	public bool doCheckWithFase = true;

	void Start() {
		player = GetComponent<PlayerController> ();
		SoundMaster sm = GameObject.FindWithTag ("SoundMaster").GetComponent<SoundMaster>();
		sm.beatListeners += delegate(float beatDuration) {
			// Do as if the music started > 2 beats ago (easier for calculations)
			maatMeasuring = Time.time-beatDuration*10;
		};
	}

	//rythmcheck method
	public int rythmCheck()
	{
		float timeSinceMusicStart = Time.time - maatMeasuring;

		//copying timestamps from playercontroller
		List<float> timeStamp = player.getTimeStamp ();
		List<float> timeStamp2 = new List<float>();
		float startOfRange = Time.time - period * 1.2f;
		foreach (float spacebarTime in timeStamp) {
			if (spacebarTime > startOfRange) {
				timeStamp2.Add (spacebarTime-maatMeasuring);
			}
		}

		BESTRYTHM = -1;
		SCORE = 0;

		TICK = (int)((timeSinceMusicStart * 2) % 2);

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

			float percentCorrect = 0;
			if (doCheckWithFase) {
				percentCorrect = (correctCount+faseCorrectCount) * 1f / (tapCount + tapCount - 1);
			} else {
				percentCorrect = (correctCount) * 1f / (tapCount - 1);
			}
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
