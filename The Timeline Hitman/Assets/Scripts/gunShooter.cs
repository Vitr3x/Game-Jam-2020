using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShooter : MonoBehaviour
{
    public GameObject BulletSpawn;
    public GameObject Bullet;
    public float BulletSpeed;
    GameObject hand;
    GameObject aim;

    bool shoot = false;
    GameObject cam;


    private float time = 0.0f;
    public float interpolationPeriod = 0.5f;
    // Use this for initialization
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        hand = GameObject.FindGameObjectWithTag("Hand");
        aim = GameObject.FindGameObjectWithTag("Aim");
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;



       

        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit);


        if(hand.transform.childCount > 0)
        {
            for (int i = 0; i < hand.transform.childCount; i++)
            {
                if (hand.transform.GetChild(i).transform.gameObject.name == "gun")
                {
                    Debug.Log("we through");
                    if (time >= interpolationPeriod)
                    {
                        time = 0.0f;
                        shoot = true;
                    }
                    Vector3 diff = hand.transform.GetChild(i).transform.position - aim.transform.position;
                    hand.transform.GetChild(i).transform.rotation = Quaternion.LookRotation(diff);
                    hand.transform.GetChild(i).transform.Rotate(0, 180, 0);
                }
            }
        }

        if (shoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<AudioSource>().Play();
                GameObject tempBullet;
                tempBullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;
                tempBullet.transform.Rotate(Vector3.left * 90);
                Rigidbody RB;
                RB = tempBullet.GetComponent<Rigidbody>();
                RB.AddForce(transform.forward * BulletSpeed);
                Destroy(tempBullet, 3);
                shoot = false;
            }
        }
    }
}
