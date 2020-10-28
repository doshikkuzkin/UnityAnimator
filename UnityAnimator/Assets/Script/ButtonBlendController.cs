using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class ButtonBlendController : MonoBehaviour
{
    [SerializeField] private Slider colorS;
    [SerializeField] private Slider scaleS;
    [SerializeField] private Slider moveS;
    
    private Animator m_Animator;
    private readonly int Color = Animator.StringToHash("Color");
    private readonly int Scale = Animator.StringToHash("Scale");
    private readonly int Move = Animator.StringToHash("Move");

    [SerializeField] private Animator animatorB;
    
    private readonly int ColorB = Animator.StringToHash("ColorB");
    private readonly int ScaleB = Animator.StringToHash("ScaleB");

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        colorS.onValueChanged.AddListener(value =>
        {
            m_Animator.SetFloat(Color, value);
        });
        
        scaleS.onValueChanged.AddListener(value =>
        {
            m_Animator.SetFloat(Scale, value);
        });
        
        moveS.onValueChanged.AddListener(value =>
        {
            m_Animator.SetFloat(Move, value);
        });
    }

    public void SetValues()
    {
        var color = Random.Range(0f, 1f);
        var scale = Random.Range(0f, 1f);
        var move = Random.Range(0f, 1f);

        colorS.value = color;
        scaleS.value = scale;
        moveS.value = move;
    }

    public void SetButtonValues()
    {
        var color = Random.Range(0f, 1f);
        var scale = Random.Range(0f, 1f);
        
        animatorB.SetFloat(ColorB, color);
        animatorB.SetFloat(ScaleB, scale);
    }
}
