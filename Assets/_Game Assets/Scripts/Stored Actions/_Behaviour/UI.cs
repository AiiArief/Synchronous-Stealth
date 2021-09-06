using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] UIDialogue m_uiDialogue;
    public UIDialogue UIDialogue { get { return m_uiDialogue; } }

    [Header("Optional")]
    [SerializeField] UIShoot m_uiShoot;
    public UIShoot UIShoot { get { return m_uiShoot; } }

    [SerializeField] Camera m_uiCamera;
    public Camera UICamera { get { return m_uiCamera; } }

    // handle player ui shoot
    public void AddDialogue(DialogueString dialogueString)
    {
        UIDialogue.dialogueStrings.Add(dialogueString);
    }
}
