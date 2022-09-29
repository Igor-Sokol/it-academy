using System;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private float _yTeleportDistance;

    private void OnTriggerEnter(Collider other)
    {
        var newPosition = other.transform.position;
        newPosition = new Vector3(newPosition.x, newPosition.y + _yTeleportDistance, newPosition.z);
        
        other.transform.position = newPosition;
    }
}
