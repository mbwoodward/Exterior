using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class exitgate : MonoBehaviour {

	public bool win;
	public string LeveltoLoad;

	void Start()
	{
		win = false;
	}


	public GameObject infoText;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (win == false)
			{
				infoText.SendMessage("ShowHints", "I can't leave without the apple");
			}
			else
			{
				SceneManager.LoadScene (LeveltoLoad);
			}
		}
	}
}
