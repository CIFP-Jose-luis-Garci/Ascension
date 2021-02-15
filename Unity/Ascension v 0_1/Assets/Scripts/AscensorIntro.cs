using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AscensorIntro : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            SceneManager.LoadScene("Demo1");
        }
    }
}
