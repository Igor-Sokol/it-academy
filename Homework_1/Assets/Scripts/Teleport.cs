using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private float spawnCooldown;
    [SerializeField]
    private float maxStep;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnCooldown)
        {
            Vector3 newPosition = new Vector3(
                this.transform.position.x + Random.Range(-maxStep, maxStep), 
                this.transform.position.y + Random.Range(-maxStep, maxStep), 
                this.transform.position.z + Random.Range(-maxStep, maxStep)
                );

            this.transform.position = newPosition;

            timer = 0;
        }
    }
}
