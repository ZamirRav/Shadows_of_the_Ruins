using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Transform tKnight, tBerserk, tMage, tHeavyKnight,
    tShadowKnight, tShadowBerserk, tShadowMage, tShadowHeavyKnight;
    public GameObject knightPrefab, berserkPrefab, magePrefab, heavyKnightPrefab,
    shadowKnightPrefab, shadowBerserkPrefab, shadowMagePrefab, shadowHeavyKnightPrefab;

    public ResourceManager rm;

    public void KnightSpawn()
    {
        if (rm.SpendPlayerResources(8))
        {
            GameObject knight = Instantiate(knightPrefab, tKnight.position, Quaternion.identity);
        }
    }
    public void BerserkSpawn()
    {
        if (rm.SpendPlayerResources(10))
        {
            GameObject berserk = Instantiate(berserkPrefab, tBerserk.position, Quaternion.identity);
        }
    }
    public void MageSpawn()
    {
        if (rm.SpendPlayerResources(16))
        {
            GameObject mage = Instantiate(magePrefab, tMage.position, Quaternion.identity);
        }
    }
    public void HeavyKnightSpawn()
    {
        if (rm.SpendPlayerResources(38))
        {
            GameObject hKnight = Instantiate(heavyKnightPrefab, tHeavyKnight.position, Quaternion.identity);
        }
    }
    public void ShadowKnightSpawn()
    {
        GameObject knight = Instantiate(shadowKnightPrefab, tShadowKnight.position, Quaternion.identity);
    }
    public void ShadowBerserkSpawn()
    {
        GameObject berserk = Instantiate(shadowBerserkPrefab, tShadowBerserk.position, Quaternion.identity);
    }
    public void ShadowMageSpawn()
    {
        GameObject mage = Instantiate(shadowMagePrefab, tShadowMage.position, Quaternion.identity);
    }
    public void ShadowHeavyKnightSpawn()
    {

        GameObject hKnight = Instantiate(shadowHeavyKnightPrefab, tShadowHeavyKnight.position, Quaternion.identity);
    }
}
