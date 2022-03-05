using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingEnemyContoller : MonoBehaviour
{
    //Radius to look for player
	public float lookradius = 10f;

    //Target to follow and navmesh agent
    public Transform target;
    NavMeshAgent agent;

    //Animation vars
    public Animator m_Animator;
    private bool walkAnim;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        //sets the enmys target as the player
        //target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        //Set up anim vars
        lastPosition = transform.position;
        walkAnim = false;
    }

    // Update is called once per frame
    void Update()
    { //distance between player and enemy
        float distance = Vector3.Distance(target.position, transform.position);

        //Disable walking
        walkAnim = false;

        //if the distance is less than the look radius then the enemy will chase the player
        if (distance <= lookradius)
        {
            agent.SetDestination(target.position);
        }

        //Only walk if moving
        if (transform.position != lastPosition)
            walkAnim = true;
        else
            walkAnim = false;

        //Get last position
        lastPosition = transform.position;

        //Set walking anim
        if (walkAnim == false)
            m_Animator.SetBool("TrackingPlayer", false);

        if (walkAnim == true)
            m_Animator.SetBool("TrackingPlayer", true);

        // If within attacking distance
        //if (distance <= agent.stoppingDistance)
        //{
        //    CharacterStats targetStats = target.GetComponent<CharacterStats>();
        //    if (targetStats != null)
        //    {
        //        combat.Attack(targetStats);
        //    }
        { 
            FaceTarget();   // Make sure to face towards the target
        }
    }

    private void OnDrawGizmosSelected()
    {
        //shows the radius of what the enemy character can see
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }


    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
