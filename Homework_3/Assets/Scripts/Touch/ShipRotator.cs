using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotator : MonoBehaviour
{
    private Vector2 touchStartPosition;

    [SerializeField] private Transform shipContainer;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                shipContainer.rotation = Quaternion.Euler(0, this.touchStartPosition.x - touch.position.x, 0);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                shipContainer.rotation = Quaternion.identity;
            }
        }
    }
}
