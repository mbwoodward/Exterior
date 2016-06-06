using UnityEngine;
using System.Collections;

public class garden : MonoBehaviour {

    public bool picked;

    void Start()
    {
        picked = false;
    }


    public GameObject infoText;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (picked == false)
            {
                infoText.SendMessage("ShowHints", "My goal is in there...I can't get it myself.");
            }
            else
            {
                infoText.SendMessage("ShowHints", "I got the apple, I need to escape.");
            }
        }
    }
}
