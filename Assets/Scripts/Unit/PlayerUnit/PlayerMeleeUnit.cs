using UnityEngine;

public class PlayerMeleeUnit : PlayerUnit
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
        if(targetUnit != null){
            targetUnit.TakeDamage(damage);
            if (targetUnit.isDead){
                targetUnit = null;
            }
        }
        if (isBaseInRange){
            targetBase.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }
        FindEnemyUnits();
    }
}