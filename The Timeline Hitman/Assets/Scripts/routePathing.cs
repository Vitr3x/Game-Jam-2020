using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class routePathing : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] points;
    private int destPoints, current = 0;
    public float speed;
    public float rotateSpeed;
    float radius = 1;
    public bool noLoop = false;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(points[current].transform.position, transform.position) < radius)
        {
            current++;
            int p = points.Length;
            if(current >= p && noLoop == false)
            {
                current = 0;
            } else if (current >= p && noLoop == true)
            {
                Destroy(this);
            }
        }

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        _direction = (points[current].transform.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, rotateSpeed * Time.deltaTime);
    }
}
