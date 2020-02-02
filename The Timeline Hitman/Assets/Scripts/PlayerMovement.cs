using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 0.5f;

    public Transform grounded;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    private float savedHeight;
    private float savedCapHeight;
    private float savedCamHeight;
    private bool uncrouching = false;

    Vector3 banana;
    bool isGrounded;

    // Update is called once per frame

    private void Start()
    {
        savedHeight = this.GetComponent<CharacterController>().height;
        savedCapHeight = transform.GetChild(0).transform.localScale.y;
    }

    void Update()
    {


        if (uncrouching)
        {
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position + new Vector3(0, 1, 0), transform.localScale / 2, Quaternion.identity, 9);
            int ii = 0;
            if (hitColliders.Length != 0)
            {
                while (ii < hitColliders.Length)
                {

                    uncrouching = true;
                    //Output all of the collider names
                    Debug.Log("Hit : " + hitColliders[ii].name + ii);
                    //Increase the number of Colliders in the array
                    ii++;
                }
            }
            else
            {
                this.GetComponent<CharacterController>().height = savedHeight;
                this.transform.GetChild(0).transform.localScale = new Vector3(transform.GetChild(0).transform.localScale.x, savedCapHeight, transform.GetChild(0).transform.localScale.z); ;
                this.transform.GetChild(1).transform.position = new Vector3(transform.GetChild(1).transform.position.x, transform.position.y + 0.8f, transform.GetChild(1).transform.position.z);
                uncrouching = false;
            }
        }
    




        isGrounded = Physics.CheckSphere(grounded.position, groundDist, groundMask);

        if(isGrounded && banana.y < 0)
        {
            banana.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            banana.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (this.GetComponent<CharacterController>().height > 0.1)
            {
                this.GetComponent<CharacterController>().height = this.GetComponent<CharacterController>().height - 0.1f;
                this.transform.GetChild(0).transform.localScale = new Vector3 (transform.GetChild(0).transform.localScale.x, transform.GetChild(0).transform.localScale.y - 0.03f, transform.GetChild(0).transform.localScale.z);
                this.transform.GetChild(1).transform.position = new Vector3(transform.GetChild(1).transform.position.x, transform.GetChild(1).transform.position.y - 0.02f, transform.GetChild(1).transform.position.z);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position + new Vector3(0, 1, 0), transform.localScale / 2, Quaternion.identity, 9);
            int ii = 0;
            if (hitColliders.Length != 0)
            {
                while (ii < hitColliders.Length)
                {

                    uncrouching = true;
                    //Output all of the collider names
                    Debug.Log("Hit : " + hitColliders[ii].name + ii);
                    //Increase the number of Colliders in the array
                    ii++;
                }
            }
            else
            {
                this.GetComponent<CharacterController>().height = savedHeight;
                this.transform.GetChild(0).transform.localScale = new Vector3(transform.GetChild(0).transform.localScale.x, savedCapHeight, transform.GetChild(0).transform.localScale.z); ;
                this.transform.GetChild(1).transform.position = new Vector3(transform.GetChild(1).transform.position.x, transform.position.y + 0.8f, transform.GetChild(1).transform.position.z);
                uncrouching = false;
            }
            
            
        }

        banana.y += gravity * Time.deltaTime;

        cc.Move(banana * Time.deltaTime);
    }
}
