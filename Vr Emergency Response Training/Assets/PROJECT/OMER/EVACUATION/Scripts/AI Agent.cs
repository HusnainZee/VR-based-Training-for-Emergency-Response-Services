using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    [SerializeField] Transform InjuredPosition;
    private NavMeshAgent agentRef;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        agentRef = GetComponent<NavMeshAgent>();
    }

    public void RunToInjured()
    {
        agentRef.SetDestination(InjuredPosition.position);
        anim.SetTrigger("Run");
    }

    void Crouch()
    {
        //agentRef.baseOffset = -0.5f;
        anim.SetTrigger("Crouch");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Injured"))
        {
            
            Crouch();
        }
    }



}
