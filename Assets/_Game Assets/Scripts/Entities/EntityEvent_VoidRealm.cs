using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEvent_VoidRealm : EntityEvent
{
    public override void EventOnLoadLevel()
    {
        base.EventOnLoadLevel();

        //eventManager.afterInputActionList.AddRange(new Action[] { 
        //    () => {
        //        // fadein
        //        mainPlayer.storedStatusEffects.Add(new StoredStatusEffectAutoSkip(mainPlayer, 3.0f, 1));
        //        mainPlayer.storedStatusEffects.Add(new StoredStatusEffectPlayerDisableInput(mainPlayer));
        //        mainPlayer.playerUI.AddDialogue(new DialogueString("???", "Halo player"));
        //    },
        //    () => {
        //        mainPlayer.playerUI.AddDialogue(new DialogueString("???", "Nama gua Ai, dan gua goddess di dunia ini"));
        //    },
        //    () => {
        //        mainPlayer.playerUI.AddDialogue(new DialogueString("???", "Lu adalah seorang super secret agent yang bertugas " +
        //            "menghancurkan dokumen yang dimiliki oleh surface dweller, lu mau kan menjalanin tugas ini?"));
        //        // kasih opsi gmana ya
        //        // tampilin opsi, setiap opsinya kasih custom action kalo dipilih
        //    },
        //});
    }
}
