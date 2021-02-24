using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoPuertaServers : MonoBehaviour
{
    [SerializeField] GameObject bloqueopuerta;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sonidoreactivadorpuerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider target)

    {
        if (Input.GetButtonDown("X"))
        {
            bloqueopuerta.SetActive(false);
            print("funciono");
            audioSource.PlayOneShot(sonidoreactivadorpuerta, 0.2f);
        }

    }
}
