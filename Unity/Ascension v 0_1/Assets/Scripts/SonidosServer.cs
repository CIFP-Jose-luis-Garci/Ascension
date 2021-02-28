using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosServer : MonoBehaviour
{
    public GameObject audioServers;

    // Start is called before the first frame update
    void Start()
    {
         audioServers.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)

        {
            
            if(target.gameObject.tag == "Player")
            {
              audioServers.SetActive(true);
            }
        }         
void OnTriggerExit(Collider target)

        {
            
            if(target.gameObject.tag == "Player")
            {
              audioServers.SetActive(false);
            }
        }         
}
