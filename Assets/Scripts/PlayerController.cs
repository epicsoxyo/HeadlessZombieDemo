using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // MOVEMENT VARS
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float speed = 0.05f; // player's walking speed

    // ANIMATION VARS
    private Animator animator;

    // DEATH VARS
    private Scene demoScene; // scene to reload upon death
    [SerializeField] private TextMeshProUGUI deathScreen;
    private GameObject[] enemies; // list of all enemies to freeze upon player death



    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }



    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        demoScene = SceneManager.GetActiveScene();
        deathScreen.canvasRenderer.SetAlpha(0);
    }



    void Update()
    {
        AnimatePlayer();
    }
    
    void AnimatePlayer()
    // uses player input to switch between idle/walking states in animator
    {
        Vector2 input = new Vector2
        (
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        animator.SetFloat("Speed", Mathf.Abs(input.magnitude));
    }



    void FixedUpdate()
    {
        Move();
    }

    void Move()
    // moves player based on user input
    {
        Vector2 input = new Vector2
        (
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        if (input.magnitude >= 0.01f)
            MoveRelativeToCam(input);
    }

    void MoveRelativeToCam(Vector2 input)
    // converts player input to coords relative to current active camera
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



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
            DoDeath();
    }

    void DoDeath()
    // stops player + enemies, fades in death screen and restarts level
    {
        FreezePlayer();

        FreezeAllEnemies();

        deathScreen.CrossFadeAlpha(1, 0.2f, false);

        StartCoroutine(RestartLevel());
    }

    private void FreezePlayer()
    // freezes player movement
    {
        navMeshAgent.isStopped = true;
        animator.speed = 0;
    }

    void FreezeAllEnemies()
    // freezes all enemies' movement
    {
        foreach (GameObject enemy in enemies)
        {
            NavMeshAgent enemyAgent = enemy.GetComponent<NavMeshAgent>();
            enemyAgent.isStopped = true;

            Animator enemyAnimator = enemy.GetComponent<Animator>();
            enemyAnimator.speed = 0;
        }
    }

    IEnumerator RestartLevel()
    // restarts the level after one second
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(demoScene.name);
    }

}