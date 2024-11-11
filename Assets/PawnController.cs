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
    // Délai de saut, ici fixé à 1 seconde
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
        // Calcul de la vitesse et mise à jour de l'animation
        SpeedRef = agent.velocity.magnitude;
        if (animator != null)
        {
            animator.SetFloat("Speed", SpeedRef);
        }

        // Si le personnage est immobile (vitesse <= 0.1), incrémenter le temps d'inactivité
        if (SpeedRef <= 0.5f)
        {
            IdleTimeRef += Time.deltaTime;  // Incrémenter IdleTimeRef si le personnage est immobile

            // Mettre à jour l'animation avec le temps d'inactivité
            if (animator != null)
            {
                animator.SetFloat("IdleTime", IdleTimeRef);
            }

            // Réinitialiser RunTimeRef si le personnage est à l'arrêt
            RunTimeRef = 0f;
        }
        else
        {
            // Si le personnage est en mouvement, incrémenter le temps de course
            RunTimeRef += Time.deltaTime;

            // Si 1 seconde écoulée et le personnage est en mouvement, effectuer le saut
            if (RunTimeRef >= 1f)
            {
                Debug.Log("Jump est appelé");
                Jump();  // Effectuer le saut
                RunTimeRef = 0f;  // Réinitialiser le chronomètre après le saut
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

            // Déclencher l'animation de saut en activant le trigger "Jump"
            if (animator != null)
            {
                animator.SetTrigger("Jump");  // L'animation de saut commence ici
            }
        }
    }
}