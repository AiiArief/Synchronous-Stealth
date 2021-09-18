using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent_LoadingScreen : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        eventManager.afterInputActionList.AddRange(new Action[] {
            () => {
                // fade in?
                mainPlayer.storedStatusEffects.Add(new StoredStatusEffectAutoSkip(mainPlayer, 3.0f, 1));
                mainPlayer.storedStatusEffects.Add(new StoredStatusEffectPlayerDisableInput(mainPlayer));
                mainPlayer.playerUI.AddDialogue(new DialogueString("???", "Eh bentar ... ada yang login"));
            },
            () => {
                mainPlayer.playerUI.AddDialogue(new DialogueString("???", "Sek sek, hmm jadi playernya pake AMD Ryzen 3 2200G yah"));
            },
            () => {
                mainPlayer.playerUI.AddDialogue(new DialogueString("???", "Yaelah, miskin nih orang, yawis gua load dulu levelnya"));
            },
            () => {
                mainPlayer.storedStatusEffects.Add(new StoredStatusEffectAutoSkip(mainPlayer, 3.0f, 1));
                mainPlayer.playerUI.AddDialogue(new DialogueString("???", "..."));
            },
            () => {
                SceneManager.LoadScene("Void Realm");
            }
        });
    }
}
