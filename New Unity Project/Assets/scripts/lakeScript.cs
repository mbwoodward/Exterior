using UnityEngine;
using System.Collections;

public class lakeScript : MonoBehaviour {

    public GameObject infoText;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            infoText.SendMessage("ShowHints", "Now's not the time for swimming..");
        }
    }
}
