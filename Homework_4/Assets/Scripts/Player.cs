using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Gun gun;

    public Gun Gun => this.gun;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gun.Shoot();
        }
    }
}
