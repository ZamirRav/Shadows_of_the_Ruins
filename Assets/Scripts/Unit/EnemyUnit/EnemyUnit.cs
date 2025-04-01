using UnityEngine;

public abstract class EnemyUnit : Unit
{
    protected override string GetEnemyBaseTag()
    {
        return "PlayerBase";
    }

    protected override string GetEnemyUnitTag()
    {
        return "PlayerUnit";
    }
}