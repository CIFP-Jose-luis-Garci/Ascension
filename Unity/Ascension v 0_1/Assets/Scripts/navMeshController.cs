using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class navMeshController : MonoBehaviour
{
    public Animator animator;
    private Animation anim;
    public Transform target; //Empty que seguira nuestro objetivo
    private NavMeshAgent agente;
    public GameObject target2;
    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
    private float viewAngle;
    public Transform player;
    Color originalSpotlightColour;

    // Start is called before the first frame update
    void Start()
    {
        originalSpotlightColour = spotlight.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        target2 = GameObject.Find("Setdestination");

        agente = GetComponent<NavMeshAgent>();
        anim = target2.GetComponent<Animation>();
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position,player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if(!Physics.Linecast(transform.position,player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer())
        {
            spotlight.color = Color.red;
            anim.enabled = false;
            target = player.transform;
            animator.SetBool("Correr", true);
        }
        else
        {
            spotlight.color = originalSpotlightColour;
            Invoke("NotSee", 3.0f);
        }
        agente.destination = target.position;
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
    void NotSee()
    {
        anim.enabled = true;
        target = target2.transform;
        animator.SetBool("Correr", false);
    }
}
