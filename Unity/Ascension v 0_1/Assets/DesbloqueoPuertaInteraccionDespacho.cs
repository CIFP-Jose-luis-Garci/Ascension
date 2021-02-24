using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoPuertaInteraccionDespacho : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject bloqueopuerta;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sonidoreactivadorpuerta;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider target)

    {
      if(Input.GetButtonDown("X"))
        {
            bloqueopuerta.SetActive(false);
            print("funciono");
            audioSource.PlayOneShot(sonidoreactivadorpuerta, 0.2f);
        }

    }
}
