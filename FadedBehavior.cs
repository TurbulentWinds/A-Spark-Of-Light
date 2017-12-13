using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadedBehavior : MonoBehaviour {

	public float speed;
	public float pulseSpeed;
	public float pulseUpperAlpha;

	bool fade;

	SpriteRenderer sprite;
	Rigidbody2D rb2d;

	void Start () {

		//speed = Random.Range (0.5f, 3f);

		sprite = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D> ();

		Vector2 movement = new Vector2 (Random.Range(-1f,1f), Random.Range(-1f,1f));
		rb2d.AddForce (movement * speed);

		sprite.color = new Color (1f, 1f, 1f, 0f);

	}

	void Update () {

		if (sprite.color.a < pulseUpperAlpha && !fade) {
			sprite.color = new Color (1f, 1f, 1f, sprite.color.a + pulseSpeed);

			Debug.Log ("Increasing Color: " + sprite.color);

			if (sprite.color.a > pulseUpperAlpha)
				fade = true;
		} else {
			sprite.color = new Color (1f, 1f, 1f, sprite.color.a - pulseSpeed);

			Debug.Log ("Decreasing Color: " + sprite.color);

			if (sprite.color.a <= 0)
				fade = false;
		}
	}
}
