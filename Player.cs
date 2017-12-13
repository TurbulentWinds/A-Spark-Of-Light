using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

	public GameObject textObject;

	SceneManagement sceneManager;

	TextMeshProUGUI text;

	Light light;

	SpriteRenderer sprite;

	bool touchingLeftWall;
	bool touchingRightWall;

	float timer = 0;

	void Start () {
		sceneManager = FindObjectOfType<SceneManagement> ();
		text = textObject.GetComponent<TextMeshProUGUI> ();

		sprite = this.gameObject.GetComponent<SpriteRenderer> ();
		light = this.gameObject.GetComponentInChildren<Light> ();
	}

	void Update () {

		timer = timer + Time.deltaTime;

		if (light.intensity < 1) {
			sprite.color = new Color (1f, 1f, 1f, light.intensity);
		} else {
			sprite.color = new Color (1f, 1f, 1f, 1f);
		}

		if (touchingLeftWall && touchingRightWall) {
			sceneManager.GameOver (light.intensity, timer);
		}

		if (light.intensity <= 0) {
			sceneManager.GameOver (light.intensity, timer);
		}

		text.SetText ("LIGHT: {0:2}", light.intensity);
	}

	void OnCollisionEnter2D (Collision2D col) {

		GameObject go = col.gameObject;

		if (go.CompareTag("Light")) {

			Light goLight = go.GetComponentInChildren<Light> ();

			light.intensity = light.intensity + goLight.intensity;
			Destroy (go);
		}

		if (go.CompareTag("LeftWall")) {
			touchingLeftWall = true;
		}

		if (go.CompareTag("RightWall")) {
			touchingRightWall = true;
		}
	}

	void OnCollisionExit2D (Collision2D col) {

		GameObject go = col.gameObject;

		if (go.CompareTag("LeftWall")) {
			touchingLeftWall = false;
		}

		if (go.CompareTag("RightWall")) {
			touchingRightWall = false;
		}
	}
}
