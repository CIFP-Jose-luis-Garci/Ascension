using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class navMeshController1 : MonoBehaviour
{
    public Animator animator;
    private Animation anim;
    public Transform target; //Empty que seguira nuestro objetivo
    public NavMeshAgent agente;
    public GameObject target2;
    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
    private float viewAngle;
    public Transform player;
    Color originalSpotlightColour;
    public Slider slider;
    public Canvas tehanpillado;
    float progreso;
    public GameObject eventSystem;


    // Start is called before the first frame update
    void Start()
    {
        originalSpotlightColour = spotlight.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        //target2 = GameObject.Find("SetdestinationGuard2");
        eventSystem.SetActive(false);
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
        
        agente.destination = target.position;
        if (CanSeePlayer())
        {
            
                
            spotlight.color = Color.red;
            anim.enabled = false;
            target = player.transform;
            animator.SetBool("Correr", true);
            for (float n = 0.6f; n < 1f; n++)
            {
                slider.value = progreso;
                progreso += n * Time.deltaTime;
                if (progreso > 0.99)
                {
                    tehanpillado.enabled = true;
                    //Time.timeScale = 0f; Para parar el juego, falta ver si funciona el canvas con este codigo
                }
            }

        }
        else
        {
           
            spotlight.color = originalSpotlightColour;
           Invoke("NotSee", 3.0f);
            

        }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            slider.value = 1f;
            tehanpillado.enabled = true;
            eventSystem.SetActive(true);


            Time.timeScale = 0;
        }
        
    }
}
