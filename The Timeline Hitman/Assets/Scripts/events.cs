using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class events : MonoBehaviour
{
    bool killedGuy = false;
    private Animator blackScreen;
    GameObject blkScr;
    public GameObject lable;
    
    // Start is called before the first frame update
    void Start() { 

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
       
        blackScreen.SetBool("toBlack", true);
        lable.GetComponent<Text>().text = "THAT WASN'T HITLER!!!\n\n By killing one of Hitlers \"loyal\" followers you have incited his rage!In the wake of your meddling the world has turned into a nuclear wasteland.\n\nFIX THIS NOW.We are sending you back to start over!";
        lable.SetActive(true);
        StartCoroutine(EndLvl(3));
    }

    void CaughtWithGun()
    {
        blackScreen.SetBool("toBlack", true);
        lable.GetComponent<Text>().text = "BUSTED\n\nGood job rookie.Bailing you out was not on our to do list.Thanks to your inadequacy Hitler now knows of time travel.Shooting faster dumb ass. ****HE IS AFTER US * ***.\n\nRESET NOW FAST-- - Damn Rookies";
        lable.SetActive(true);
        StartCoroutine(EndLvl(3));
    }

    void seenBySomeone()
    {
        Debug.Log("seen");
        blackScreen.SetBool("toBlack", true);
        lable.GetComponent<Text>().text = "BUSTED \n Good job rookie.Bailing you out was not on our to do list.Thanks to your inadequacy Hitler now knows of time travel.Try knocking that major out. ****HE IS AFTER US * ***. \n\nRESET NOW FAST-- - Damn Rookies";
        lable.SetActive(true);             
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
