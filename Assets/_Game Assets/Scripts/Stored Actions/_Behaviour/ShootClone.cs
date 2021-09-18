using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootClone : MonoBehaviour
{
    public bool enableShootClone = true;

    [SerializeField] Transform m_shootCloneSpawner;
    public Transform shootCloneSpawner { get { return m_shootCloneSpawner; } }

    [SerializeField] EntityBulletClone m_clone;
    public EntityBulletClone clone { get { return m_clone; } }

    [SerializeField] Transform m_crosshair;
    public Transform crosshair { get { return m_crosshair; } }

    [SerializeField] float m_maxBulletRange = 1000.0f;

    public void HandleCrosshairWaitInput(CameraLook playerCameraLook)
    {
        if(!CheckCloneHasBeenReleased())
        {
            RaycastHit hit;
            Vector3 resultHit = Vector3.zero;

            bool isHit = Physics.Raycast(playerCameraLook.transform.position + playerCameraLook.transform.forward, playerCameraLook.transform.forward, out hit, m_maxBulletRange, -1, QueryTriggerInteraction.Ignore);
            if (isHit)
            {
                resultHit = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z));
                // mungkin cek dulu itu pas di round perlu tambahin normal apa engga
                resultHit = new Vector3(resultHit.x + hit.normal.x, resultHit.y, resultHit.z + hit.normal.z);
            }

            m_crosshair.gameObject.SetActive(isHit);
            m_crosshair.position = resultHit;

            // ntar butuh cek, hit siapa
            // ga aktif kalo hit tempatnya entity lain
        }
    }

    public bool CheckCloneHasBeenReleased()
    {
        return m_clone.transform.parent != m_shootCloneSpawner;
    }

    public bool CheckAbleToShoot()
    {
        return !CheckCloneHasBeenReleased() && crosshair.gameObject.activeSelf;
    }

    public void DisableCrosshair()
    {
        m_crosshair.gameObject.SetActive(false);
    }
}
