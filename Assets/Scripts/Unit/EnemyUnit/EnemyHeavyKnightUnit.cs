using UnityEngine;

public class EnemyHeavyKnightUnit : EnemyUnit
{
    protected override void AttackTarget()
    {
        if (targetUnit != null)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("2_Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void DealDamage()
    {
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(damage);
            if (targetUnit.isDead)
            {
                targetUnit = null;
            }
        }
        if (isBaseInRange)
        {
            targetBase.gameObject.GetComponent<PlayerBase>().TakeDamage(damage);
        }
        FindEnemyUnits();
    }
}