using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	public void GameOver (float light, float time) {

		PlayerPrefs.SetFloat ("light", light);
		PlayerPrefs.SetFloat ("time", time);

		SceneManager.LoadScene ("GameOver");
	}
}
