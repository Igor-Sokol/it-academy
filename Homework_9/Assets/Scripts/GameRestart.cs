using System;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    private Trap[] _traps;

    private Vector3 _playerStartPosition;
    private Vector3 _playerCameraStartPosition;
    
    [SerializeField] private Player player;
    [SerializeField] private Camera playerCamera;
    
    public void Restart()
    {
        player.transform.position = _playerStartPosition;
        playerCamera.transform.position = _playerCameraStartPosition;

        foreach (var trap in _traps)
        {
            trap.Reload();
        }
        
        Time.timeScale = 1;
    }
    
    private void Start()
    {
        _traps = FindObjectsOfType<Trap>();

        _playerStartPosition = player.transform.position;
        _playerCameraStartPosition = playerCamera.transform.position;
    }

    private void OnEnable()
    {
        player.PlayerDied += OnGameEnd;
    }

    private void OnDisable()
    {
        player.PlayerDied -= OnGameEnd;
    }

    private void OnGameEnd()
    {
        Time.timeScale = 0;
    }
}
