using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct SpawnPoint
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [FormerlySerializedAs("direction")] [SerializeField] private Vector3 moveDirection;

    public Vector3 Position => position;
    public Vector3 Rotation => rotation;
    public Vector3 MoveDirection => moveDirection;
}
