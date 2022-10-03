using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isRunning;
    private Vector3 _targetPosition;
    
    [SerializeField] private Vector3 runDirection;
    [SerializeField] private float runDistance;
    [SerializeField] private float speed;

    private void Start()
    {
        _targetPosition = transform.position + runDirection * runDistance;
    }

    public void Run()
    {
        gameObject.SetActive(true);
        _isRunning = true;
    }

    public void Hide()
    {
        _isRunning = false;
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (_isRunning)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);

            if (transform.position == _targetPosition)
            {
                Hide();
            }
        }
    }
}
