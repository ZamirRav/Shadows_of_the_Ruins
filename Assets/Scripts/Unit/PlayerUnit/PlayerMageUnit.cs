using UnityEngine;

public class PlayerMageUnit : PlayerUnit
{
    public GameObject magicProjectilePrefab;
    public Transform projectileSpawnPoint;
    protected override void AttackTarget()
    {
        if (targetUnit != null)
        {
            if (targetUnit.isDead)
            {
                targetUnit = null;
            }
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("2_Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void ShootMagicProjectile()
    {
        GameObject projectile = Instantiate(magicProjectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        MagicProjectile magicProjectile = projectile.GetComponent<MagicProjectile>();
        if (magicProjectile != null)
        {
            magicProjectile.tag1 = "EnemyUnit";
            magicProjectile.tag2 = "EnemyBase";
            magicProjectile.damage = damage;
            if (targetUnit != null)
            {
                magicProjectile.SetTarget(targetUnit.transform, "Unit");
                magicProjectile.parent = gameObject.GetComponent<Unit>();
            }
            else if (isBaseInRange)
            {
                magicProjectile.SetTarget(targetBase, "Base");
                magicProjectile.parent = gameObject.GetComponent<Unit>();
            }
            else
            {
                Destroy(magicProjectile.gameObject);
            }
        }
    }
}