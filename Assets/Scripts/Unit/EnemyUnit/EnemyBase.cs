using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public Text hpAmount;
    private float health = 1500;
    public GameObject endGamePanel;
    public PauseManager pauseManager;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            endGamePanel.SetActive(true);
            pauseManager.TogglePause();
        }
        hpAmount.text = Math.Round(health / 15).ToString();
    }
}
