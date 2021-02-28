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
    public Canvas pilladoCanvas;
    public GameObject eventsystem;
    public Slider slidervision;
    

    // Start is called before the first frame update
    void Start()
    {
        CurrentCheckPoint = 0;
        NextCheckPoint = CurrentCheckPoint + 1;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        //Comprobamos si el punto de control alcanzado es el siguiente en la lista
        if (other.name == "CheckPoint" + NextCheckPoint)
        {
            //Actualizamos los valores
            CurrentCheckPoint = NextCheckPoint;
            NextCheckPoint = CurrentCheckPoint + 1;

           
        }
    }

   public void Die()
    {
        //Si el personaje muere, lo devolvemos a la posición del último checkpoint alcanzado
        //Para ello, usamos el GameObject almacenado en el punto concreto del Array
        Vector3 RestartPos = CheckPointsArray[CurrentCheckPoint].transform.position;

        //Lo llevamos allí (habrá que ver qué pasa con la cámara)
        transform.position = RestartPos;

        pilladoCanvas.enabled = false;
        Time.timeScale = 1;
        eventsystem.SetActive(false);
        slidervision.value = 0f;

    }
}
