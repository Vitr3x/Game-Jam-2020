using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{

    // path between an array of waypoints
    public GameObject[] path;
    public float rotationSpeed = 6.0f;
    public float acceleration = 1.8f;
    public bool DoPath = false;
    private int crtPoint = 0;

    public void Update()
    {
        if (DoPath)
        {
            walk();
            if(crtPoint == path.Length)
            {
                DoPath = false;
            }
        }
    }

    public void walk()
    {
        Debug.Log("Started Pathing");

        Debug.Log("Pathing to point");
        Quaternion rotation = Quaternion.LookRotation(path[crtPoint].transform.position - this.transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        Vector2 wayPointDirection = path[crtPoint].transform.position - transform.position;

        float speedElement = Vector2.Dot(wayPointDirection.normalized, transform.forward);
        float speed = acceleration * speedElement;
        Debug.Log(speed);

        this.transform.Translate(0, 0, Time.deltaTime * speed);

    }

    void onTriggerEnter(Collider collider)
    {
        if (collider.tag == "Point")
        {
            crtPoint++;
        }
    }


}
