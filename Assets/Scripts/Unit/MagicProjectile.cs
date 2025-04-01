using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float speed = 10f; // Скорость движения
    public int damage; // Урон
    public float lifetime = 5f; // Время жизни эффекта
    public string tag1, tag2;
    private Transform target; // Цель (вражеский юнит или база)
    private Rigidbody2D rb;
    private Unit targetUnit;
    public Unit parent;
    private string targetType;
    private string baseType = "Base";
    private string unitType = "Unit";
    void Start()
    {
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(-0.5f, 0.2f);
    }

    void Update()
    {
        if (target != null)
        {
            if (targetType == unitType)
            {
                if (targetUnit.isDead)
                {
                    Destroy(gameObject);
                }
                transform.position = Vector2.MoveTowards(transform.position, target.position + new Vector3(0, 0.5f), speed * Time.deltaTime);
            }
            else if (targetType == baseType)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position + new Vector3(0, 0.5f), speed * Time.deltaTime);
            }


        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget, string type)
    {
        targetType = type;
        target = newTarget;
        if (targetType == baseType)
        {

        }
        if (targetType == unitType)
        {
            targetUnit = target.GetComponent<Unit>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag(tag1) || collision.CompareTag(tag2)) && (collision.gameObject.name == target.gameObject.name))
        {
            if (targetType == unitType)
            {
                Unit unit = collision.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.TakeDamage(damage);
                    if (unit.isDead)
                    {
                        targetUnit = null;
                        parent.targetUnit = null;

                    }
                }
            }
            if (targetType == baseType)
            {
                if (parent.CompareTag("PlayerUnit"))
                {
                    target.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
                }
                if (parent.CompareTag("EnemyUnit"))
                {
                    target.gameObject.GetComponent<PlayerBase>().TakeDamage(damage);
                }
            }


            Destroy(gameObject);
        }
    }
}