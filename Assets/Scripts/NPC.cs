using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour
{
    NavMeshAgent agente;
    public Transform target;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agente.destination = target.position;
    }
}
