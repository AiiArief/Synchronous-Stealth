using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseWaitInput : MonoBehaviour
{
    public void ActivateWaitInput()
    {
        gameObject.SetActive(true);

        GameManager.Instance.playerManager.SetupEntitiesOnWaitInputStart();
        GameManager.Instance.enemyManager.SetupEntitiesOnWaitInputStart();
        GameManager.Instance.bulletManager.SetupEntitiesOnWaitInputStart();
    }

    public void UpdateWaitInput()
    {
        bool playerManagerHasDoneInput = GameManager.Instance.playerManager.CheckEntitiesHasDoneWaitInput();
        bool enemyManagerHasDoneInput = GameManager.Instance.enemyManager.CheckEntitiesHasDoneWaitInput();
        bool bulletManagerHasDoneInput = GameManager.Instance.bulletManager.CheckEntitiesHasDoneWaitInput();

        if(playerManagerHasDoneInput && enemyManagerHasDoneInput && bulletManagerHasDoneInput)
        {
            GameManager.Instance.phaseManager.SetPhase(PhaseEnum.ProcessInput);
        }
    }
}
