using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PruebasCheckPoint : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;

    //Array con los Empty Objects que harán de CheckPoint
    [SerializeField] GameObject[] CheckPointsArray;

    //Punto de control en el que estamos ahora mismo
    [SerializeField] int CurrentCheckPoint;
    [SerializeField] int NextCheckPoint;

    //Texto
    [SerializeField] Text textoInfo;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCheckPoint = 0;
        NextCheckPoint = CurrentCheckPoint + 1;

        textoInfo.text = "Punto de control actual: " + CurrentCheckPoint; 
    }

    // Update is called once per frame
    void Update()
    {
        //MoverPersonaje();

        //Si pulsamos el botón de disparo, simulamos que nos hemos muerto
        if(Input.GetKeyDown("space"))
        {
            //Ejecutamos el método Die, pero esperando dos segundos
            print("Te has muerto, espera 2 segundos para volver a comenzar");
            textoInfo.text = "MUERTO. En 2 segundos irás al punto de ocntrol: " + CurrentCheckPoint;
            Invoke("Die", 2f);
        }
    }

    /*void MoverPersonaje()
    {
        float desplX = Input.GetAxis("Horizontal");
        float desplZ = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * desplX * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * desplZ * moveSpeed * Time.deltaTime);
    }

   */ private void OnTriggerEnter(Collider other)
    {
        //Comprobamos si el punto de control alcanzado es el siguiente en la lista
        if (other.name == "CheckPoint" + NextCheckPoint)
        {
            print("Alcanzado siguiente punto de control");
            //Actualizamos los valores
            CurrentCheckPoint = NextCheckPoint;
            NextCheckPoint = CurrentCheckPoint + 1;

            textoInfo.text = "Punto de control actual: " + CurrentCheckPoint;
        }
    }

    void Die()
    {
        //Si el personaje muere, lo devolvemos a la posición del último checkpoint alcanzado
        //Para ello, usamos el GameObject almacenado en el punto concreto del Array
        Vector3 RestartPos = CheckPointsArray[CurrentCheckPoint].transform.position;

        //Lo llevamos allí (habrá que ver qué pasa con la cámara)
        transform.position = RestartPos;
        textoInfo.text = "Punto de control actual: " + CurrentCheckPoint;

    }
}
