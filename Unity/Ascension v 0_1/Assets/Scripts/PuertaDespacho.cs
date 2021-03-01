using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDespacho : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject bloqueopuerta;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sonidoreactivadorpuerta;
    [SerializeField] GameObject LuzAbiertaDespachos;
    [SerializeField] GameObject LuzCerradaDespachos;
    [SerializeField] GameObject PressX;
    private bool pressxcartel;
    private bool pressxonce;

    private bool estadentro;
    void Start()
    {
        LuzAbiertaDespachos.SetActive(false);
        PressX.SetActive(false);
        LuzCerradaDespachos.SetActive(true);
        estadentro = false;
        pressxcartel = false;
        pressxonce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X") && estadentro == true &&  pressxonce == false)
        {
            bloqueopuerta.SetActive(false);
            audioSource.PlayOneShot(sonidoreactivadorpuerta, 0.2f);
            LuzAbiertaDespachos.SetActive(true);
            LuzCerradaDespachos.SetActive(false);
            pressxcartel = false;
            pressxonce = true;
        }
        DentroFueraX();
        
    }

    void OnTriggerEnter(Collider target)

    {
        if(target.gameObject.tag == "Player" )
        {
            estadentro = true;
            
            
        }

        if(target.gameObject.tag == "Player" && pressxcartel == false && pressxonce == false)
        
        {

        pressxcartel = true;

        }
    }
    void OnTriggerExit(Collider target)
    {

    if(target.gameObject.tag == "Player")
        
        {

        estadentro = false;
        pressxcartel = false;

        }
    }

    void DentroFueraX()
    {
        if (pressxcartel == true)
        {
        
        PressX.SetActive(true);

        }

        else if(pressxcartel == false)
        {

        PressX.SetActive(false);

        }

    }

    
}
