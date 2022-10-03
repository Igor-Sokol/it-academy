using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Player player;
    [SerializeField] private Transform border;

    private void Start()
    {
        Vector3 borderStartPosition = playerCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));
        border.transform.position = borderStartPosition;
    }

    private void Update()
    {
        Vector3 playerScreenPoint = playerCamera.WorldToViewportPoint(player.transform.position);
        if (playerScreenPoint.x > 0.5f)
        {
            var position = playerCamera.transform.position;
            position = new Vector3(player.transform.position.x, position.y, position.z);
            playerCamera.transform.position = position;
        }
    }
}
