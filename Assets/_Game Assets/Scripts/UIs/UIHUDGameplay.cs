using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDGameplay : MonoBehaviour
{
    // handle player status hudnya gmana
    // handle crosshair, ammo, camera bullet, dll

    [SerializeField] GameObject m_uiShoot;
    [SerializeField] GameObject m_uiShoot_crosshair;
    [SerializeField] Text m_uiShoot_ammo;
    //[SerializeField] Image m_transitionImage;

    // transisi?
    public void SetEnableShootUI(bool enable)
    {
        m_uiShoot.gameObject.SetActive(enable);
    }
}
