using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public GameObject player;
    public PruebasCheckPoint pruebas;
    public Canvas canvasStart;
    public GameObject hud;
    public Canvas canvaspillado;


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
        hud.SetActive(true);
        

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
        hud.SetActive(true);
        Time.timeScale = 1;
        canvaspillado.enabled = true;
    }

    public void Reintentar()
    {
        hud.SetActive(true);

        pruebas.Die();
        
    }
}
