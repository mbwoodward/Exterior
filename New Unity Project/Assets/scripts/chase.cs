using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour
{

    public Transform target; //the enemy's target
    public float moveSpeed; //move speed
    public float rotationSpeed; //speed of turning
    public float attackDistance;
    public float chaseHealth, minHealth, maxHealth;
    public Texture calm, enraged;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {

            chaseHealth--;

            Destroy(other.gameObject);

        }

    }


    Transform myTransform; //current transform data of this enemy


    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }


    void Start()
    {
        GameObject.FindWithTag("mesh2").GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;

        chaseHealth = Random.Range(minHealth, maxHealth);

    }

    void Update()
    {

        float dist = Vector3.Distance(target.position, transform.position);

        if (dist <= attackDistance)
        {
            //rotate to look at the player
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);


            //move towards the player
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

            GameObject.FindWithTag("mesh2").GetComponent<SkinnedMeshRenderer>().material.mainTexture = enraged;
            //GetComponent<SmoothLookAt>().enabled = true;

        }
        else {

            GameObject.FindWithTag("mesh2").GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;
            //GetComponent<SmoothLookAt>().enabled = false;
        }

        if (chaseHealth <= 0.0f)
        {

            Destroy(gameObject);

        }
    }
}