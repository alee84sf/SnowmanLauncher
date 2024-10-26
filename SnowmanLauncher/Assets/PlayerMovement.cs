using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private float xMovement;
    private float yMovement;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checking for movement
        //Referred to this video: https://www.youtube.com/watch?v=u8tot-X_RBI

        //more info on GetAxisRaw https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(xMovement, yMovement).normalized;
    }

    private void FixedUpdate()
    {
        //TODO: Add a "movementEnabled" bool so I can disable movement while the control panel is open

        //FixedUpdate for moving since Update is frame-dependent
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
