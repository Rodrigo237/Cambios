using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    public float lifeEnemy;
    public float currentHealth;
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
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        Debug.Log("Distance to player: " + enemyAgent.remainingDistance);
        enemyAnimator.SetFloat("Speed",enemyAgent.speed);
        

        if (enemyAgent.remainingDistance <= 1f && enemyAgent.hasPath)
        {
            enemyAnimator.SetFloat("Speed", 0f);
            enemyAnimator.SetBool("Punch", true);
        } ///Distancia al destino

        else
            enemyAnimator.SetFloat("Speed", enemyAgent.speed);


        if (lifeEnemy != 0)
        {
            enemyAnimator.SetBool("Vidas", false);
            Destroy(transform.parent.gameObject);
            stateGame.EnemyCounter();
        }
        else
            enemyAnimator.SetBool("Vidas", true);
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            this.Damage(1f);        
        }
    }

    public void Damage(float damage)
    {
        if(currentHealth>0)
            currentHealth -= damage;       
    }
}
