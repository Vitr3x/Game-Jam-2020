using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{
    GameObject player;
    GameObject EventManage;
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

        Vector3 sightDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(sightDir, transform.forward);
        if (angle > 55f && angle < 125f)
        {
            this.transform.rotation = Quaternion.LookRotation(sightDir);
            this.transform.Rotate(0, 90, 0);
            Debug.Log(angle);
            EventManage.GetComponent<events>().killedMan(wut);
            Destroy(this);
        }
            
    }
}

