using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private int direction;
    public int Direction => direction;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction = -direction;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
