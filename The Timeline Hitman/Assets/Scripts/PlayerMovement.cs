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

    Vector3 banana;
    bool isGrounded;

    // Update is called once per frame

    private void Start()
    {
        
    }

    void Update()
    {
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
            if (this.GetComponent<CharacterController>().height > 1)
            {
                this.GetComponent<CharacterController>().height = this.GetComponent<CharacterController>().height - 0.1f;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {

            this.GetComponent<CharacterController>().height =


            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale + new Vector3 (0,transform.localScale.y,0), Quaternion.identity, 1 >> 8);
            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                //Output all of the collider names
                Debug.Log("Hit : " + hitColliders[i].name + i);
                //Increase the number of Colliders in the array
                i++;
            }
        }

        banana.y += gravity * Time.deltaTime;

        cc.Move(banana * Time.deltaTime);
    }
}
