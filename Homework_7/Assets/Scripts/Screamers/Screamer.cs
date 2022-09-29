using UnityEngine;

public abstract class Screamer : MonoBehaviour
{
    public void Hide()
    {
        Destroy(gameObject);
    }
}
