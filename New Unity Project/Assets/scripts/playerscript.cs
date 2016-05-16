using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerscript : MonoBehaviour {

	public int playerHealth;

	public int ammoCount;

	public GameObject healthGUI;

	public GameObject ammoText;

	public GameObject infoText;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "hurtsphere") {
			playerHealth = playerHealth - 10;
			//healthGUI.GetComponent<Rect> ().width -= 10;
		}
		if (other.tag == "ammotemp") {
			ammoCount = ammoCount + 5;
			if (ammoCount > 10) {
				ammoCount = 10;
			}
		}

	}

	// Use this for initialization
	void Start () {

		playerHealth = 100;
		ammoCount = 10;
	
	}
	
	// Update is called once per frame
	void Update () {

		ammoText.GetComponent<Text> ().text = "" + ammoCount;


		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
			if (ammoCount > 0) {
				ammoCount--;
			}
		}
	
	}
}
