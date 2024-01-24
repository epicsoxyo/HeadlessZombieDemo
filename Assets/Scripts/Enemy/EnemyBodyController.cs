using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// controls enemy movement
public class EnemyBodyController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateEnemy();
    }

    // sets speed param in enemy's animator; triggers idle/walking animation
    private void AnimateEnemy()
    {
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    // updates the navmesh destination to match the last seen location of the player
    public void UpdateLastSeenLocation(Vector3 playerPos)
    {
        navMeshAgent.SetDestination(playerPos);
    }

}