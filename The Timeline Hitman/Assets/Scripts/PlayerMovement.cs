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

        banana.y += gravity * Time.deltaTime;

        cc.Move(banana * Time.deltaTime);
    }
}
