using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour {

	public float intensity = 2f;

	Light light;

	SpriteRenderer sprite;

	void Start () {
		light = this.gameObject.GetComponentInChildren<Light> ();
		light.intensity = intensity;

		sprite = this.gameObject.GetComponent<SpriteRenderer> ();

		UpdateSize ();
	}

	void FixedUpdate () {
		UpdateSize ();
	}

	void UpdateSize() {

		float newLight = light.intensity / 2;

		transform.localScale = new Vector3 (newLight, newLight, newLight);

		if(light.intensity < 1) {
			sprite.color = new Color (1f, 1f, 1f, light.intensity);
		}

		if (light.intensity <= 0) {
			Destroy (this.gameObject);
		}
	}
}
