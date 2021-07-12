using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManagerBullet : EntityManager
{
    public void AddBullet(EntityBullet bullet)
    {
        bullet.transform.SetParent(transform, true);

        _AssignEntities();
    }

    public void RemoveBullet(ShootClone shootClone, EntityBullet bullet)
    {
        bullet.transform.SetParent(shootClone.shootCloneSpawner, false);

        _AssignEntities();
    }

    protected override void _AssignEntities()
    {
        entities.Clear();

        foreach (Transform child in transform)
        {
            Entity entity = child.GetComponent<Entity>();
            if (entity)
            {
                entities.Add(entity);
            }
        }
    }
}
