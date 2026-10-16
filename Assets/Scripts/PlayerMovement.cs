using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    /*
    [Header ("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rb;

    [Header("Raycast Settings")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        CheckGround();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal * -1, 0.0f, moveVertical * -1).normalized;
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
        //rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
    }

    private void CheckGround()
    {
        Vector3 origin = transform.position;
        isGrounded = Physics.Raycast(origin, Vector3.down, rayDistance, groundLayer);

        Color coloRay;
        if(isGrounded)
        {
            coloRay = Color.green;
        }
        else
        {
            coloRay = Color.red;
        }

        Color ColorRay = isGrounded ? Color.green : Color.red;
        Debug.DrawRay(origin, Vector3.down * rayDistance, ColorRay);
    }
    */
}
