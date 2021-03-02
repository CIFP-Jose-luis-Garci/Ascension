using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionableBaño : MonoBehaviour
{
    public MeshRenderer coleccionableRenderer;
    public GameObject luzcoleccionable;
    public AudioSource audioSource;
    public AudioClip clipaudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnTriggerEnter(Collider target)

        {
            
            coleccionableRenderer.enabled = false;
            luzcoleccionable.SetActive(false);
            audioSource.PlayOneShot(clipaudio, 1f);

        }         
}
