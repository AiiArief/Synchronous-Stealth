using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent: Entity
{
    public virtual void EventOnLoadLevel()
    {
    }

    protected void _SendDialogueToMainPlayer(DialogueString playerDialogue)
    {
        EntityManagerEvent eventManager = GameManager.Instance.eventManager;
        EntityManagerPlayer playerManager = GameManager.Instance.playerManager;
        EntityCharacterPlayer mainPlayer = playerManager.GetPlayerPlayableList()[0];
        eventManager.afterInputActionList.Add(() => { mainPlayer.playerUI.AddDialogue(playerDialogue); });
    }

    protected void _ChangeScene(string sceneName)
    {
        EntityManagerEvent eventManager = GameManager.Instance.eventManager;
        // kasih wait 1 detik?
        // hud gameplay diitemin?
        eventManager.afterInputActionList.Add(() => { SceneManager.LoadScene(sceneName); });
    }
}
