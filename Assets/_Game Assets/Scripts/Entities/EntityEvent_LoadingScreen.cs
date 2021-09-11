using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEvent_LoadingScreen : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        // add status effect ke player
        _SendDialogueToMainPlayer(new DialogueString("???", "Eh bentar ... ada yang login"));
        _SendDialogueToMainPlayer(new DialogueString("???", "Sek sek, hmm jadi playernya pake AMD Ryzen 3 2200G yah"));
        _SendDialogueToMainPlayer(new DialogueString("???", "Yaelah, miskin nih orang, yawis gua load dulu levelnya"));
        _ChangeScene("Void Realm");
    }
}
