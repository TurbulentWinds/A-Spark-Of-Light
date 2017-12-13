using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour {

	public GameObject[] destroyOnTouch;

	public GameObject player;
	Light light;

	Transform transform;

	float wallSpeed = 0.01f;

	void Start () {
		light = player.GetComponentInChildren<Light> ();
		transform = this.gameObject.transform;
	}

	void FixedUpdate () {

		float xChange = wallSpeed / light.intensity;

		if (light.intensity > 1) {
			this.transform.localScale += new Vector3 (xChange, 0, 0);
		} else if (this.transform.localScale.x > 3) {
			this.transform.localScale -= new Vector3 (xChange, 0, 0);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {

		GameObject go = col.gameObject;

		foreach (GameObject gameObject in destroyOnTouch) {

			if (go.CompareTag (gameObject.tag)) {
				Destroy (go);
			}
		}
	}
}
