using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementplayer : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPlayer();
       
    }

    void MovimientoPlayer()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;
        float desplZ = Input.GetAxis("Vertical");
        float desplX = Input.GetAxis("Horizontal");

       
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * desplX);
            transform.Translate(Vector3.back * Time.deltaTime * speed * desplZ);
        }

    }
}