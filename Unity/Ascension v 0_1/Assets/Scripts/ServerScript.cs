using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerScript : MonoBehaviour
{

    public bool estaRangoServer;
    public float timerCuentaAtras;
    public int segundos;
    [SerializeField] GameObject FinalDelNivel;
    [SerializeField] Animator animatorPuertaCerrada;
    public float prueba;

    // Start is called before the first frame update
    void Start()
    {
       estaRangoServer = false;
       FinalDelNivel.SetActive(false);
       animatorPuertaCerrada.SetBool("PuertaCuarentena", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
       InteraccionServer();

       FinalNivel();
       
       print(segundos);
      
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
        if(segundos >= 25)
        {
            FinalDelNivel.SetActive(true);
            animatorPuertaCerrada.SetBool("PuertaCuarentena", false);
        }
    }
   


    IEnumerator CuentaAtras()
    {
             

        while(segundos < 25)
       
        {
            
            timerCuentaAtras += Time.deltaTime;
            segundos = (int)timerCuentaAtras % 60;
            animatorPuertaCerrada.SetBool("PuertaCuarentena", true);
            print("Funciono");
            yield return new WaitForSeconds(0.0001f);
        }

    }

  
}

