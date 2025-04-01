using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public Text hpAmount;
    public float health = 1200;
    public GameObject endGamePanel;
    public PauseManager pauseManager;
    void Update()
    {
        hpAmount.text = Math.Round(health / 12).ToString();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            endGamePanel.SetActive(true);
            pauseManager.TogglePause();
        }
        hpAmount.text = Math.Round(health / 12).ToString();
    }
}
