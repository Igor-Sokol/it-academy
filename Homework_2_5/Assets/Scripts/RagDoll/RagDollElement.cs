using UnityEngine;
using UnityEngine.Events;

public class RagDollElement : MonoBehaviour
{
    private RagDollController _parent;
    private int _elementIndex;

    public event UnityAction<int, Collision> OnHit; 

    public void Init(RagDollController ragDollController, int index)
    {
        _parent = ragDollController;
        _elementIndex = index;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnHit?.Invoke(_elementIndex, collision);
    }
}
