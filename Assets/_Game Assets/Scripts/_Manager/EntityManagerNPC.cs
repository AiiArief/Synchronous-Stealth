using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManagerNPC : EntityManager
{
    public override void SetupEntitiesOnLevelStart()
    {
        base.SetupEntitiesOnLevelStart();
        _AssignEnemiesToGrid();
        _SetNPCsIsActive();
    }

    private void _AssignEnemiesToGrid()
    {
        foreach(EntityCharacterNPC npc in entities)
        {
            npc.AssignToLevelGrid();
        }
    }

    private void _SetNPCsIsActive()
    {
        foreach (EntityCharacterNPC npc in entities)
        {
            npc.SetIsUpdateAble(true);
        }
    }
}
