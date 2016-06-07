using UnityEngine;
using System.Collections;


public class turret : MonoBehaviour
{

	Transform playerPos;
	string state = "patrol";
    public float attackDistance;
	float playerDistance;
    public Rigidbody bullet;
    public Transform firePoint;
    public float fireRate;
    public float maxForce;
    private float fireTime = 0.0f;
    public float turretHealth, minHealth, maxHealth;
    public Texture calm, enraged;
	public Animator myAnimator;
	public GameObject mesh;

	IEnumerator wait()
	{
		yield return new WaitForSeconds (1.50f);
		Rigidbody tempBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Rigidbody;
		tempBullet.velocity = transform.forward * maxForce;
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {

            turretHealth--;

            Destroy(other.gameObject);

        }

    }

    // Use this for initialization
    void Start()
    {
        mesh.GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;

        turretHealth = Random.Range(minHealth, maxHealth);

		playerPos = GameObject.FindWithTag ("Player").transform;

		myAnimator = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update()
    {

        playerDistance = Vector3.Distance(playerPos.position, transform.position);

		if(state == "patrol")
		{
			myAnimator.Play("Idle");
			if (playerDistance <= attackDistance) {

				state = "attack";

				mesh.GetComponent<SkinnedMeshRenderer> ().material.mainTexture = enraged;
				//GetComponent<SmoothLookAt>().enabled = true;


			}
					
			}else if(state == "attack")
			{
            //GetComponent<SmoothLookAt>().enabled = false;
			if (playerDistance > attackDistance)
			{
				mesh.GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;
				state = "patrol";

			}
			if (Time.time > fireTime) {

				transform.LookAt (playerPos);

				myAnimator.Play ("turret");

				StartCoroutine (wait ());

				fireTime = Time.time + fireRate;


			}
			}

        if (turretHealth <= 0.0f)
        {

            Destroy(gameObject);

        }

    }
}

