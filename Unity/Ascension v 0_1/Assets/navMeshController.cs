using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class navMeshController : MonoBehaviour
{
    private Animator anim;
    public Transform target; //Empty que seguira nuestro objetivo
    private NavMeshAgent agente;
    

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        agente.destination = target.position;
    }
}
