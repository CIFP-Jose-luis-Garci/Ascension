using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cameraScript : MonoBehaviour
{
    public Animation anim; //animacion camara
    public Animation anim2; //animacon Raycast
    public Light spotlight; //Luz de espera
    public Light spotlight2; //luz atrapado
    public float viewDistance; //distancia del raycast
    public LayerMask viewMask; //Mascara que detecta la camara (la 8 es la de player)
    private float viewAngle; //angulo de vision que corresponde a angulo de luz
    public Transform player; //Cogemos transform de nuestro personaje
    Color originalSpotlightColour; //cogemos el color original de la luz
    public GameObject camera; //seleccionamos la cabeza de nuestra camara
    private bool pillado = false; //booleana para cuando te pillan por defecto en false
    public Transform objectiveCamera; /*objetivo de la camara que es empty en el personaje 
    para arreglar bug de camara mirando a el suelo al hacer el lookAT*/
    public Slider slider;
    public Canvas tehanpillado;
    float progreso;
    public GameObject eventSystemPillado;
    public GameObject eventSystemContinue;
    public GameObject Hud;





    // Start is called before the first frame update
    void Start()
    {
        tehanpillado.enabled = false;
        spotlight2.enabled = false;
        originalSpotlightColour = spotlight.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        eventSystemPillado.SetActive(false);

    }
    bool CanSeePlayer() //Metodo para ver a el personaje con el raycast y el angulo de la spotlight
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
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

        if (CanSeePlayer()) //variables que se activan cuando ve a el personaje
        {
            anim.enabled = false; //deshabilita animacion camara
            anim2.enabled = false; //deshabilita animacion raycast
            transform.LookAt(player); //activa lookAt a raycast
           camera.transform.LookAt(objectiveCamera.transform ); //activa lookAt a el empty de nuestro personaje por bug.
            spotlight.enabled = false; //desactiva luz de idle
            spotlight2.enabled = true; //activa luz de atrapado
            spotlight2.color = Color.red; //cambia en rojo la luz de atrapado
            pillado = true; //pone en true la booleana pillado
            StopCoroutine("sliderpilladoDown");
            StartCoroutine("sliderpilladoUp");


        }
        else
        {
            StopCoroutine("sliderpilladoUp");
            

            spotlight2.color = originalSpotlightColour; //coloca la luz de su posicion original
            
            if (pillado == true)//si la variable es true al salir del area de vision y esperar 2segundos comienza el invoke
            {
                
                Invoke("NotSeen", 2.0f);
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

    void NotSeen() //con este invoke las luces vuelven a su sitio y se activan las animaciones y vuelve la booleana a false
    {
        spotlight.enabled = true;
        spotlight2.enabled = false;
        anim.enabled = true;
        anim2.enabled = true;
        pillado = false;
        StartCoroutine("sliderpilladoDown");


    }

    IEnumerator sliderpilladoUp()
    {
        for (float n = 0.3f; n<1f; n++)
        {
            slider.value = progreso;
            progreso += n * Time.deltaTime;
            if (progreso > 0.99)
            {
                eventSystemContinue.SetActive(false);
                Hud.SetActive(false);
                eventSystemPillado.SetActive(true);
                tehanpillado.enabled = true;
                Time.timeScale = 0;
                
            }
        }
        yield return null;
    }

    IEnumerator sliderpilladoDown()
    {
        
        if(progreso > 0.05f)
        {
            for (float n = 1f; n > 0.01f; n--)
            {
                
                slider.value = progreso;
                progreso -= n * Time.deltaTime;
            }
        }
        
        yield return null;
    }
}