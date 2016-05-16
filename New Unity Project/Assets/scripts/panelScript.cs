using UnityEngine;
using System.Collections;

public class panelScript : MonoBehaviour {


	public AudioClip caution, door, pickup;

	public bool doorOpened;

	public Animator mainAnim;

	public GameObject infoText, door1, door2, door3;

	public bool greenKey, yellowKey, blueKey, platform;

//	void OnTriggerEnter(Collider other){

//		if (other.tag == "Player" && doorOpened == false) {

			//Debug.Log ("hit by Player");
			//AudioSource.PlayClipAtPoint (caution, transform.position);
			//mainAnim.SetTrigger ("open");
			//AudioSource.PlayClipAtPoint (door, transform.position);
			//doorOpened = true;

//			infoText.SendMessage ("ShowHints", "Cannot operate...\n" +
//				"You need three keys to operate this platform...\n" +
//				"I have granted access to one door...");
			//yellowKey = true;

//		} else if (other.tag == "Player" && yellowKey == true && door1.GetComponent<doorScript> ().canBeOpened == false) {

			//door1.GetComponent<doorScript> ().canBeOpened = true;
			//AudioSource.PlayClipAtPoint (pickup, transform.position);
//			infoText.SendMessage ("ShowHints", "Cannot operate...\n" +
//				"One key found...\n" +
//				"I have granted access to another door...");


//		} else if (other.tag == "Player" && blueKey == true && door2.GetComponent<doorScript> ().canBeOpened == false) {
		
			//door2.GetComponent<doorScript> ().canBeOpened = true;
			//AudioSource.PlayClipAtPoint (pickup, transform.position);
//			infoText.SendMessage ("ShowHints", "Cannot operate...\n" +
//				"Two keys found...\n" +
//				"Another door is available...");
		
//		} else if (other.tag == "Player" && greenKey == true && door3.GetComponent<doorScript> ().canBeOpened == false) {
			
			//door3.GetComponent<doorScript> ().canBeOpened = true;
//			AudioSource.PlayClipAtPoint (pickup, transform.position);
//			infoText.SendMessage ("ShowHints", "Now Operational...\n" +
//									"All keys found...\n" +
//									"Proceeding...");
			//GetComponent<Animation> ().Play ();
			//GetComponent<BoxCollider> ().enabled = false;
//		}
//	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
