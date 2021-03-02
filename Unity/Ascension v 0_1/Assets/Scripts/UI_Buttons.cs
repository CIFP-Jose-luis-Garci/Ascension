using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public GameObject player;
    public PruebasCheckPoint pruebas;
    public Canvas canvasStart;
    public Canvas hud;


    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<PruebasCheckPoint>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Escena2");
    }

    public void Salir()
    {
         //Debug.Log("QUIT!");
         Application.Quit();
    }

    public void Ajustes()
    {
        SceneManager.LoadScene("Escena3");
    }

    public void Continuar()
    {
        SceneManager.LoadScene("EscenaAscensor");
        Time.timeScale = 1;
        hud.enabled = true;
        

    }

    public void Coleccionables()
    {
        SceneManager.LoadScene("Escena4");
    }

    public void Volveralmenu()
    {
        SceneManager.LoadScene("Escena2");
    }

    public void ContinuarStart()
    {
        canvasStart.enabled = false;
        Time.timeScale = 1;
    }

    public void Reintentar()
    {
        pruebas.Die();
        
    }
}
