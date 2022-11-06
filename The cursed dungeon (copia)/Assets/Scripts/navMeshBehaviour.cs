using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class navMeshBehaviour : MonoBehaviour
{
    private NavMeshAgent agente;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }


}
