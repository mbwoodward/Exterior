using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class infoTextScript : MonoBehaviour {


	public float timer = 0.0f;

	void ShowHints (string message){

		timer = 0.0f;
		GetComponent<Text> ().text = message;
		GetComponent<Text> ().enabled = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Text> ().enabled == true) {
	
			timer += Time.deltaTime;

			if (timer > 2.0f) {
				GetComponent<Text> ().enabled = false;
				timer = 0.0f;
			}
		}
	}
}
