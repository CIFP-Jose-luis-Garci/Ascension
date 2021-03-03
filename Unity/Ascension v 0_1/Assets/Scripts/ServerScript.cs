using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerScript : MonoBehaviour
{

    public bool estaRangoServer;
    public float timerCuentaAtras;
    public int segundos;
    [SerializeField] GameObject FinalDelNivel;
    [SerializeField] Animator animatorPuertaCerrada;
    [SerializeField] Animator luzServer;

    [SerializeField] Image usb;
    [SerializeField] GameObject USBAnim;
    [SerializeField] AudioClip startServer;
    [SerializeField] AudioClip serverAliniciar;
    [SerializeField] AudioClip serverSuccess;
    [SerializeField] AudioSource audioSource;
    public float prueba;

    [SerializeField] GameObject PressX;
    private bool pressxcartel;
    private bool pressxonce;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        USBAnim.SetActive(false);
        estaRangoServer = false;
        FinalDelNivel.SetActive(false);
        animatorPuertaCerrada.SetBool("PuertaCuarentena", false);
        usb.enabled = false;

        pressxcartel = false;
        pressxonce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       InteraccionServer();

       FinalNivel();
       
       //print(segundos);

       DentroFueraX();
      
    }

    void OnTriggerEnter(Collider target)

    {
        if(target.gameObject.tag == "Player")
        {
            
            estaRangoServer = true;
            
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

        estaRangoServer = false;
        pressxcartel = false;

        }
    }


    void InteraccionServer()
    {
       
        if(Input.GetButtonDown("X") && estaRangoServer == true && segundos == 0 && pressxonce == false)  
        {
           StartCoroutine("CuentaAtras");
           audioSource.PlayOneShot(startServer, 0.7f);
            audioSource.PlayOneShot(serverAliniciar, 1f);
            luzServer.SetTrigger("ServerOn");
           USBAnim.SetActive(true);

            pressxcartel = false;
            pressxonce = true;
        }
    }  

    void FinalNivel()
    
    {
        if(segundos >= 15)
        {
            FinalDelNivel.SetActive(true);
            animatorPuertaCerrada.SetBool("PuertaCuarentena", false);
            

            usb.enabled = true;
            USBAnim.SetActive(false);
        }
    }
   


    IEnumerator CuentaAtras()
    {
             

        while(segundos < 15)
       
        {
            
            timerCuentaAtras += Time.deltaTime;
            segundos = (int)timerCuentaAtras % 60;
            animatorPuertaCerrada.SetBool("PuertaCuarentena", true);
            yield return new WaitForSeconds(0.0001f);
        }
        audioSource.PlayOneShot(serverSuccess, 1f);
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

