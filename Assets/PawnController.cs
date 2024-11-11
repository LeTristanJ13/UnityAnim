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
    float IdleTimeRef;
    float RunTimeRef;
    Rigidbody rb;
    // D�lai de saut, ici fix� � 1 seconde
    private float jumpCooldown = 1f;
    private float jumpTimer = 0f;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        agent.speed = 5;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calcul de la vitesse et mise � jour de l'animation
        SpeedRef = agent.velocity.magnitude;
        if (animator != null)
        {
            animator.SetFloat("Speed", SpeedRef);
        }

        // Si le personnage est immobile (vitesse <= 0.1), incr�menter le temps d'inactivit�
        if (SpeedRef <= 0.5f)
        {
            IdleTimeRef += Time.deltaTime;  // Incr�menter IdleTimeRef si le personnage est immobile

            // Mettre � jour l'animation avec le temps d'inactivit�
            if (animator != null)
            {
                animator.SetFloat("IdleTime", IdleTimeRef);
            }

            // R�initialiser RunTimeRef si le personnage est � l'arr�t
            RunTimeRef = 0f;
        }
        else
        {
            // Si le personnage est en mouvement, incr�menter le temps de course
            RunTimeRef += Time.deltaTime;

            // Si 1 seconde �coul�e et le personnage est en mouvement, effectuer le saut
            if (RunTimeRef >= 1f)
            {
                Debug.Log("Jump est appel�");
                Jump();  // Effectuer le saut
                RunTimeRef = 0f;  // R�initialiser le chronom�tre apr�s le saut
            }
        }
    }

    // Fonction Jump : Effectuer le saut
    void Jump()
    {
        if (rb != null)
        {
            // Appliquer une force pour le saut
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

            // D�clencher l'animation de saut en activant le trigger "Jump"
            if (animator != null)
            {
                animator.SetTrigger("Jump");  // L'animation de saut commence ici
            }
        }
    }
}