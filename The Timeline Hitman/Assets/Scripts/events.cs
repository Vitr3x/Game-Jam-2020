using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class events : MonoBehaviour
{
    bool killedGuy = false;
    private Animator blackScreen;
    GameObject blkScr;

    
    // Start is called before the first frame update
    void Start()
    {
        blkScr = GameObject.FindGameObjectWithTag("Panel");
        blackScreen = blkScr.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killedMan(string namez)
    {
        StartCoroutine(TimeIt(1, namez));
    }

    void killedManpart2()
    {
        Debug.Log("we made it");
        blackScreen.SetBool("toBlack", true);
        blkScr.transform.GetChild(0).transform.gameObject.SetActive(true);
        StartCoroutine(EndLvl(3));
    }

    void seenBySomeone()
    {
        Debug.Log("seen");
        blackScreen.SetBool("toBlack", true);
        blkScr.transform.GetChild(1).transform.gameObject.SetActive(true);
        StartCoroutine(EndLvl(3));
    }

    void resetLevel()
    {
        SceneManager.LoadScene("Game Scene");
    }

    IEnumerator TimeIt(int seconds, string namez)
    {
        yield return new WaitForSeconds(seconds);
        if (namez == "Guy")
        {
            killedManpart2();
        } else if (namez == "Spotted")
        {
            seenBySomeone();
        }
    }

    IEnumerator EndLvl(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        resetLevel();
    }
}
