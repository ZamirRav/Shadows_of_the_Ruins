using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public float speed = 2f;
    public int health = 100;
    public int damage = 10;
    public float attackRange = 1f;
    public float attackRate = 1f;
    protected Transform targetBase;
    public Unit targetUnit;
    protected float nextAttackTime;
    public bool isDead = false;
    protected bool isBaseInRange;
    protected Animator animator;
    protected abstract string GetEnemyBaseTag();
    protected abstract string GetEnemyUnitTag();

    void Start()
    {
        animator = GetComponent<Animator>();
        targetBase = GameObject.FindWithTag(GetEnemyBaseTag()).transform;
    }

    void Update()
    {
        if (isDead) return;
        if (targetBase == null) return;
        FindEnemyUnits();

        if (targetUnit != null)
        {
            animator.SetBool("1_Move", false);
            AttackTarget();
        }
        else if (isBaseInRange)
        {
            animator.SetBool("1_Move", false);
            AttackBase();
        }
        else
        {
            MoveToBase();
            animator.SetBool("1_Move", true);
        }

    }

    void MoveToBase()
    {
        // Движение к вражеской базе
        transform.position = Vector2.MoveTowards(transform.position * new Vector2(1, 0), targetBase.position * new Vector2(1, 0), speed * Time.deltaTime);
        FindEnemyUnits();

    }

    public void FindEnemyUnits()
    {
        // Ищем вражеских юнитов в радиусе атаки
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange * 0.6f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag(GetEnemyUnitTag()))
            {
                var unit = hit.GetComponent<Unit>();
                if (!unit.isDead && unit != null)
                {
                    targetUnit = unit;
                    break;
                }
            }
            if (hit.CompareTag(GetEnemyBaseTag()))
            {
                isBaseInRange = true;
            }
        }
    }

    // Абстрактный метод для атаки (будет реализован в дочерних классах)
    protected abstract void AttackTarget();
    protected virtual void AttackBase()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("2_Attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("3_Death");
        gameObject.layer = LayerMask.NameToLayer("DeadUnits");
        enabled = false;
    }

    public void UnitDelete()
    {
        Destroy(gameObject);
    }
}