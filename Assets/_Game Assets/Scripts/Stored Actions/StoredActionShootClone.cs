using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoredActionShootCloneActionEnum
{
    ShootClone, TeleportToClone, DismissClone
}

public class StoredActionShootClone : StoredAction
{
    public StoredActionShootClone(EntityCharacterPlayer player, StoredActionShootCloneActionEnum actionEnum = StoredActionShootCloneActionEnum.ShootClone)
    {
        ShootClone shootClone = player.playerShootClone;
        EntityManagerBullet bulletManager = GameManager.Instance.bulletManager;

        action = () => {
            if(!player.playerShootClone.enableShootClone)
            {
                actionHasDone = true;
                return;
            }

            if(!shootClone.CheckCloneHasBeenReleased())
            {
                shootClone.clone.transform.position = shootClone.crosshair.position;
                shootClone.clone.SetIsUpdateAble(true);
                bulletManager.AddBullet(shootClone.clone);

                actionHasDone = true;
                return;
            } else
            {
                if(actionEnum == StoredActionShootCloneActionEnum.TeleportToClone)
                {
                    LevelManager levelManager = GameManager.Instance.levelManager;
                    LevelGridNode currentNode = player.currentNode;

                    // belum ngecek ada orang apa engga gmana (panggil is walkable?), kalo celahnya sempit juga cek dulu
                    LevelGrid tempGrid = levelManager.GetClosestGridFromPosition(shootClone.clone.transform.position);
                    LevelGridNode tempNode = tempGrid.ConvertPosToNode(shootClone.clone.transform.position);
                    currentNode.entityListOnThisNode.Remove(player);
                    currentNode = tempNode;
                    player.AssignToLevelGrid(currentNode);

                    // cek y nya juga, kalo ada ceil atau ada orang gmana
                    Vector3 target = new Vector3(currentNode.realWorldPos.x, shootClone.clone.transform.position.y, currentNode.realWorldPos.z);
                    player.transform.position = target;

                    _DismissClone(bulletManager, shootClone);

                    actionHasDone = true;
                    return;
                }

                if (actionEnum == StoredActionShootCloneActionEnum.DismissClone)
                {
                    _DismissClone(bulletManager, shootClone);
                    actionHasDone = true;
                    return;
                }
            }
        };
    }

    private void _DismissClone(EntityManagerBullet bulletManager, ShootClone shootClone)
    {
        bulletManager.RemoveBullet(shootClone, shootClone.clone);
        shootClone.clone.SetIsUpdateAble(false);
        shootClone.clone.transform.position = shootClone.shootCloneSpawner.position;
        shootClone.clone.cameraLook.gameObject.SetActive(false);
    }
}
