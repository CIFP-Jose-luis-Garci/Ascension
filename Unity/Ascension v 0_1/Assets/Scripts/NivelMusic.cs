using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelMusic : MonoBehaviour
{
    public GameObject clips;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        clips = GameObject.FindGameObjectWithTag("clip_audio");

        //En función de si estamos en la pantalla de carga, opciones o el nivel, se reproducirá una canción u otra.
        scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 0)
        {
            clips.GetComponent<AudioSource>().Play();
            if(scene.buildIndex != 0)
                clips.GetComponent<AudioSource>().Stop();
        }
        if (scene.buildIndex == 1)
        {
            clips.GetComponent<AudioSource>();
            if (scene.buildIndex != 1)
                clips.GetComponent<AudioSource>().Stop();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
