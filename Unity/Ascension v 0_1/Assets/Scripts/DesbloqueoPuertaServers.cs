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
    private bool estadentroServer;
    void Start()
    {
        animacionPuerta.SetBool("PuertaAbierta", false);
        LuzAbiertaServer.SetActive(false);
        LuzCerradaServer.SetActive(true);
        estadentroServer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X") && estadentroServer == true)
        {
           animacionPuerta.SetBool("PuertaAbierta", true);
            audioSource.PlayOneShot(sonidoreactivadorpuerta, 0.2f);
            LuzAbiertaServer.SetActive(true);
            LuzCerradaServer.SetActive(false);
        }
        
    }

void OnTriggerEnter(Collider target)

    {
        if(target.gameObject.tag == "Player")
        {
            estadentroServer = true;
        }

    }
    void OnTriggerExit(Collider target)
    {

    if(target.gameObject.tag == "Player")
        
        {

        estadentroServer = false;

        }
    }

}
