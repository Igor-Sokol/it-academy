using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction PlayerDied = delegate { };
    
    public void Die()
    {
        PlayerDied?.Invoke();
    }
}
