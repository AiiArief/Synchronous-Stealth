using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoredActionShootCloneActionEnum
{
    ShootClone, TeleportToClone, DismissClone
}

public class StoredActionShootClone : StoredAction
{
    public StoredActionShootClone(EntityPlayer player, StoredActionShootCloneActionEnum actionEnum = StoredActionShootCloneActionEnum.ShootClone)
    {
        ShootClone shootClone = player.playerShootClone;
        EntityManagerBullet bulletManager = GameManager.Instance.bulletManager;
        LevelGrid currentGrid = GameManager.Instance.levelManager.grid;
        LevelGridNode currentNode = player.currentNode;

        action = () => {
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
                    // ngecek ada orang apa engga gmana ga tau, kalo celahnya sempit juga cek dulu
                    LevelGridNode tempNodePos = currentGrid.ConvertPosToGrid(shootClone.clone.transform.position);
                    currentNode.entityListOnThisNode.Remove(player);
                    currentNode = currentGrid.gridNodes[tempNodePos.x, tempNodePos.y];
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
