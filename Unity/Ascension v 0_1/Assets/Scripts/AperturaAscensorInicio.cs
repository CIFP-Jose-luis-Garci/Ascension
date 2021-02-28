using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AperturaAscensorInicio : MonoBehaviour
{
    [SerializeField] Animator PuertaDcha;
    [SerializeField] Animator PuertaIzda;
    [SerializeField] AudioSource Asc;
    [SerializeField] AudioClip SonidoFuncionamientoAsc;
    [SerializeField] AudioClip SonidoLlegadaAsc;
    [SerializeField] AudioClip SonidoAperturaAsc;
    // Start is called before the first frame update
    void Start()
    {
        Asc = GetComponent<AudioSource>();
        Asc.PlayOneShot(SonidoFuncionamientoAsc, 0.2f);
        Invoke("AperturaPuertasAsc", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void AperturaPuertasAsc()
    {
        Asc.PlayOneShot(SonidoLlegadaAsc, 2f);
        PuertaDcha.SetTrigger("PuertaDchaTrig");
        PuertaIzda.SetTrigger("PuertaIzdaTrig");
        
        new WaitForSeconds(0.2f);

        Asc.PlayOneShot(SonidoAperturaAsc, 1f);
        
    }
}
