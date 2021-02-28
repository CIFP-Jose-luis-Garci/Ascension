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
    [SerializeField] Image usb;
    public float prueba;

    // Start is called before the first frame update
    void Start()
    {
       estaRangoServer = false;
       FinalDelNivel.SetActive(false);
       animatorPuertaCerrada.SetBool("PuertaCuarentena", false);
       usb.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       InteraccionServer();

       FinalNivel();
       
       //print(segundos);
      
    }

    void OnTriggerEnter(Collider target)

    {
        if(target.gameObject.tag == "Player")
        {
            
            estaRangoServer = true;
            
        }

    }

    void OnTriggerExit(Collider target)
    {

    if(target.gameObject.tag == "Player")
        
        {

        estaRangoServer = false;

        }
    }


    void InteraccionServer()
    {
       
        if(Input.GetButtonDown("X") && estaRangoServer == true && segundos == 0)  
        {
           StartCoroutine("CuentaAtras");
        }
    }  

    void FinalNivel()
    
    {
        if(segundos >= 15)
        {
            FinalDelNivel.SetActive(true);
            animatorPuertaCerrada.SetBool("PuertaCuarentena", false);
            usb.enabled = true;
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

    }

  
}

