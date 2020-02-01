using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events : MonoBehaviour
{
    bool killedGuy = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killedMan(string namez)
    {
        StartCoroutine(TimeIt(2, namez));
    }

    void killedManpart2()
    {
        Debug.Log("we made it");
    }

    IEnumerator TimeIt(int seconds, string namez)
    {
        yield return new WaitForSeconds(seconds);
        if (namez == "Guy")
        {
            killedManpart2();
        }
    }
}
