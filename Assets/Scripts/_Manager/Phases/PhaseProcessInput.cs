﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseProcessInput : MonoBehaviour
{
    [SerializeField] float m_minimumTimeBeforeNextPhase = 0.25f;
    public float minimumTimeBeforeNextPhase { get { return m_minimumTimeBeforeNextPhase; } }
    public float currentTimeBeforeNextPhase { get; private set; } = 0.0f;

    public void ActivateProcessInput()
    {
        gameObject.SetActive(true);

        currentTimeBeforeNextPhase = 0.0f;
        GameManager.Instance.playerManager.SetupEntitiesOnProcessInputStart();
        GameManager.Instance.enemyManager.SetupEntitiesOnProcessInputStart();
    }

    public void UpdateProcessInput()
    {
        bool playerManagerHasDoneProcess = GameManager.Instance.playerManager.CheckEntitiesHasDoneProcessInput();
        bool enemyManagerHasDoneProcess = GameManager.Instance.enemyManager.CheckEntitiesHasDoneProcessInput();

        currentTimeBeforeNextPhase += Time.deltaTime;
        bool timeHasPassed = currentTimeBeforeNextPhase >= m_minimumTimeBeforeNextPhase;

        if (timeHasPassed && playerManagerHasDoneProcess && enemyManagerHasDoneProcess)
        {
            GameManager.Instance.phaseManager.SetPhase(PhaseEnum.AfterInput);
        }
    }
}
