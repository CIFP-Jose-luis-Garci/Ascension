using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AscensorIntro : MonoBehaviour
{
    public Canvas pantallacarga;
    public Slider slidercarga;
    float progreso;
    bool Comenzar;


    
    // Start is called before the first frame update
    void Start()
    {
        pantallacarga.enabled = false;
        Comenzar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Comenzar == true)
        {
            StartCoroutine("bucleSlider");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pantallacarga.enabled = true;
            Comenzar = true;
            
        }
    }
    IEnumerator bucleSlider()
    {
        for (float n = 0.6f; n < 1f; n++)
        {
            slidercarga.value = progreso;
            progreso += n * Time.deltaTime;
            if (progreso > 0.99)
            {
                SceneManager.LoadScene("Demo1");
                StopCoroutine("bucleSlider");
            }
        }
        yield return null;
    }
}



