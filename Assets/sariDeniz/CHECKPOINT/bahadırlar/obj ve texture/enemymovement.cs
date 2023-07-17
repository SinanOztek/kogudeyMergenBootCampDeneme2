using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement: MonoBehaviour
{
    private NavMeshAgent enemy;
    [SerializeField] LayerMask groundLayer, playerLayer;
    public GameObject player;
    Vector3 destPoint;
    bool walkpointSet ;
    [SerializeField] float range;
    // chase
    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;
    //attack
    Animator animator;
    int health = 100;
    private GameManager gameManager;



    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        gameManager = FindObjectOfType <GameManager>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSight && !playerInAttackRange) patrol();
        if (playerInSight && !playerInAttackRange) chase();
        if (playerInSight && playerInAttackRange) Attack();
    }

    void chase() 
    {
        enemy.SetDestination(player.transform.position);

    }
    void Attack() 
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("bahadýrAtack")) 
        { 
            animator.SetTrigger("Attack");
            enemy.SetDestination(transform.position);

        }
        

    }

    public void TakeDamage(int damage)
    {
        
        
            health -= damage;
            animator.SetTrigger("isHit");
            Debug.Log("Damage Taken!");
            if (health <= 0)
            {
                Die();
            
            }
        
    }

     void Die() 
    {
        enemy.isStopped = true;
        animator.SetTrigger("dead");
        gameManager.RemoveEnemy(this);

        
        
    }

    void patrol() 
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) enemy.SetDestination(destPoint);
        if(Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false ;
    }
    void SearchForDest() 
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        { 
            walkpointSet = true ;
        }
    }
}
