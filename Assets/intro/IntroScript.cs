using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	public Renderer fadeRenderer;

	private float time;

	public float fadeTime = 1f;
	public float waitTime = 1f;

	public int nextScene = 1;

	public bool waitForSpace = false;
	public bool doFadeIn = true;
	public bool doFadeOut = true;

	private bool buttonPressed = true;

	// Use this for initialization
	void Start () {
		StartCoroutine (DoSceneChange());
	}

	void Update(){
		if (Input.GetButtonDown ("Fire1")) {
			buttonPressed = true;
		}
	}

	public IEnumerator DoSceneChange() {
		if (doFadeIn) {
			time = Time.time;
			while (Time.time < time + fadeTime) {
				float percentWave = (Time.time - time) / fadeTime;
				fadeRenderer.material.SetColor ("_TintColor", new Color (0, 0, 0, 1 - percentWave));
				yield return new WaitForEndOfFrame ();
			}
			fadeRenderer.material.SetColor ("_TintColor", new Color (0, 0, 0, 0));
		}

		if (waitForSpace) {
			buttonPressed = false;
			while (!buttonPressed) {
				yield return new WaitForEndOfFrame ();
			}
		} else {
			yield return new WaitForSeconds (waitTime);
		}

		if (doFadeOut) {
			time = Time.time;
			while (Time.time < time + fadeTime) {
				float percentWave = (Time.time - time) / fadeTime;
				fadeRenderer.material.SetColor ("_TintColor", new Color (0, 0, 0, percentWave));
				yield return new WaitForEndOfFrame ();
			}
		}

		SceneManager.LoadScene (nextScene);
	}
}
