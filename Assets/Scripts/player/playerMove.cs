using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController controler;

    public float x;
    public float z;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 12.0f;
    public float BaseSpeed = 12.0f;
    public float SprintSpeed = 12.0f;
    public float StrafeSpeed = 12.0f;


    public float gravity = -9.80655f;

    public float jumpHeight = 3.0f;

    Vector3 velocity;
    public bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * x + transform.forward * z;

        if (Input.GetButton("Sprint") == true)
        {
            speed = SprintSpeed;
        }
        else 
        {
            speed = BaseSpeed;
        }

        if (GameObject.Find("spawner").GetComponent<spawner>().currentGameSatae == spawner.gamestate.wave && Input.GetButton("Fire2") == true)
        {
            speed = StrafeSpeed;
        }

        controler.Move(Move.normalized * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controler.Move(velocity * Time.deltaTime);
    }
}
