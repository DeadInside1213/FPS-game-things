using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] float chaseRadius = 10f;
    [SerializeField] float maxDistance = 50f;
    [SerializeField] float attackDistance = 5f;

    [SerializeField] private Vector3 originalPosition;
    [SerializeField] Animator animator;

    
    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // khoan cach tu vi tri hen tai den vi tri ban dau cua enemy
        var chasedDistance = Vector3.Distance(transform.position, originalPosition);
        
        // khoan cach tu player -> enemy
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance <= chaseRadius)
        {
            agent.SetDestination(target.position);
        }

        if (distance <= attackDistance && isAttacking == false)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            agent.isStopped = true;
        }
        
        // khoan cach giua player va enemy qua xa

        
        if (chasedDistance <= chaseRadius && distance >= maxDistance)
        {
            agent.SetDestination(originalPosition);
        }

        if (distance > chaseRadius || chasedDistance > maxDistance)
        {
            agent.SetDestination(originalPosition);
        }
        
        
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);  
        Debug.Log(speed);
    }


    public void EndAttack()
    {
        animator.SetTrigger("EndAttack");
        isAttacking = false;
        agent.isStopped = false;
    }
}
