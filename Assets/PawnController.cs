using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Personnage : MonoBehaviour
{
    [SerializeField] GameObject target;

    NavMeshAgent agent;
    Animator animator;
    float SpeedRef;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        agent.speed=5;
        animator = GetComponent<Animator>();
    }
     void Update()
    {   if(animator != null)
        {
            SpeedRef= agent.velocity.magnitude;
            animator.SetFloat("Speed", SpeedRef);
        }
    
            
    }
}


   
