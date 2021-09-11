using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBulletClone : EntityBullet
{
    [SerializeField] EntityCharacterPlayer m_player;

    [SerializeField] CameraLook m_cameraLook;
    public CameraLook cameraLook { get { return m_cameraLook; } }

    public override void SetupWaitInput()
    {
        base.SetupWaitInput();
        cameraLook.gameObject.SetActive(true);
    }

    public override void WaitInput()
    {
        // handle camera wait input
        m_cameraLook.CloneCameraWaitInput(m_player.playerCameraLook);

        if (!m_player.isUpdateAble)
            storedActions.Add(new StoredActionSkip());

        if (m_player.isUpdateAble && m_player.storedActions.Count > 0)
        {
            // cek kalo player udah wait input
            storedActions.Add(new StoredActionSkip());
            storedActions.Add(new StoredActionCameraLook(m_player, m_cameraLook));
        }
    }
}
