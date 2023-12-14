using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerController playerController;
    
    [SerializeField] private float restartDelay = 2f;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerDied()
    {
        // Handle player death (e.g., decrease lives, restart level, etc.)
        playerController.Death();
        DOVirtual.DelayedCall( restartDelay, RestartLevel);
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void InitPlayerController(PlayerController pc)
    {
        playerController = pc;
    }
}