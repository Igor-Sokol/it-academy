using UnityEngine;

public class CommonBullet : Bullet
{
    public override void Shoot(Vector3 direction)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(direction * this.speed);
    }

    protected override void OnHit(Collision collision)
    {
        
    }
}