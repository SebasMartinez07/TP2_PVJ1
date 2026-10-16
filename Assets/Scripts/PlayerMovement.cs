using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Settings")]
    [SerializeField] private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isStop=false;
    public bool IsStop
    {
        get {return isStop; }
        set { isStop=value; }
    }

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rb;

    [Header ("Raycast Settings")]
    [SerializeField]private bool isGrounded;

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

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }

    }

    private void FixedUpdate()
    {
        Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

    }
    private void CheckGround()
    {
        Vector3 origin = transform.position;
        isGrounded = Physics.Raycast(origin, Vector3.down, rayDistance, groundLayer);

        Color ColorRay = isGrounded ? Color.green : Color.red;

        Debug.DrawRay(origin,Vector3.down*rayDistance,ColorRay);
    }

    public void RotateCharacter(float rotateY)
    {
        transform.rotation = Quaternion.Euler(0f, rotateY, 0f);
    }


}
