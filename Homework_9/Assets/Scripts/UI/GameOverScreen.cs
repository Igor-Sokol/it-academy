using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField] private Player player;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameRestart gameRestart;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        player.PlayerDied += OnPlayerDied;
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        player.PlayerDied -= OnPlayerDied;
        restartButton.onClick.RemoveListener(RestartGame);
    }

    private void OnPlayerDied()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void RestartGame()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        
        gameRestart.Restart();
    }
}
