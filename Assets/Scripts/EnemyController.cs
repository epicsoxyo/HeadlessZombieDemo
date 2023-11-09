using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    Animator animator;



    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        AnimateEnemy();
    }

    void AnimateEnemy()
    // sets speed param in enemy's animator; triggers idle/walking animation
    {
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

}