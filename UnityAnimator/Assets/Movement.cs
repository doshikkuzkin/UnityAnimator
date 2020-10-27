using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    
    [SerializeField] private float moveSpeed = 10f;
    private float chrouchSpeed = 0.5f;
    
    private bool isChrouch = false;
    private bool isFlipped = false;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Chrouch = Animator.StringToHash("Chrouch");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        var moveX = Input.GetAxis("Horizontal");
        isChrouch = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger(Jump);
        }

        var speedDown = isChrouch ? chrouchSpeed : 1;

        rigid.velocity = new Vector2(moveX * moveSpeed * speedDown, rigid.velocity.y);

        if (moveX < 0 && !isFlipped)
        {
            Flip();
            isFlipped = true;
        }

        if (moveX > 0 && isFlipped)
        {
            Flip();
            isFlipped = false;
        }
        
        animator.SetFloat(Speed, Mathf.Abs(moveX));
        animator.SetBool(Chrouch, isChrouch);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
}
