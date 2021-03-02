using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform player;
    public float viewDistance;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void StartGiro()
    {
        StartCoroutine("GiroCamara");
    }

    public void StopGiro()

    {
        StopCoroutine("GiroCamara");
    }


    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        
       
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
    IEnumerator GiroCamara()
    {
        for(int n=0; ; n++)
        {
            if(n<30)
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 300);
            }
            else if (n<60)
            {
                transform.Rotate(Vector3.down * Time.deltaTime * 300);
            }
            else
            {
                n = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
