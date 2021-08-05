using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBall : MonoBehaviour
{
    private Rigidbody rb;
    private float hozInput, vertInput;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpForce = 8;
    private bool isJumpButtonPressed = false;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hozInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpButtonPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(hozInput, 0, vertInput);
        playerMovement *= speed;
        rb.AddForce(playerMovement,ForceMode.Acceleration);

        //create a new ray, it's center is the player's position, it's direction is Vector3.down
        Ray ray = new Ray(transform.position, Vector3.down);
        //Physics.Raycast will return true if the ray hits a collider
        //send the ray and check if it did hit anything, the ray length is going to be half of our scale(player's)
        //plus a small value to make sure our ray is barely longer than the player's radius.
        
        if(Physics.Raycast(ray,transform.localScale.x / 2f + 0.01f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isJumpButtonPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isJumpButtonPressed = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    isGrounded = true;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    isGrounded = false;
    //}
}
