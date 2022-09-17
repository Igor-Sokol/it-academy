using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;

    public abstract void Shoot(Vector3 direction);
}
