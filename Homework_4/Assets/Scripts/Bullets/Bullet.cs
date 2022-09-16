using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;

    public abstract void Shoot(Vector3 direction);

    //this.gameObject.GetComponent<Rigidbody>().AddForce(direction* this.speed* 300f);
}