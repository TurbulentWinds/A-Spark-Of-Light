using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBehavior : MonoBehaviour {

	public float speed;

	public float darknessAmount = 1f;
	public float lightLoss = 0.002f;

	public GameObject[] drainLightFrom;
	public GameObject player;

	float scale = 4f;

	void Start () {
		UpdateSize ();
	}

	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
	}

	void OnTriggerStay2D (Collider2D col) {

		GameObject go = col.gameObject;

		foreach (GameObject gameObject in drainLightFrom) {

			if (go.tag == gameObject.tag) {

				Light light = go.GetComponentInChildren<Light> ();

				light.intensity = light.intensity - lightLoss;
				darknessAmount = darknessAmount + lightLoss;

				Debug.Log ("Darkness: " + darknessAmount);

				UpdateSize ();
			}
		}
	}

	void UpdateSize() {
		transform.localScale = new Vector3 (darknessAmount/(4*scale), darknessAmount/(4*scale), darknessAmount/(4*scale)); 
		Debug.Log ("Scale: " + transform.localScale);
	}
}
