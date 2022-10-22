using System.Collections;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private int _spawnPointIndex = 0;
    private Block _currentBlock;
    private Block _previousBlock;

    [SerializeField] private Block startBlock;
    [SerializeField] private Transform container;
    [SerializeField] private Block prefab;
    [SerializeField] private SpawnPoint[] spawnPoints;

    private void Start()
    {
        _previousBlock = startBlock;
        SpawnBlock();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _currentBlock.Cut(_previousBlock.savedPart.transform.position);
            _previousBlock = _currentBlock;
            StartCoroutine(SpawnNewBlock());
        }
    }

    private void SpawnBlock()
    {
        if (_spawnPointIndex >= spawnPoints.Length)
        {
            _spawnPointIndex = 0;
        }

        Quaternion rotation = Quaternion.Euler(spawnPoints[_spawnPointIndex].Rotation);
        Vector3 position = spawnPoints[_spawnPointIndex].Position;
        position += new Vector3(_previousBlock.savedPart.transform.position.x, 0, _previousBlock.savedPart.transform.position.z);
        
        _currentBlock = Instantiate(prefab, position, rotation, container);
        _currentBlock.MoveDirection = spawnPoints[_spawnPointIndex].MoveDirection;
        _currentBlock.Scale = new Vector3(_previousBlock.Scale.z, 1, _previousBlock.Scale.x);

        _spawnPointIndex++;
    }

    private IEnumerator SpawnNewBlock()
    {
        yield return new WaitForSeconds(2);
        container.transform.position += Vector3.down;
        SpawnBlock();
    }
}
