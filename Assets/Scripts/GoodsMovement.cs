using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMovement : MonoBehaviour
{
    [SerializeField] private GameObject _bake;
    [SerializeField] private SpriteRenderer _bakeSpriteRenderer;
    private bool _isRotateBake = false;

    private void Start()
    {
        _bake = GameObject.FindGameObjectWithTag("Bake");
        if (_bake != null)
        {
            _bakeSpriteRenderer = _bake.GetComponent<SpriteRenderer>();
        }
    }
    
    public void RotateBake()
    {
        _isRotateBake = !_isRotateBake;
        _bakeSpriteRenderer.flipX = _isRotateBake;
    }
}
