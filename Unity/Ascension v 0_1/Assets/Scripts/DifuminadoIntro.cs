using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifuminadoIntro : MonoBehaviour
{
    public float alphaLevel = 256f;
    public GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    
    
    void Update()
    {
        alphaLevel--;
        Image.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel) * Time.deltaTime / 5;
    }
}
