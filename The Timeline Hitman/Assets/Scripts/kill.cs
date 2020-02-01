using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject person;
    GameObject eventers;
    string namez = "";

    void Start()
    {
        person = this.gameObject;
        namez = this.gameObject.name;
        eventers = GameObject.FindGameObjectWithTag("Inventory");
        Debug.Log(eventers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.name == "bullet(Clone)")
        {
            Debug.Log("hit");
            eventers.GetComponent<events>().killedMan(namez);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
