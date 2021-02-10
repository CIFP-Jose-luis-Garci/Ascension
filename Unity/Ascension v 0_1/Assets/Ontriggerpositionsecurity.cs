using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontriggerpositionsecurity : MonoBehaviour
{
    public Animator anim;
    public GameObject agente;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemigo")
        {
            anim.SetBool("Parado", true);
            anim.SetBool("Vigilando", false);
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemigo")
        {
            anim.SetBool("Parado", false);
            anim.SetBool("Vigilando", true);
        }
    }
           
}

