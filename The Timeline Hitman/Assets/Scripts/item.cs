﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{

    GameObject thisGameobject;
    GameObject inv;
    
    // Start is called before the first frame update
    void Start()
    {
        thisGameobject = this.gameObject;
        inv = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        Debug.Log("Picked up");
        inv.GetComponent<Inventory>().AddItem(thisGameobject);
        thisGameobject.SetActive(false);
    } 
}