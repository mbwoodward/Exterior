using UnityEngine;
using System.Collections;

public class gatebarrier : MonoBehaviour {

	public bool open;

	void Start()
	{
		open = false;
	}


	public GameObject infoText;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (open == false)
			{
				infoText.SendMessage("ShowHints", "There seems to be a magic barrier, it looks like I need to find a key of some sort...");
			}
			else
			{
				GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}
}
