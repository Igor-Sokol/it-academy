using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected ParticleSystem hitParticle;

    public abstract void Shoot(Vector3 direction);

    protected abstract void OnHit(Collision collision);

    private void OnCollisionEnter(Collision collision)
    {
        SpawnParticle(hitParticle);
        OnHit(collision);
    }

    protected void SpawnParticle(ParticleSystem particle)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
