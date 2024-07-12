using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] Transform targetDestination;
    //GameObject targetGameObject;
    //Character targetCharacter;
    //[SerializeField] float speed;

    //Rigidbody2D rgdbd2d;

    //[SerializeField] int hp = 999;
    //[SerializeField] int damage = 1;

    //private void Awake()
    //{
    //    rgdbd2d = GetComponent<Rigidbody2D>();
    //    targetGameObject = targetDestination.gameObject;
    //}

    //private void FixedUpdate()
    //{
    //    Vector3 direction = (targetDestination.position - transform.position).normalized;
    //    rgdbd2d.velocity = direction * speed;
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject == targetGameObject)
    //    {
    //        Attack();
    //    }
    //}

    //private void Attack()
    //{
    //    if (targetCharacter == null)
    //    {
    //        targetCharacter = targetGameObject.GetComponent<Character>();
    //    }

    //    targetCharacter.TakeDamage(damage);
    //}

    //public void TakeDamage(int damage)
    //{
    //    hp -= damage;
    //    if (hp < 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //Gets a reference to the player 
    [SerializeField]
    private Character target;

    //Variables for enemy stats
    //Remove serialize fields after switching to enemy spawning 
    [SerializeField]
    private float speed;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int damage;

    //Holds navmesh agent reference 
    private NavMeshAgent agent;

    //Variables for attacks  
    private bool canAttack = true;
    private bool targetInRange = false;
    [SerializeField]
    private float timeBetweenAttacks; 

    void Awake()
    {
        //Initializes the reference
        agent = GetComponent<NavMeshAgent>();

        //Delete this after implementing enemy spawning 
        agent.speed = speed;
    }

    void Update()
    {
        if(canAttack)
        {
            //Calls the GetTarget function repeatedly to move the navmesh in the target's direction 
            GetTarget(target.gameObject);

            //Checks if target is within range 
            if (targetInRange)
            {
                //If target is within range, attack the target
                Attack(target.gameObject);
            }
        }
    }

    //Initializes the enemy stats 
    //Switch to this after implementing enemy spawning
    public void SetStats(float speed, int hp, int damage)
    {
        agent.speed = speed;
        this.hp = hp;
        this.damage = damage;
    }

    //Controls the enemy movement 
    public void GetTarget(GameObject target)
    {
        agent.SetDestination(new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y, 0f)); 
    }

    //Trigger used to define enemy attack radius 
    void OnTriggerEnter2D(Collider2D collision)
    {
        targetInRange = true; 
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        targetInRange = false;
    }
    void Attack(GameObject objToDamage)
    {
        //Add in attack code here 
        //Ideally add a deal damage function in the player and call it here
        //Add in attack animations too 
        Debug.Log("Attacking target");
        StartCoroutine(AttackTimer());
    }
    //Timer to add in pauses between attacks
    IEnumerator AttackTimer()
    {
        Debug.Log("Timer started");
        canAttack = false;
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }
}
