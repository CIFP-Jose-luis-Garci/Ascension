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
    private bool estadentro;
    void Start()
    {
        LuzAbiertaDespachos.SetActive(false);
        LuzCerradaDespachos.SetActive(true);
        estadentro = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X") && estadentro == true)
        {
            bloqueopuerta.SetActive(false);
            print("funciono");
            audioSource.PlayOneShot(sonidoreactivadorpuerta, 0.2f);
            LuzAbiertaDespachos.SetActive(true);
            LuzCerradaDespachos.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider Despacho)

    {
        print("Estas entrando en el despacho");
        estadentro = true;

    }
    void OnTriggerExit(Collider Despacho)

    {
        estadentro = false;

    }


}