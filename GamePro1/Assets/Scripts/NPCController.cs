using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public bool reached = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        InvokeRepeating("AiDestination", 0.5f, 0.5f);
    }

    void AiDestination()
    {
        agent.SetDestination(target.transform.position);
    }
}

