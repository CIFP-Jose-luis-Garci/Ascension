using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject enemy;
    public float visionlenght;
    float speed = 3;
    public GameObject Player;
    public float lookspeed = 100;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AtraparPlayer();
    }
    

    void AtraparPlayer()
        {
           
            RaycastHit hit;
            Ray myRay = new Ray(transform.position, Vector3.forward);

  
            
        //esto es la creacion del raytrace
            if (Physics.Raycast(myRay, out hit, visionlenght))
            {
                //esto es cuando el raytrace golpe a el personaje
                if (hit.collider.tag == "Player")
                {
                     GetComponent<Animation>().Stop();

                       //esto es para que avance hacia el personaje
                        transform.Translate(Vector3.forward * Time.deltaTime * speed);
                   
                //esto es para que mire al personaje
                     Vector3 direction = Player.transform.position - transform.position;
                     Quaternion targetRotation = Quaternion.LookRotation(direction);
                     Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * lookspeed);
                     transform.rotation = lookAt;
            }
            }

    }
   
}
