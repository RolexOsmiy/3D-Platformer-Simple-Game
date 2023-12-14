using System;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player touched the spikes, trigger death
            gameManager.PlayerDied();
        }
    }
}