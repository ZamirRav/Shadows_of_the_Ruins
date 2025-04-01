using UnityEngine;

public abstract class PlayerUnit : Unit
{
    protected override string GetEnemyBaseTag()
    {
        return "EnemyBase";
    }

    protected override string GetEnemyUnitTag()
    {
        return "EnemyUnit";
    }
}