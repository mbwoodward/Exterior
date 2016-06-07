using UnityEngine;
using System.Collections;

public class gateScript : MonoBehaviour {

	public Animator myAnimator;
	public GameObject barrier, barrier2;

	IEnumerator wait()
	{
		

		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
		Destroy (barrier);
		Destroy (barrier2);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{

			myAnimator.Play ("gate");
			StartCoroutine (wait ());

		}
	}

	// Use this for initialization
	void Start () {
		
		myAnimator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
