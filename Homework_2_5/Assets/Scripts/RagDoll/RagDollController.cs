using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollController : MonoBehaviour
{
    private RagDollElement[] _elements;
    
    [SerializeField] private Rigidbody[] rigidbodyElements;
    [SerializeField] private Character player;

    private void Start()
    {
        Disable();
        CreateChildElements();
    }

    public void Enable()
    {
        foreach (var item in rigidbodyElements)
        {
            item.isKinematic = false;
        }
    }

    public void Disable()
    {
        foreach (var item in rigidbodyElements)
        {
            item.isKinematic = true;
        }
    }

    private void CreateChildElements()
    {
        _elements = new RagDollElement[rigidbodyElements.Length];
        for (int i = 0; i < rigidbodyElements.Length; i++)
        {
            var element = rigidbodyElements[i].gameObject.AddComponent<RagDollElement>();
            element.Init(this, i);
            element.OnHit += ElementHit;
            _elements[i] = element;
        }
    }
    
    private void ElementHit(int childIndex, Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Trap trap))
        {
            player.Die();
            UnsubscribeAllElementsEvent();
            DestroyElements();
        }
    }

    private void UnsubscribeAllElementsEvent()
    {
        foreach (var element in _elements)
        {
            element.OnHit -= ElementHit;
        }
    }

    private void DestroyElements()
    {
        foreach (var element in _elements)
        {
            Destroy(element);
        }

        _elements = null;
    }
}
