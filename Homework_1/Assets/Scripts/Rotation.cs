using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 RotateDirection;

    [SerializeField]
    private int speed;

    void Update()
    {
        this.transform.Rotate(this.RotateDirection * this.speed * Time.deltaTime);
    }
}
