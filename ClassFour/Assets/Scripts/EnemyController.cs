using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    public float countlife;
    public bool life = true;
    private StateGame stateGame = new StateGame();
    private GameObject Healthbar;
    LifeBar lifeBar;
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Healthbar = GameObject.FindGameObjectWithTag("Lifebar");
        this.lifeBar.SetHealth(this.countlife);
        this.lifeBar.UpdateHealth(this.countlife);
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        Debug.Log("Distance to player: " + enemyAgent.remainingDistance);
        enemyAnimator.SetFloat("Speed",enemyAgent.speed);
        enemyAnimator.SetBool("Vidas", true);

        if (enemyAgent.remainingDistance <= 1f && enemyAgent.hasPath)
        {
            enemyAnimator.SetFloat("Speed", 0f);
            enemyAnimator.SetBool("Punch", true);
        } ///Distancia al destino

        else
            enemyAnimator.SetFloat("Speed", enemyAgent.speed);
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            countlife -= 1;
            this.Damage(1f);          
        }
    }

    public void Damage(float damage)
    {
        this.countlife -= damage;
        if (countlife <= 0f)
        {
            Destroy(this.gameObject);
            stateGame.EnemyCounter();
        }
        this.lifeBar.UpdateHealth(this.countlife);
    }
}
