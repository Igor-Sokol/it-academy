using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Door : MonoBehaviour
{
    private Transform _player;

    [SerializeField] private Vector3 closePosition;
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private float triggerRadius;

    private void Update()
    {
        if (_player)
        {
            float t = (closePosition - _player.position).magnitude / triggerRadius;
            transform.position = Vector3.Lerp(openPosition, closePosition, t);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _player = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        _player = null;
    }
}
