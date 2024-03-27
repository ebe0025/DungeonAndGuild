using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;


    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();    
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {

        Movement();
    }

    private void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX < 0)
            renderer.flipX = true;
        else
            renderer.flipX = false;

        float inputY = Input.GetAxis("Vertical");
        Vector2 moveDir = new Vector2(inputX, inputY);
        moveDir.Normalize();
        animator.SetFloat("Speed", moveDir.magnitude);


        rb.velocity = moveDir * moveSpeed;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }
}
