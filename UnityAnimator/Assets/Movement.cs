using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D m_Rigid;
    private Animator m_Animator;
    private Transform m_Transform;
    
    [SerializeField] private float moveSpeed = 10f;
    private readonly float chrouchSpeed = 0.5f;
    
    private bool m_IsChrouch = false;
    private bool m_IsFlipped = false;
    
    private readonly int m_Speed = Animator.StringToHash("Speed");
    private readonly int m_Chrouch = Animator.StringToHash("Chrouch");
    private readonly int m_Jump = Animator.StringToHash("Jump");

    private void Awake()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Transform = transform;
    }

    private void FixedUpdate()
    {
        var moveX = Input.GetAxis("Horizontal");
        m_IsChrouch = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKeyDown(KeyCode.J))
        {
            m_Animator.SetTrigger(m_Jump);
        }

        var speedDown = m_IsChrouch ? chrouchSpeed : 1;

        m_Rigid.velocity = new Vector2(moveX * moveSpeed * speedDown, m_Rigid.velocity.y);

        if (moveX < 0 && !m_IsFlipped)
        {
            Flip();
            m_IsFlipped = true;
        }

        if (moveX > 0 && m_IsFlipped)
        {
            Flip();
            m_IsFlipped = false;
        }
        
        m_Animator.SetFloat(m_Speed, Mathf.Abs(moveX));
        m_Animator.SetBool(m_Chrouch, m_IsChrouch);
    }

    private void Flip()
    {
        Vector3 scale = m_Transform.localScale;
        scale.x *= -1;
        m_Transform.localScale = scale;
    }
}
