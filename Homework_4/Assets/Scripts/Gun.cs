using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    public void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
        bullet.Shoot(this.transform.forward);
    }

    public void ChangeBullet(Bullet newBullet)
    {
        this.bulletPrefab = newBullet;
    }
}
