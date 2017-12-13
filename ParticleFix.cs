using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFix : MonoBehaviour {

	SpriteRenderer parent;
	ParticleSystem.MainModule settings;

	void Start () {
		settings = GetComponent<ParticleSystem> ().main;
		parent = transform.parent.GetComponent<SpriteRenderer> ();
	}

	void Update () {
		settings.startColor = new ParticleSystem.MinMaxGradient (parent.color);
	}
}
