using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredActionDialogue : StoredAction
{
    public StoredActionDialogue(UIDialogue dialogue)
    {
        // cek dulu ada dialog apa engga
        // kalo ada dialog aktifin dialog system
        int i = 0;
        float currentTextDelay = 0;
        float textSpeed = dialogue.textSpeed;
        string str = "";
        string strComplete = dialogue.dialogueStrings[0].dialogue;
        string dialogueName = dialogue.dialogueStrings[0].name;

        action = () =>
        {
            if(i < strComplete.Length && currentTextDelay <= 0.0f)
            {
                str += strComplete[i++];
                dialogue.dialogueText.text = str;

                dialogue.dialogueNameText.text = dialogueName;

                currentTextDelay = textSpeed;
            }

            currentTextDelay = Mathf.Max(currentTextDelay - Time.deltaTime, 0.0f);
            actionHasDone = i >= strComplete.Length;
        };
    }
}
