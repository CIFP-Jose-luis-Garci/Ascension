using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoPuertaServers : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animacionPuerta;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sonidoreactivadorpuerta;
    [SerializeField] GameObject LuzAbiertaServer;
    [SerializeField] GameObject LuzCerradaServer;
    [SerializeField] GameObject PressX;
    [SerializeField] GameObject AudioPuertaServer;
    private bool pressx;
    
    private bool pressxonce;

    private bool estadentroServer;
    void Start()
    {
        animacionPuerta.SetBool("PuertaAbierta", false);
        LuzAbiertaServer.SetActive(false);
        LuzCerradaServer.SetActive(true);
        estadentroServer = false;
        PressX.SetActive(false);
        pressx = false;
        pressxonce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X") && estadentroServer == true &&  pressxonce == true)
        {
           animacionPuerta.SetBool("PuertaAbierta", true);
            audioSource.PlayOneShot(sonidoreactivadorpuerta, 0.2f);
            LuzAbiertaServer.SetActive(true);
            LuzCerradaServer.SetActive(false);
            pressx = false;
            pressxonce = false;
            AudioPuertaServer.SetActive(true);
            
        }
        DentroFueraX();
    }

void OnTriggerEnter(Collider target)

    {
        if(target.gameObject.tag == "Player")
        {
            estadentroServer = true;
        
        }

        if(target.gameObject.tag == "Player" && pressx == false && pressxonce == true)
        
        {

        pressx = true;

        }

    }
    void OnTriggerExit(Collider target)
    {

    if(target.gameObject.tag == "Player")
        
        {

        estadentroServer = false;
        pressx = false;

        }
    }


     void DentroFueraX()
    {
        if (pressx == true)
        {
        
        PressX.SetActive(true);

        }

        else if(pressx == false)
        {

        PressX.SetActive(false);

        }

    }

}
