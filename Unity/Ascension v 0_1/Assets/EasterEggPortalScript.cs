using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggPortalScript : MonoBehaviour
{
    public GameObject eastereggPortal;
   
    // Start is called before the first frame update
    void Start()
    {
        eastereggPortal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)

        {
            
            if(target.gameObject.tag == "Player")
            {
             eastereggPortal.SetActive(true);
            }
        }         
void OnTriggerExit(Collider target)

        {
            
            if(target.gameObject.tag == "Player")
            {
             eastereggPortal.SetActive(false);
            }
        }         

        

}
