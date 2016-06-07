using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {

	IEnumerator wait()
	{
		yield return new WaitForSeconds (4.0f);
		Destroy (gameObject);
	}

	void Update()
	{
		StartCoroutine (wait ());
	}
}
