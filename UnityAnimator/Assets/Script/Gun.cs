using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gun : MonoBehaviour
{
    private Animator _animator;
    
    private int IsAiming = Animator.StringToHash("isAiming");
    private int IsMoving = Animator.StringToHash("isMoving");

    private bool aiming;
    private bool moving;

    [SerializeField] private AnimationClip[] shootAnims;
    [SerializeField] private AnimationClip[] aimAnims;

    private int shootIndex = 0;
    private int aimIndex = 0;

    private AnimatorOverrideController animatorOverrideController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            aiming = !aiming;
            _animator.SetBool(IsAiming, aiming);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            
            aimIndex++;
            if (aimIndex >= aimAnims.Length)
            {
                aimIndex = 0;
            }

            animatorOverrideController["Aim"] = aimAnims[aimIndex];
            _animator.runtimeAnimatorController = animatorOverrideController;

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            
            shootIndex++;
            if (shootIndex >= shootAnims.Length)
            {
                shootIndex = 0;
            }
            
            animatorOverrideController["Shoot"] = shootAnims[shootIndex];
            _animator.runtimeAnimatorController = animatorOverrideController;
        }
    }

    public void SetMove(bool value)
    {
        if (moving == value) return;
        moving = value;
        _animator.SetBool(IsMoving, value);

    }
}
