﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private Vector3 m_currentCameraRot;
    public Vector3 currentCameraRot { get { return m_currentCameraRot; } }

    [SerializeField] Camera m_playerCamera;
    public Camera playerCamera { get { return m_playerCamera; } }

    [SerializeField] Vector2 m_xRotClamp = new Vector2(-60.0f, 90.0f);

    public void HandleCameraWaitInput(float camH, float camV)
    {
        m_currentCameraRot.y = Mathf.Repeat(m_currentCameraRot.y + camH, 360);
        m_currentCameraRot.x = Mathf.Clamp(m_currentCameraRot.x - camV, m_xRotClamp.x, m_xRotClamp.y);

        transform.rotation = Quaternion.Euler(m_currentCameraRot.x, m_currentCameraRot.y, 0.0f);
    }

    public void CloneCameraWaitInput(CameraLook copyCameraLook)
    {
        transform.rotation = copyCameraLook.transform.rotation;
    }
}
