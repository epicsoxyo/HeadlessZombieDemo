using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetection : MonoBehaviour
{

    // VARS

    private Rigidbody rigidBody;
    private List<Collider> players = new List<Collider>();
    Renderer rend;
    NavMeshAgent navMeshAgent;

    [SerializeField] private GameObject enemyBody;
    [SerializeField] private Material[] materials = new Material[1];
    [SerializeField] private GameObject trackingBall;



    // CALLBACKS

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];

        navMeshAgent = enemyBody.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        UpdateColour();
    }

    void FixedUpdate()
    {
        FindPlayers();
    }

    private void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !players.Contains(collider))
            players.Add(collider);
    }

    private void OnTriggerExit (Collider collider)
    {
        players.Remove(collider);
    }



    // FUNCTIONS/PROCEDURES

    private void UpdateColour()
    {
        if (players.Count == 0)
            rend.sharedMaterial = materials[1];
        else
            rend.sharedMaterial = materials[0];
    }

    private void FindPlayers()
    {
        if (players.Count != 0)
        {
            Vector3 playerPos = players[0].transform.position;

            navMeshAgent.SetDestination(playerPos);

            trackingBall.transform.position = playerPos;
        }
    }

}