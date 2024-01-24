using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// controls player movement
public class PlayerController : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    [SerializeField] private float speed = 0.05f; // player's walking speed
    [SerializeField] private SceneScript sceneScript; // to call player death

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatePlayer();
    }
    
    // sets speed param in player's animator; triggers idle/walking animation
    private void AnimatePlayer()
    {
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // moves player based on user input
    private void MovePlayer()
    {
        Vector2 input = new Vector2
        (
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        if (input.magnitude >= 0.01f)
            MoveRelativeToCamera(input);
    }

    // converts player input to coords relative to current active camera
    private void MoveRelativeToCamera(Vector2 input)
    {
        // get relative axes
        Vector3 relativeX = Camera.main.transform.right;
        Vector3 relativeY = Camera.main.transform.forward;

        // remove vertical component + renormalize position vectors
        relativeX.y = 0;
        relativeY.y = 0;
        relativeX = relativeX.normalized;
        relativeY = relativeY.normalized;

        // get relative input
        Vector3 relativeInputX = relativeX * input.x * speed;
        Vector3 relativeInputY = relativeY * input.y * speed;
        Vector3 relativeMovement = relativeInputX + relativeInputY;

        // set player position in navmesh
        Vector3 destination = transform.position + relativeMovement;
        navMeshAgent.SetDestination(destination);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
            sceneScript.DoDeath();
    }

}