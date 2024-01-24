using System.Collections.Generic;
using UnityEngine;

// controls behaviour of enemy detection cone
public class PlayerDetection : MonoBehaviour
{

    private Rigidbody rigidBody;
    private Renderer rend;
    private List<Collider> detectedPlayers = new List<Collider>();

    [SerializeField] private EnemyBodyController enemyBodyController;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;
    [SerializeField] private GameObject trackingBall;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = offMaterial;
    }

    private void FixedUpdate()
    {
        FindPlayers();
    }

    // gets location of first player in detected players list + updates body navmesh and trackerball
    private void FindPlayers()
    {
        if (detectedPlayers.Count != 0)
        {
            Vector3 playerPos = detectedPlayers[0].transform.position;

            enemyBodyController.UpdateLastSeenLocation(playerPos);

            trackingBall.transform.position = playerPos;
        }
    }

    private void OnTriggerEnter (Collider collider)
    {
        if (collider.CompareTag("Player") && !detectedPlayers.Contains(collider))
        {
            detectedPlayers.Add(collider);

            rend.sharedMaterial = onMaterial;
        }
    }

    private void OnTriggerExit (Collider collider)
    {
        if (collider.CompareTag("Player") && detectedPlayers.Contains(collider))
        {
            detectedPlayers.Remove(collider);

            if (detectedPlayers.Count == 0)
                rend.sharedMaterial = offMaterial;
        }
    }

}