using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEventSystem : MonoBehaviour
{
    public GameObject tehanpillado;
    public GameObject start;
    public GameObject hud;
    public Canvas canvastart;
    public GameObject eventsystemContinue;
    public GameObject eventsystemPillado;
    private bool On;

    // Start is called before the first frame update
    void Start()
    {
        canvastart.enabled = false;
        hud.SetActive(true);
        tehanpillado.SetActive(false);
        eventsystemContinue.SetActive(true);
        eventsystemPillado.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        //Metodo Start 
        if (Input.GetButtonDown("Start") && On == false)
        {
            canvastart.enabled = true;
            hud.SetActive(false);
            start.SetActive(true);
            tehanpillado.SetActive(false);
            Time.timeScale = 0;
            On = true;
            eventsystemContinue.SetActive(true);
            eventsystemPillado.SetActive(false);


        }
        else if (Input.GetButtonDown("Start") && On == true)
        {
            canvastart.enabled = false;
            start.SetActive(false);
            hud.SetActive(true);
            tehanpillado.SetActive(true);
            Time.timeScale = 1;
            On = false;
            eventsystemContinue.SetActive(true);
            eventsystemPillado.SetActive(false);


        }




    }
}
