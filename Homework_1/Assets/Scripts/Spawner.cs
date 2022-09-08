using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;

    private GameObject instance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.prefabs.Length == 0)
            {
                Debug.LogError("Prefabs not found");
            }
            if (this.instance != null)
            {
                Destroy(this.instance);
            }

            Quaternion rotation = Quaternion.identity;
            Vector3 position = Vector3.zero;

            GameObject prefab = this.prefabs[Random.Range(0, prefabs.Length)];
            this.instance = Instantiate(prefab, position, rotation);
        }
    }
}
