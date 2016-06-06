using UnityEngine;
using System.Collections;


public class turret : MonoBehaviour
{

    public Transform myTarget;
    public float attackDistance;
    public Rigidbody bullet;
    public Transform firePoint;
    public float fireRate;
    public float maxForce;
    private float fireTime = 0.0f;
    public float turretHealth, minHealth, maxHealth;
    public Texture calm, enraged;

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
        GameObject.FindWithTag("mesh").GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;

        turretHealth = Random.Range(minHealth, maxHealth);

        myTarget = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(myTarget.position, transform.position);

        if (dist <= attackDistance)
        {
            GameObject.FindWithTag("mesh").GetComponent<SkinnedMeshRenderer>().material.mainTexture = enraged;
            //GetComponent<SmoothLookAt>().enabled = true;

            if (Time.time > fireTime)
            {

                transform.LookAt(myTarget);



                Rigidbody temBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Rigidbody;

                temBullet.velocity = transform.forward * maxForce;

                fireTime = Time.time + fireRate;


            }

        }
        else {

            GameObject.FindWithTag("mesh").GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;
            //GetComponent<SmoothLookAt>().enabled = false;
        }

        if (turretHealth <= 0.0f)
        {

            Destroy(gameObject);

        }

    }
}

