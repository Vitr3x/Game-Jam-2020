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
    [SerializeField]
    private GameObject Hitler;
    GameObject player;
    
    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;
        blkScr = GameObject.FindGameObjectWithTag("Panel");
        player = GameObject.FindGameObjectWithTag("Player");
        blackScreen = blkScr.GetComponent<Animator>();
        StartCoroutine(HitlerSpawn(50));

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
        player.SetActive(false);
        blackScreen.SetBool("toBlack", true);
        lable.GetComponent<Text>().text = "THAT WASN'T HITLER!!!\n\nBy killing one of Hitlers \"loyal\" followers you have incited his rage!In the wake of your meddling the world has turned into a nuclear wasteland.\n\nFIX THIS NOW.We are sending you back to start over!";
        lable.SetActive(true);
        StartCoroutine(EndLvl(8));
    }

    public void CaughtWithGun()
    {
        Debug.Log("caught with a gun");
        player.SetActive(false);
        blackScreen.SetBool("toBlack", true);
        lable.SetActive(true);
        lable.GetComponent<Text>().text = "BUSTED\n\nGood job rookie.Bailing you out was not on our to do list.Thanks to your inadequacy Hitler now knows of time travel.Shooting faster dumb ass. ****HE IS AFTER US * ***.\n\nRESET NOW FAST-- - Damn Rookies";
        StartCoroutine(EndLvl(8));
    }

    void seenBySomeone()
    {
        Debug.Log("seen");
        player.SetActive(false);
        blackScreen.SetBool("toBlack", true);
        lable.GetComponent<Text>().text = "BUSTED \n\nGood job rookie.Bailing you out was not on our to do list.Thanks to your inadequacy Hitler now knows of time travel.Try knocking that major out. ****HE IS AFTER US * ***. \n\nRESET NOW FAST-- - Damn Rookies";
        lable.SetActive(true);             
        StartCoroutine(EndLvl(8));
    }

    void resetLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void HitlerEscape()
    {
        player.SetActive(false);
        blackScreen.SetBool("toBlack", true);
        lable.GetComponent<Text>().text = "HE ESCAPED \n\nYOU SCRUB, you let Hitler get away! better  improve soon or your fired! \n\nRESET NOW FAST-- - Damn Rookies";
        lable.SetActive(true);
        StartCoroutine(EndLvl(8));
    }

    IEnumerator TimeIt(int seconds, string namez)
    {
        yield return new WaitForSeconds(seconds);
        if (namez == "SS" || namez == "SS1")
        {
            killedManpart2();
        } else if (namez == "Spotted")
        {
            seenBySomeone();
        }else if (namez == "Hitler")
        {
            player.SetActive(false);
            blackScreen.SetBool("toBlack", true);
            lable.GetComponent<Text>().text = "EZ Clap \n\nI'm expecting a trick shot next time";
            lable.SetActive(true);
            StartCoroutine(WinLvl(8));
        }
    }

    IEnumerator EndLvl(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);
    }

    IEnumerator HitlerSpawn(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("spawn hit");
        Hitler.SetActive(true);
    }

    IEnumerator WinLvl(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
