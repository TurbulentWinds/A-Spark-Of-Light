using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip[] music;
	AudioSource source;

	public static AudioManager instance;

	void Awake () {

		if (instance == null)
			instance = this;
		else {
			Destroy (this.gameObject);
			return;
		}

		DontDestroyOnLoad (this.gameObject);

		source = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (!source.isPlaying) {
			source.clip = music[Random.Range(0, music.Length)]; 
			source.Play ();
		}
	}
}
