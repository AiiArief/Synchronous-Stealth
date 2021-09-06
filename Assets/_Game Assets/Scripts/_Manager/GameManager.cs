﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] PhaseManager m_phaseManager;
    public PhaseManager phaseManager { get { return m_phaseManager; } }

    [SerializeField] EventManager m_eventManager;
    public EventManager eventManager { get { return m_eventManager; } }

    [SerializeField] EntityManagerPlayer m_playerManager;
    public EntityManagerPlayer playerManager { get { return m_playerManager; } }

    [SerializeField] EntityManagerEnemy m_enemyManager;
    public EntityManagerEnemy enemyManager { get { return m_enemyManager; } }

    [SerializeField] EntityManagerBullet m_bulletManager;
    public EntityManagerBullet bulletManager { get { return m_bulletManager; } }

    [SerializeField] LevelManager m_levelManager;
    public LevelManager levelManager { get { return m_levelManager; } }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        m_levelManager.SetupLevelOnLevelStart();
        m_playerManager.SetupEntitiesOnLevelStart();
        m_enemyManager.SetupEntitiesOnLevelStart();
        m_eventManager.SetupEventsOnLevelStart();
        m_phaseManager.SetPhase(PhaseEnum.WaitInput);
    }

    private void Update()
    {
        if (m_phaseManager.currentPhase != PhaseEnum.None)
            m_phaseManager.UpdateCurrentPhase();
    }
}
