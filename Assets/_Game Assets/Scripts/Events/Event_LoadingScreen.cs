using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_LoadingScreen : Event
{
    public static string NextLevelLoad = "Void Realm";

    public override void EventOnLoadLevel()
    {
        EntityPlayer currentPlayer = GameManager.Instance.playerManager.GetPlayerPlayableList()[0];
        currentPlayer.playerUI.AddDialogue(new DialogueString("???", "!!!!"));
        currentPlayer.playerUI.AddDialogue(new DialogueString("???", "A player has login!!!"));
        currentPlayer.playerUI.AddDialogue(new DialogueString("???", "Quick! err... setup first time for the player"));
        currentPlayer.playerUI.AddDialogue(new DialogueString("???", "So, using AMD Ryzen 3 2200g huh? What a potato pc this player have"));
        currentPlayer.playerUI.AddDialogue(new DialogueString("???", "Let me load the level"));
        // teleport
    }
}
