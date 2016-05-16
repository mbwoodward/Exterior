using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickupScript : MonoBehaviour {


	public string itemName;
	public AudioClip pickupSound;
	public GameObject infoText;
	public GameObject itemGUI;


	void OnTriggerEnter(Collider other){


		if(other.tag=="Player"){

			//Debug.Log ("Hit by Player");
			if(itemName == "key")
			{
				//GameObject.Find ("Platform").GetComponent<panelScript>().yellowKey = true;
				//AudioSource.PlayClipAtPoint(pickupSound, transform.position);
				itemGUI.SetActive (true);
				Destroy(gameObject);

			}

			if(itemName == "sky")
			{
				//AudioSource.PlayClipAtPoint(pickupSound, transform.position);
				itemGUI.SetActive (true);
				Destroy(gameObject);
				
			}
			if(itemName == "apple")
			{
				//AudioSource.PlayClipAtPoint(pickupSound, transform.position);
				itemGUI.SetActive (true);
				Destroy(gameObject);
				
			}

		}



	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
