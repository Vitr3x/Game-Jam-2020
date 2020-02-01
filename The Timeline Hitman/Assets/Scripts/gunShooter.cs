using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShooter : MonoBehaviour
{
    public GameObject BulletSpawn;
    public GameObject Bullet;
    public float BulletSpeed;
    bool shoot = true;


    private float time = 0.0f;
    public float interpolationPeriod = 0.5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;



        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            shoot = true;
        }

        if (shoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
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
