using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "turret")
        {
            Destroy(gameObject);
        }

        if (other.collider.tag == "terrain")
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
