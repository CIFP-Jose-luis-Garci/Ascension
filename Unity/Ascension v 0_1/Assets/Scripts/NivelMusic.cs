using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelMusic : MonoBehaviour
{
    public GameObject clip;
    // Start is called before the first frame update
    void Start()
    {
        clip = GameObject.FindGameObjectWithTag("clip_audio");
        clip.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
