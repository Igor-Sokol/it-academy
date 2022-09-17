using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : Bullet
{
    private const int PrimitiveMaskLayer = 1 << 8;

    [SerializeField] private float slopeDegree;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;

    public override void Shoot(Vector3 direction)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(direction.x, direction.y + slopeDegree / 90f, direction.z) * this.speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var targets = Physics.OverlapSphere(this.transform.position, this.explosionRadius, PrimitiveMaskLayer);

        foreach (var target in targets)
        {
            target.attachedRigidbody.AddForce((target.transform.position - this.transform.position).normalized * explosionForce);
        }

        Destroy(gameObject);
    }
}
