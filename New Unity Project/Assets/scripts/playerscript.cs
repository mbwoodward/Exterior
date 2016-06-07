using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerscript : MonoBehaviour {

	public int playerHealth;

	public int ammoCount;

	public Image healthGUI;

	public Sprite[] health;

	public GameObject ammoText;

	public GameObject infoText;
    
    public float bulletSpeed = 600;

    public Rigidbody bullet;

    public Transform firePoint;

    public float maxForce;
    public float fireRate;
    float fireTime = 0.0f;

    public static bool canFire = false;

    void LoseHealth(int Amount)
    {

        playerHealth -= Amount;
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "hurtsphere") {
			if (playerHealth > 0) {
				playerHealth = playerHealth - 1;
				infoText.SendMessage ("ShowHints", "You have taken damage");
			}
		}
        if(other.tag == "chase")
        {
            if(playerHealth > 0)
            {
                playerHealth = playerHealth - 1;
                infoText.SendMessage("ShowHints", "You have taken damage");
            }
        }
        if (other.tag == "EnemyBullet")
        {
            if (playerHealth > 0)
            {
                playerHealth = playerHealth - 1;
                infoText.SendMessage("ShowHints", "You have taken damage");
            }
            Destroy(other.gameObject);


        }
        if (other.tag == "ammotemp") {
			if (ammoCount < 10) {
				ammoCount = ammoCount + 5;
				if (ammoCount > 10) {
					ammoCount = 10;
				}
				infoText.SendMessage ("ShowHints", "You have gained ammo");
			}

		}
		if (other.tag == "healthtemp") {
			if (playerHealth < 10) {
				playerHealth += 3;
				if (playerHealth > 10) {
					playerHealth = 10;
				}
				infoText.SendMessage ("ShowHints", "You have gained health");
			}
		}

	}

	// Use this for initialization
	void Start () {

		playerHealth = 10;
		ammoCount = 10;

		infoText.SendMessage ("ShowHints", "Left Mouse Click to expend ammo");
	
	}
	
	// Update is called once per frame
	void Update () {

		ammoText.GetComponent<Text> ().text = "" + ammoCount;

		healthGUI.sprite = health[playerHealth];


		if (Input.GetMouseButtonDown (0)) {
            //Debug.Log ("Pressed left click.");
            if ((Time.time > fireTime) && (ammoCount > 0))
            {

                //Debug.Log ("Player fires");

                Rigidbody tempBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Rigidbody;

                tempBullet.velocity = transform.forward * maxForce;

                fireTime = Time.time + fireRate;

                ammoCount--;

				infoText.SendMessage ("ShowHints", "ammo expended");
			}
		}
	
		if (transform.position.y > 25.0f) {
			transform.position = new Vector3 (transform.position.x, 25.0f, transform.position.z);
		}
	}
}
