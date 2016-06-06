using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playagain : MonoBehaviour {

	public string LeveltoLoad;

	public void OnClick()
	{
		SceneManager.LoadScene (LeveltoLoad);
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
