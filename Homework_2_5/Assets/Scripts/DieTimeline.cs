using System;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class DieTimeline : MonoBehaviour
{
    private PlayableDirector _playableDirector;
    
    [SerializeField] private Character player;

    private void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        player.OnDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        player.OnDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _playableDirector.Play();
    }
}
