using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

// contains scene routines (e.g. a small cutscene for player death)
public class SceneScript : MonoBehaviour
{

    private GameObject[] enemies;
    private GameObject[] players;
    private Scene demoScene;
    [SerializeField] private TextMeshProUGUI deathScreen;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        players = GameObject.FindGameObjectsWithTag("Player");

        demoScene = SceneManager.GetActiveScene();

        deathScreen.canvasRenderer.SetAlpha(0);
    }

    // stops player + enemies, fades in death screen and restarts level
    public void DoDeath()
    {
        FreezeAllCharacters();

        deathScreen.CrossFadeAlpha(1, 0.2f, false);

        StartCoroutine(RestartLevel());
    }

    void FreezeAllCharacters()
    {
        foreach (GameObject enemy in enemies)
        {
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.isStopped = true;

            Animator anim = enemy.GetComponent<Animator>();
            anim.speed = 0;
        }

        foreach(GameObject player in players)
        {
            NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
            agent.isStopped = true;

            Animator anim = player.GetComponent<Animator>();
            anim.speed = 0;
        }
    }

    // restarts the level after one second
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(demoScene.name);
    }

}
