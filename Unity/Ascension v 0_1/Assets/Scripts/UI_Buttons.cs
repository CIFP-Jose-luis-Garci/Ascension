using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    // Start is called before the first frame update

    public void StartGame()
    {
        SceneManager.LoadScene("Escena2");
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
}
