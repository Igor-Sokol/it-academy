using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrap : Trap
{
    private Vector3 _startEnemyPosition;
    
    [SerializeField] private Enemy enemy;

    protected override void Start()
    {
        _startEnemyPosition = enemy.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            enemy.Run();
        }
    }

    public override void Reload()
    {
        enemy.Hide();
        enemy.transform.position = _startEnemyPosition;
    }
}
