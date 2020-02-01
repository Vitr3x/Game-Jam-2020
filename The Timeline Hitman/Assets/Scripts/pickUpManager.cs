using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpManager : MonoBehaviour
{
    float dist;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.tag == "Pickup")
            {
                dist = Vector3.Distance(cam.transform.position, selection.transform.position);
                if (dist < 2)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        selection.GetComponent<item>().PickUp();
                    }
                }
            }
        }
    }
}
