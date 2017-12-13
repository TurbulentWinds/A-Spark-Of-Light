using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScores : MonoBehaviour {

	public GameObject text;
	TextMeshProUGUI textMesh;

	void Start () {

		textMesh = text.GetComponent<TextMeshProUGUI> ();
		textMesh.SetText ("LIGHT AT DEATH: {0:2}\nTIME SURVIVED: {1:2}", PlayerPrefs.GetFloat("light"), PlayerPrefs.GetFloat("time"));
	}
}
