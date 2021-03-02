using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEventSystem : MonoBehaviour
{
    public GameObject tehanpillado;
    public GameObject start;
    public GameObject hud;
    public Canvas canvastart;
    public GameObject canvasprincipio;
    public GameObject eventsystemContinue;
    public GameObject eventsystemPillado;
    private bool On;

    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(false);
        //canvastart.enabled = false;
        hud.SetActive(true);
        tehanpillado.SetActive(true);
        eventsystemContinue.SetActive(true);
        eventsystemPillado.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        //Metodo Start 
        if (Input.GetButtonDown("Start") && On == false)
        {
            start.SetActive(true);
            canvastart.enabled = true;
            canvasprincipio.SetActive(false);
            hud.SetActive(false);
            
            tehanpillado.SetActive(false);
            

            Time.timeScale = 0;
            On = true;
            eventsystemContinue.SetActive(true);
            eventsystemPillado.SetActive(false);


        }
        else if (Input.GetButtonDown("Start") && On == true)
        {
            start.SetActive(false);
            //canvastart.enabled = false;
            hud.SetActive(true);
            tehanpillado.SetActive(true);
            Time.timeScale = 1;
            On = false;
            eventsystemContinue.SetActive(true);
            eventsystemPillado.SetActive(false);


        }




    }
}
