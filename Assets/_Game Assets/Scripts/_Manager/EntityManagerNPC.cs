using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManagerNPC : EntityManager
{
    public int maxAlertLevel = 15;

    public override void SetupEntitiesOnLevelStart()
    {
        base.SetupEntitiesOnLevelStart();
        _AssignEnemiesToGrid();
    }

    private void _AssignEnemiesToGrid()
    {
        foreach(EntityCharacterNPC npc in entities)
        {
            npc.AssignToLevelGrid();
        }
    }
}
