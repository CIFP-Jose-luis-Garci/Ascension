using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    public Canvas canvastart;
    private bool On;
    // Start is called before the first frame update
    void Start()
    {
        canvastart.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Start") && On == false)
        {
            print("se esta pulsando");
            canvastart.enabled = true;
            Time.timeScale = 0;
            On = true;

        }
        else if (Input.GetButtonDown("Start")&& On == true)
        {
            canvastart.enabled = false;
            Time.timeScale = 1;
            On = false;
        }
    }
}
