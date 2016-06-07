using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour
{
    NavMeshAgent agent;
    string state = "patrol";
    public GameObject[] patrolPoints;
    int currentPoint = 0;
    Transform playerPos; //the enemy's target
    public float moveSpeed; //move speed
    public float rotationSpeed; //speed of turning
    public float chaseDistance, attackDistance;
    float playerDistance;
    public float attackRate;
    float attackTime = 0.0f;
    public float chaseHealth, minHealth, maxHealth;
    public Texture calm, enraged;
    public Animator myAnimator;
	public GameObject mesh;



	IEnumerator wait()
	{
		myAnimator.Play("chase");
		yield return new WaitForSeconds(1.5f);
		GameObject.FindWithTag("Player").SendMessage("LoseHealth", 1);
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {

            chaseHealth--;

            Destroy(other.gameObject);

        }

    }

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        agent.destination = patrolPoints[currentPoint].transform.position;

        playerPos = GameObject.FindWithTag("Player").transform;

        myAnimator = GetComponent<Animator>();

        mesh.GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;

        chaseHealth = Random.Range(minHealth, maxHealth);

    }

    void Update()
    {

        playerDistance = Vector3.Distance(transform.position, playerPos.position);

        if (state == "patrol")
        {

			myAnimator.Play("Idle");
            if (playerDistance <= chaseDistance)
            {


                state = "chase";

                agent.destination = playerPos.position;

                agent.speed = 4;

				mesh.GetComponent<SkinnedMeshRenderer>().material.mainTexture = enraged;
                //GetComponent<SmoothLookAt>().enabled = true;

            }
            if (agent.remainingDistance < .01)
            {

                if (currentPoint < (patrolPoints.Length - 1))
                {

                    currentPoint++;

                }
                else {

                    currentPoint = 0;

                }

                agent.destination = patrolPoints[currentPoint].transform.position;
            }
        } else if (state == "chase")
        {

            agent.destination = playerPos.position;

            if (playerDistance > chaseDistance)
            {

                state = "patrol";

                agent.Stop();
                mesh.GetComponent<SkinnedMeshRenderer>().material.mainTexture = calm;
                agent.destination = patrolPoints[currentPoint].transform.position;
                agent.Resume();
                agent.speed = 2;

            }

            if (playerDistance < attackDistance)
            {

                state = "attack";

                agent.Stop();



            }
        }
        else if (state == "attack")
        {

            if (playerDistance > attackDistance)
            {

                state = "chase";

                agent.speed = 4;

                agent.Resume();


            }

            if (Time.time > attackTime)
            {				
				StartCoroutine (wait());      
                attackTime = Time.time + attackRate;
            }

        }

            if (chaseHealth <= 0.0f)
            {
                Destroy(gameObject);
            }
    }
}