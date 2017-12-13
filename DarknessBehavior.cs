using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessBehavior : MonoBehaviour {

	public float darknessAmount = 1f;
	public float lightLoss = 0.002f;

	public GameObject[] drainLightFrom;

	SpriteRenderer sprite;

	void Start () {

		sprite = this.gameObject.GetComponent<SpriteRenderer> ();

	}

	void UpdateSize() {

		transform.localScale = new Vector3 (darknessAmount, darknessAmount, darknessAmount);

		sprite.color = new Color (1f, 1f, 1f, darknessAmount);

		if (darknessAmount <= 0) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D col) {

		GameObject go = col.gameObject;

		foreach (GameObject gameObject in drainLightFrom) {

			if (go.tag == gameObject.tag) {

				Light light = go.GetComponentInChildren<Light> ();

				light.intensity = light.intensity - lightLoss;
				darknessAmount = darknessAmount - lightLoss;

				UpdateSize ();
			}
		}
	}
}
