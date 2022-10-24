using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class NavMeshAreaSpeedMultiplier : MonoBehaviour
{
    private float _speedMultiplier;
    
    [SerializeField] private int areaIndex;
    
    private void Start()
    {
        this._speedMultiplier = NavMesh.GetAreaCost(areaIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.Speed /= _speedMultiplier;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.Speed *= _speedMultiplier;
        }
    }
}
