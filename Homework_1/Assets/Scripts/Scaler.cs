using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private Vector3 expectedScale;

    [SerializeField]
    private float secondsToScale;

    private Vector3 startScale;
    private float Timer = 0;

    private void Start()
    {
        this.startScale = this.transform.localScale;
    }

    private void Update()
    {
        this.Timer += Time.deltaTime;

        this.transform.localScale = Vector3.Lerp(this.startScale, this.expectedScale, this.Timer / this.secondsToScale);
    }
}
