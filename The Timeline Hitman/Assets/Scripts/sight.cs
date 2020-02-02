using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{
    GameObject player;
    GameObject EventManage;
    bool ftSpotted = false;
    string wut = "Spotted";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EventManage = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0,3,0), player.transform.position - (transform.position + new Vector3 (0,3,0)), Color.green);
        Vector3 sightDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(sightDir, transform.forward);
        if (angle > -30f && angle < 30f)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, 3, 0), player.transform.position - (transform.position + new Vector3(0, 3, 0)), out hit);
            if(hit.transform.gameObject.name == "Capsule")
            {
                if(ftSpotted == false)
                {
                    Destroy(this.transform.gameObject.GetComponent<routePathing>());
                    ftSpotted = true;
                }
                
                this.transform.rotation = Quaternion.LookRotation(sightDir);
                EventManage.GetComponent<events>().killedMan(wut);
                Destroy(this);
            }
            
        }
            
    }
}

