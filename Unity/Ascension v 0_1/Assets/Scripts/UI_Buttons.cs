using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public GameObject player;
    public PruebasCheckPoint pruebas;

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

    public void VolverMenu()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void Ajustes()
    {
        SceneManager.LoadScene("Escena3");
    }

    public void Continuar()
    {
        SceneManager.LoadScene("EscenaAscensor");
    }

    public void Coleccionables()
    {
        SceneManager.LoadScene("Escena4");
    }
    public void Reintentar()
    {
        pruebas.Die();
        
    }
}
