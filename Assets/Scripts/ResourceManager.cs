using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public Text coinsAmount;
    public UnitSpawner unitSpawner;
    public PlayerBase playerBase;
    public Text upgradeCostText;
    public int playerResources = 0;
    private int enemyResources = 0;
    float resourceGainInterval = 0.47f;
    int resourceGainAmount = 1;
    int upgradeCost = 20;
    int upgradeIncrease = 15;
    int healCost = 50;
    float diff = 1f;
    int fightTimer;
    int upgradeCount;
    public GameObject berserkBtn, mageBtn, heavyKnightBtn, closeBerserkBtn, closeMageBtn, closeHeavyKnightBtn;
    private void Awake()
    {
        Time.timeScale = 1f;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        coinsAmount.text = playerResources.ToString();
    }
    private void Start()
    {
        if (GameSettings.IsDevilModOn)
        {
            diff = 5f;
            resourceGainAmount = 10;
            upgradeIncrease = 100;
            upgradeCost *= (int)diff;
        }
        if (GameSettings.IsToggleOn) resourceGainAmount = 1000;
        upgradeCostText.text = upgradeCost.ToString();
        StartCoroutine(GainResourcesOverTime());
        StartCoroutine(FightTimer());
        StartCoroutine(ShadowKnightSpawn());
        coinsAmount.text = playerResources.ToString();
    }

    private IEnumerator GainResourcesOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(resourceGainInterval);
            playerResources += resourceGainAmount;
            enemyResources += resourceGainAmount;
        }
    }

    private IEnumerator FightTimer()
    {
        bool phase1 = false, phase2 = false, phase3 = false;
        while (true)
        {
            yield return new WaitForSeconds(1);
            fightTimer++;
            if (fightTimer >= 20 / diff && !phase1)
            {
                resourceGainInterval = 0.45f;
                StartCoroutine(ShadowBerserkSpawn());
                phase1 = true;
            }
            if (fightTimer >= 30 / diff && !phase2)
            {
                resourceGainInterval = 0.43f;
                StartCoroutine(ShadowMageSpawn());
                phase2 = true;
                if(!GameSettings.IsDevilModOn) diff = 1.2f;
            }
            if (fightTimer >= 35 / diff && !phase3)
            {
                resourceGainInterval = 0.40f;
                StartCoroutine(ShadowHeavyKnightSpawn());
                phase3 = true;
                if(!GameSettings.IsDevilModOn) diff = 1.5f;
            }
        }
    }

    private IEnumerator ShadowKnightSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 8) / diff);
            unitSpawner.ShadowKnightSpawn();
        }
    }
    private IEnumerator ShadowBerserkSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 12) / diff);
            unitSpawner.ShadowBerserkSpawn();
        }
    }
    private IEnumerator ShadowMageSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10, 16) / diff);
            unitSpawner.ShadowMageSpawn();
        }
    }
    private IEnumerator ShadowHeavyKnightSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20, 38) / diff);
            unitSpawner.ShadowHeavyKnightSpawn();
        }
    }
    public void WalletUpgrade()
    {
        if (SpendPlayerResources(upgradeCost))
        {
            resourceGainAmount += 1 * (int)diff;
            upgradeCost += upgradeIncrease;
            upgradeCount++;
            upgradeCostText.text = upgradeCost.ToString();
        }
        if (upgradeCount == 1)
        {
            closeBerserkBtn.SetActive(false);
            berserkBtn.SetActive(true);
        }
        if (upgradeCount == 2)
        {
            closeMageBtn.SetActive(false);
            berserkBtn.SetActive(true);
        }
        if (upgradeCount == 3)
        {
            closeHeavyKnightBtn.SetActive(false);
            berserkBtn.SetActive(true);
        }
    }
    public void Heal()
    {
        if (SpendPlayerResources(healCost))
        {
            if (playerBase.health >= 90)
            {
                playerBase.health = 1200;
            }
            else
            {
                playerBase.health += 120;
            }
        }
    }


    public bool SpendPlayerResources(int amount)
    {
        if (playerResources >= amount)
        {
            playerResources -= amount;
            return true;
        }
        return false;
    }

    public bool SpendEnemyResources(int amount)
    {
        if (enemyResources >= amount)
        {
            enemyResources -= amount;
            return true;
        }
        return false;
    }
}
