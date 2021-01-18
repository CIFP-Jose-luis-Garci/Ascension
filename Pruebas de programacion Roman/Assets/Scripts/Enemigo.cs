using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Player;
    public float visionlenght;
    public float speed = 3;
    public float waitTime = 0.1f;
    public float lookspeed = 100;
    public float turnSpeed = 90;
    public Transform pathHolder;

    public void OnDrawGizmos() //Dibujar esferas y conexiones del recorrido de nuestro personaje.
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        //bucle para que genere una esfera en cada waypoint del padre Path
        foreach (Transform waypoint in pathHolder)
        {
            //Dibujamos una esfera en cada emptyObject que hayamos metido en Path
            Gizmos.DrawSphere(waypoint.position, .3f);
            //Dibujamos una linea que conecta los emptyObjects para poder ver el recorrido que 
            //hara nuestro enemigo.
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        //Conecta la linea final del gizmo con la principal.
        Gizmos.DrawLine(previousPosition, startPosition);
    }


    // Start is called before the first frame update
    void Start()
    {
        //Creamos un array de los vector 3 de los waypoints de los gizmos dentro del Path
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        //Creamos un bucle a traves de ese array.
        for (int n = 0; n < waypoints.Length; n++)
        {
            //cojemos la posicion de los waypoints para nuestro enemigo
            waypoints[n] = pathHolder.GetChild(n).position;
        }
        //comenzamos una rutina
         StartCoroutine(FollowPath(waypoints));
    }

    //Update is called once per frame
    void Update()
    {
        AtraparPlayer();
    }


    void AtraparPlayer()
    {

        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.forward);
        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.forward);


        //esto es la creacion del raytrace
        if (Physics.Raycast(myRay, out hit, visionlenght))
        {
            //esto es cuando el raytrace golpe a el personaje
            if (hit.collider.tag == "Player")
            {
                GetComponent<Animation>().Stop();

                //esto es para que avance hacia el personaje
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

                //esto es para que mire al personaje
                Vector3 direction = Player.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * lookspeed);
                transform.rotation = lookAt;
            }
        }

    }
    
    //Creamos una rutina que hace que vaya moviendose el personaje de un waypoint a otro.
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime); //Damos los segundos que espera entre un waypoint y otro
                yield return StartCoroutine(TurnToFace(targetWaypoint)); //Empieza la corrutina para girar hacia el otro waypoint.
            }
            yield return null;
        }

        IEnumerator TurnToFace(Vector3 lookTarget) //Esta corrutina gira hacia el siguiente punto y rota al personaje junto con la luz.
        {
            Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
            float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

            while (Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle) > 0.05f)
            {
                float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
                transform.eulerAngles = Vector3.up * angle;
                yield return null;
            }
        }
    }
}
   

