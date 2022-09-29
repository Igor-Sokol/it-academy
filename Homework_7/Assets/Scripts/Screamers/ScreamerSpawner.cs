using UnityEngine;

public class ScreamerSpawner : MonoBehaviour
{
    private float _timer;
    private float _timeToSpawn;

    [SerializeField] private GameObject[] screamerPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float minDistanceFromPlayer;
    [SerializeField] private float maxDistanceFromPlayer;

    private void Start()
    {
        _timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToSpawn)
        {
            Vector3 position = Random.insideUnitSphere * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
            Instantiate(screamerPrefabs[Random.Range(0, screamerPrefabs.Length)], position, Quaternion.identity, transform);
            
            _timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            _timer = 0;
        }
    }
}
