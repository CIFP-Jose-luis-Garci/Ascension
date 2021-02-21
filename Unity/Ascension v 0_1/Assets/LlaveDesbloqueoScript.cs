using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveDesbloqueoScript : MonoBehaviour
{

    public GameObject bloqueopuerta;
    public GameObject luztarjeta;
    public MeshRenderer tarjeta;
    public SphereCollider tarjetacollider;
    public AudioSource audioSource;
    public AudioClip sonidorecoleccion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)

        {
            //Relacionado en la tarjeta.
            tarjeta.enabled = false;
            audioSource.PlayOneShot(sonidorecoleccion, 1f);
            luztarjeta.SetActive(false);
            tarjetacollider.enabled = false;
            
            //Bloqueo de puerta.
            
            bloqueopuerta.SetActive(false);

            //Sonido recolección.

            audioSource.PlayOneShot(sonidorecoleccion, 0.2f);

        }  

}
