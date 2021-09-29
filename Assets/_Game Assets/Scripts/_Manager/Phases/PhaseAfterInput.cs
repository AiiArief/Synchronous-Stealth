﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseAfterInput : MonoBehaviour
{
    public void ActivateAfterInput()
    {
        gameObject.SetActive(true);

        GameManager.Instance.playerManager.SetupEntitiesOnAfterInputStart();
        GameManager.Instance.npcManager.SetupEntitiesOnAfterInputStart();
        GameManager.Instance.bulletManager.SetupEntitiesOnAfterInputStart();
        GameManager.Instance.eventManager.SetupEntitiesOnAfterInputStart();
    }

    public void UpdateAfterInput()
    {
        bool playerManagerHasDoneAfterInput = GameManager.Instance.playerManager.CheckEntitiesHasDoneAfterInput();
        bool enemyManagerHasDoneAfterInput = GameManager.Instance.npcManager.CheckEntitiesHasDoneAfterInput();
        bool bulletManagerHasDoneAfterInput = GameManager.Instance.bulletManager.CheckEntitiesHasDoneAfterInput();
        bool eventManagerHasDoneAfterInput = GameManager.Instance.eventManager.CheckEntitiesHasDoneAfterInput();

        if (playerManagerHasDoneAfterInput && enemyManagerHasDoneAfterInput && bulletManagerHasDoneAfterInput && eventManagerHasDoneAfterInput)
        {
            GameManager.Instance.phaseManager.SetPhase(PhaseEnum.WaitInput);
        }
    }
}
