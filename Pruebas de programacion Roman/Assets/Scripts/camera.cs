using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject tarjet;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = tarjet.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal2") * rotateSpeed;
        float vertical = Input.GetAxis("Vertical2") * rotateSpeed;
        tarjet.transform.Rotate(0, horizontal, 0);

        float desiredAngle = tarjet.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = tarjet.transform.position - (rotation * offset);

        transform.LookAt(tarjet.transform);
        
    }
}