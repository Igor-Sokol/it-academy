using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;

    [SerializeField]
    private Vector3[] points;

    private int currentTrackedPoint;

    void Update()
    {
        Vector3 moveTowards = this.points[this.currentTrackedPoint] - this.transform.position;

        if (moveTowards.sqrMagnitude > 0.1f)
        {
            this.transform.transform.Translate(moveTowards.normalized * this.speed * Time.deltaTime);
        }
        else
        {
            if (this.currentTrackedPoint == this.points.Length - 1)
            {
                this.currentTrackedPoint = 0;
            }
            else
            {
                this.currentTrackedPoint++;
            }
        }
    }
}
